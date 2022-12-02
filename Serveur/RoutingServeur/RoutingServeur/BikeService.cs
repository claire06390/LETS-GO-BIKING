

using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Policy;
using System.Text.Json;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using RoutingServeur.ProxyService;
using System.Device.Location;
using System.ServiceModel;
using Apache.NMS;
using Apache.NMS.ActiveMQ;





namespace RoutingServeur
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" à la fois dans le code et le fichier de configuration.
    public class BikeService : IBikeService
    {

        ProxyServiceClient client = new ProxyServiceClient();

        public void EnqueueItinerary(string location, string destination)
        {
            try
            {
                Itinerary itinerary = findItinerary(location, destination);

                Uri connecturi = new Uri("activemq:tcp://localhost:61616");
                ConnectionFactory connectionFactory = new ConnectionFactory(connecturi);

                IConnection connection = connectionFactory.CreateConnection();
                connection.Start();


                ISession session = connection.CreateSession();

                //Queues
                IDestination queueError = session.GetQueue("error");
                IDestination queueIsUtile = session.GetQueue("isUtile");
                IDestination queueInstructions = session.GetQueue("instructions");


                //Producers
                IMessageProducer producerError = session.CreateProducer(queueError);
                IMessageProducer producerIsUtile = session.CreateProducer(queueIsUtile);
                IMessageProducer producerInstructions = session.CreateProducer(queueInstructions);


                producerError.DeliveryMode = MsgDeliveryMode.NonPersistent;
                producerIsUtile.DeliveryMode = MsgDeliveryMode.NonPersistent;


                //Envoi des messages d'erreur et d'utilité
                ITextMessage messageError = session.CreateTextMessage(itinerary.Error.ToString());
                ITextMessage messageIsUtile = session.CreateTextMessage(itinerary.Is_utile.ToString());
                producerError.Send(messageError);
                producerIsUtile.Send(messageIsUtile);

                if (itinerary.Error == true)
                {
                    return;
                }

                if (itinerary.Is_utile == false)
                {
                    return;
                }

                //   if (itinerary.Error!=true && itinerary.Is_utile != false)
                // {
                producerInstructions.DeliveryMode = MsgDeliveryMode.NonPersistent;
                //Envoi des instructions
                //Step 1 

                ITextMessage messageInstruction = session.CreateTextMessage("Pour atteindre votre déstination vous aller parcourir km durant minutes \n");
                producerInstructions.Send(messageInstruction);
                messageInstruction = session.CreateTextMessage("Pour commencé dirigez vous vers la premiere station a fin de recupérer un vélo\n");
                producerInstructions.Send(messageInstruction);
                foreach (Instructions instructions in itinerary.Step1.paths[0].instructions)
                {
                    int distance = (int)instructions.distance;
                    messageInstruction = session.CreateTextMessage(instructions.text + " sur " + distance.ToString() + " mètre");
                    producerInstructions.Send(messageInstruction);
                }
                messageInstruction = session.CreateTextMessage("\nVous venez d'arriver a la premiere station de vélo, prenez un vélo\n");
                producerInstructions.Send(messageInstruction);

                //Step 2
                messageInstruction = session.CreateTextMessage("Maintenant dirigez vous vers la deuxieme station a vélo\n");
                producerInstructions.Send(messageInstruction);
                foreach (Instructions instructions in itinerary.Step2.paths[0].instructions)
                {
                    int distance = (int)instructions.distance;
                    messageInstruction = session.CreateTextMessage(instructions.text + " durant " + distance.ToString() + " mètre");
                    producerInstructions.Send(messageInstruction);
                }
                messageInstruction = session.CreateTextMessage("\nVous venez d'arriver a la deuxieme station de vélo, poser votre vélo sur une place dispoible \n");
                producerInstructions.Send(messageInstruction);


                //Step 3
                messageInstruction = session.CreateTextMessage("Maintenant dirigez vous votre destination finale a pied\n");
                producerInstructions.Send(messageInstruction);
                foreach (Instructions instructions in itinerary.Step3.paths[0].instructions)
                {
                    int distance = (int)instructions.distance;
                    messageInstruction = session.CreateTextMessage(instructions.text + " durant " + distance.ToString() + " mètre");
                    producerInstructions.Send(messageInstruction);
                }
                messageInstruction = session.CreateTextMessage("\nVous venez d'arriver a votre destination finale, en esperant que ce trajet vous a plu\n");
                producerInstructions.Send(messageInstruction);
                //  }
            }
            catch(Exception e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);

            }


        }



        public Itinerary findItinerary(string location, string destination)
        {
            Itinerary itinerary_error = new Itinerary(true, false, null, null, null);

            //Converti adresse en json avec les informations de position
            string location_json = convertAdressAsync(location).Result;
            string destination_json = convertAdressAsync(destination).Result;



            // obtenir les coordonnées du point de depart
            Places location_places;
            try
            {
                location_places = JsonSerializer.Deserialize<Places>(location_json);
            }
            catch (Exception e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                return itinerary_error;
            }

            double location_place_lat;
            double location_place_lon;

            if (location_places.hits.Length > 0)
            {
                location_place_lat = location_places.hits[0].point.lat;
                location_place_lon = location_places.hits[0].point.lng;
            }
            else
            {
                return itinerary_error;
            }



            // obtenir les coordonnées du point d'arrivé
            Places destination_places;
            try
            {
                destination_places = JsonSerializer.Deserialize<Places>(destination_json);
            }
            catch (Exception e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                return itinerary_error;
            }
            double destination_place_lat;
            double destination_place_lon;
            if (destination_places.hits.Length > 0)
            {
                destination_place_lat = destination_places.hits[0].point.lat;
                destination_place_lon = destination_places.hits[0].point.lng;
            }
            else
            {
                return itinerary_error;
            }




            //obtenir la station la plus proche de l'arrivé et du depart 
            GeoCoordinate location_coordinates = new GeoCoordinate(location_place_lat, location_place_lon);
            GeoCoordinate destination_coordinates = new GeoCoordinate(destination_place_lat, destination_place_lon);
            JCDecauxStation closet_station_location = null;
            JCDecauxStation closet_station_destination = null;
            Double min_distance_location = -1;
            Double min_distance_destination = -1;


            JCDecauxContract[] contracts = getContracts().Result;
            foreach (JCDecauxContract item in contracts)
            {
                JCDecauxStation[] stations = getStations(item.name).Result;
                foreach (JCDecauxStation station in stations)
                {
                    GeoCoordinate stationCoordinates = new GeoCoordinate(station.position.latitude, station.position.longitude);
                    Double distance_to_location = stationCoordinates.GetDistanceTo(location_coordinates);
                    Double distance_to_destination = stationCoordinates.GetDistanceTo(destination_coordinates);


                    if (distance_to_location != 0 && distance_to_location < distance_to_destination && (min_distance_location == -1 || distance_to_location < min_distance_location) && BikeDispo(station))
                    {
                        closet_station_location = station;
                        min_distance_location = distance_to_location;
                    }

                    if (distance_to_destination != 0 && distance_to_location > distance_to_destination && (min_distance_destination == -1 || distance_to_destination < min_distance_destination) && StandDispo(station))
                    {
                        closet_station_destination = station;
                        min_distance_destination = distance_to_destination;
                    }
                }

            }
            //Affectation des latitudes longitudes des stations 
            double stationA_longitude = closet_station_location.position.longitude;
            double stationA_latitude = closet_station_location.position.latitude;
            double stationB_longitude = closet_station_destination.position.longitude;
            double stationB_latitude = closet_station_destination.position.latitude;


            // recherche de chauqe itineraire pour chaque trajets
            Step step1;
            Step step2;
            Step step3;

            try
            {
                // du point de depart a la premiere station , a pied 
                string json_itinerary1 = Pathing(location_place_lon, location_place_lat, stationA_longitude, stationA_latitude, "foot").Result;
                step1 = JsonSerializer.Deserialize<Step>(json_itinerary1);

                // de la premiere station a la deuxieme station , a velo 
                string json_itinerary2 = Pathing(stationA_longitude, stationA_latitude, stationB_longitude, stationB_latitude, "bike").Result;
                step2 = JsonSerializer.Deserialize<Step>(json_itinerary2);

                // de la deuxieme station ay point d'arrivé, a pied 
                string json_itinerary3 = Pathing(stationB_longitude, stationB_latitude, destination_place_lon, destination_place_lat, "foot").Result;
                step3 = JsonSerializer.Deserialize<Step>(json_itinerary3);

            }
            catch (Exception e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                return itinerary_error;
            }

            //verifié si ca vaut le coup de prendre le velo
            //recherche itineraire a pied du depart a l'arrivé et regarder le temps
            Step step_without_bike;

            try
            {

                // de la deuxieme station ay point d'arrivé, a pied 
                string json_itinerary4 = Pathing(location_place_lon, location_place_lat, destination_place_lon, destination_place_lat, "foot").Result;
                step_without_bike = JsonSerializer.Deserialize<Step>(json_itinerary4);
            }
            catch (Exception e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                return itinerary_error;
            }
            bool is_utile = true;
            int time_with_bike = step1.paths[0].time + step2.paths[0].time + step3.paths[0].time;
            int time_without_bike = step_without_bike.paths[0].time;
            if (time_with_bike > time_without_bike)
            {
                is_utile = false;
            }

            // on retourn l'itinéraire final
            Itinerary itinerary = new Itinerary(false, is_utile, step1, step2, step3);
            return itinerary;
        }




        public async Task<JCDecauxContract[]> getContracts()
        {
            JCDecauxContract[] response = await client.GetListContractAsync();
            return response;

        }



        public async Task<JCDecauxStation[]> getStations(string contractName)
        {
            JCDecauxStation[] response  = await client.GetListStationsAsync(contractName);
            return response;
        }

        public async Task<JCDecauxStation[]> getStations2()
        {
            JCDecauxStation[] response = await client.GetStationsAsync();
            return response;
        }


        async Task<string> convertAdressAsync(string adresse)
        {
            HttpClient client = new HttpClient();
            string responseBody = "";
            //this.wow = adresse;
            try
            {
                HttpResponseMessage response = await client.GetAsync("https://graphhopper.com/api/1/geocode?q=" + adresse + "&locale=fr&key=e70d6ab5-3596-4601-bd55-20f2d6ffcc28");
                response.EnsureSuccessStatusCode();
                responseBody = await response.Content.ReadAsStringAsync();
                return responseBody;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                return "";
            }

        }

        Boolean BikeDispo(JCDecauxStation station)
        {
            if (station.totalStands.availabilities.bikes > 0)
            {
                return true;
            }
            return false;
        }


        Boolean StandDispo(JCDecauxStation station)
        {
            if (station.totalStands.availabilities.stands > 0)
            {
                return true;
            }
            return false;
        }



        async Task<string> Pathing(double startLongitude, double startLatitude, double endLongitude, double endLatitude, string type)
        {
           
            HttpClient client = new HttpClient();

            string responseBody = "";
            try
            {
                HttpResponseMessage response = await client.GetAsync("https://graphhopper.com/api/1/route?vehicle="+ type + "&locale=fr&key=e70d6ab5-3596-4601-bd55-20f2d6ffcc28&type=json&points_encoded=false&point="
                    + startLatitude.ToString().Replace(',', '.') + "," + startLongitude.ToString().Replace(',', '.') +
                "&point=" + endLatitude.ToString().Replace(',', '.') + "," + endLongitude.ToString().Replace(',', '.'));
                response.EnsureSuccessStatusCode();
                responseBody = await response.Content.ReadAsStringAsync();
  
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }

            return responseBody;
        }

    }






}
