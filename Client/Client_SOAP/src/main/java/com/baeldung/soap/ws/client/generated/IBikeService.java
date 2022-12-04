
package com.baeldung.soap.ws.client.generated;

import javax.jws.WebMethod;
import javax.jws.WebParam;
import javax.jws.WebService;
import javax.xml.bind.annotation.XmlSeeAlso;
import javax.xml.ws.RequestWrapper;
import javax.xml.ws.ResponseWrapper;


/**
 * This class was generated by the JAX-WS RI.
 * JAX-WS RI 2.3.2
 * Generated source version: 2.2
 * 
 */
@WebService(name = "IBikeService", targetNamespace = "http://tempuri.org/")
@XmlSeeAlso({
    ObjectFactory.class
})
public interface IBikeService {


    /**
     * 
     * @param destination
     * @param location
     */
    @WebMethod(operationName = "EnqueueItinerary", action = "http://tempuri.org/IBikeService/EnqueueItinerary")
    @RequestWrapper(localName = "EnqueueItinerary", targetNamespace = "http://tempuri.org/", className = "com.baeldung.soap.ws.client.generated.EnqueueItinerary")
    @ResponseWrapper(localName = "EnqueueItineraryResponse", targetNamespace = "http://tempuri.org/", className = "com.baeldung.soap.ws.client.generated.EnqueueItineraryResponse")
    public void enqueueItinerary(
        @WebParam(name = "location", targetNamespace = "http://tempuri.org/")
        String location,
        @WebParam(name = "destination", targetNamespace = "http://tempuri.org/")
        String destination);

}