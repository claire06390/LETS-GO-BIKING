using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Text.Json;

namespace routing_serveurSOAP
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" à la fois dans le code et le fichier de configuration.
    public class ProxyService : IProxyService
    {
        ProxyCache<JCDecauxObject> proxy = new ProxyCache<JCDecauxObject>();
        int updateDuration = 60;
        public JCDecauxStation GetStationInfo(string contractName, string stationNumber)
        {
            //Mise à jour des jsons représentant les stations toutes les 60s
           
            string urlStation = "https://api.jcdecaux.com/vls/v3/stations/" + stationNumber + "?contract=" + contractName + "&apiKey=3a08a8db05929919d5cbaf930c02cfdc401ada98";
            string response = proxy.Get(urlStation, updateDuration).getJson().Replace("\\", string.Empty);
            return JsonSerializer.Deserialize<JCDecauxStation>(response);
        }

        public List<JCDecauxContract> GetListContract()
        {
            string urlContrats = "https://api.jcdecaux.com/vls/v3/contracts?apiKey=3a08a8db05929919d5cbaf930c02cfdc401ada98";
            string response = proxy.Get(urlContrats, updateDuration).getJson().Replace("\\", string.Empty);
            return JsonSerializer.Deserialize<List<JCDecauxContract>>(response);
        }

        public List<JCDecauxStation> GetListStations(string contractName)
        {
            string urlStations = "https://api.jcdecaux.com/vls/v3/stations?contract="+ contractName + "&apiKey=3a08a8db05929919d5cbaf930c02cfdc401ada98";
            string response = proxy.Get(urlStations, updateDuration).getJson();
            return JsonSerializer.Deserialize<List<JCDecauxStation>>(response);
        }

        public List<JCDecauxStation> GetStations()
        {
            string urlStations = "https://api.jcdecaux.com/vls/v3/stations?apiKey=3a08a8db05929919d5cbaf930c02cfdc401ada98";
            string response = proxy.Get(urlStations, updateDuration).getJson();
            return JsonSerializer.Deserialize<List<JCDecauxStation>>(response);
        }
    }
}
