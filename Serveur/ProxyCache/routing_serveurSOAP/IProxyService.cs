using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace routing_serveurSOAP
{
    [ServiceContract]
    public interface IProxyService
    {
        [OperationContract]
        JCDecauxStation GetStationInfo(string contractName, string stationNumber);

        [OperationContract]
        List<JCDecauxContract> GetListContract();


        [OperationContract]
        List<JCDecauxStation> GetListStations(string contractName);


        [OperationContract]
        List<JCDecauxStation> GetStations();

    }
}
