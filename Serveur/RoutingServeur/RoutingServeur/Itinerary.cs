using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace RoutingServeur
{
    [DataContract]
    public class Itinerary
    {
        [DataMember]
        public bool Error { get; set; }

        [DataMember]
        public bool Is_utile { get; set; }

        [DataMember]
        public Step Step1 { get; set; }

        [DataMember]
        public Step Step2 { get; set; }

        [DataMember]
        public Step Step3 { get; set; }
        public Itinerary(bool error, bool is_utile, Step step1, Step step2, Step step3)
        {
        Error = error;
        Is_utile = is_utile;
        Error = error;
        Step1 = step1;
        Step2 = step2;
        Step3 = step3;
        }

}
    [DataContract]
    public class Step
    {

        [DataMember]
        public Paths[] paths { get; set; }
    }

    [DataContract]
    public class Paths
    {
        [DataMember]
        public double distance { get; set; }

        [DataMember] 
        public int time { get; set; }


        [DataMember] 
        public List<Instructions> instructions { get; set; }

    }
    [DataContract]
    public class Instructions
    {


        [DataMember] 
        public string text { get; set; }


        [DataMember]
        public double distance { get; set; }

    }


    public class Place
    {
        public string name { get; set; }

        public Point point { get; set; }

    }



    public class Point
    {
        public double lng { get; set; }

        public double lat { get; set; }

    }



    public class Places
    {
        public Place[] hits { get; set; }
    }
}
