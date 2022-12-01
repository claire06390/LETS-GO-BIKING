
package com.baeldung.soap.ws.client.generated;

import javax.xml.bind.JAXBElement;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElementRef;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;


/**
 * <p>Classe Java pour anonymous complex type.
 * 
 * <p>Le fragment de schéma suivant indique le contenu attendu figurant dans cette classe.
 * 
 * <pre>
 * &lt;complexType&gt;
 *   &lt;complexContent&gt;
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType"&gt;
 *       &lt;sequence&gt;
 *         &lt;element name="findItineraryResult" type="{http://schemas.datacontract.org/2004/07/RoutingServeur}Itinerary" minOccurs="0"/&gt;
 *       &lt;/sequence&gt;
 *     &lt;/restriction&gt;
 *   &lt;/complexContent&gt;
 * &lt;/complexType&gt;
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "", propOrder = {
    "findItineraryResult"
})
@XmlRootElement(name = "findItineraryResponse", namespace = "http://tempuri.org/")
public class FindItineraryResponse {

    @XmlElementRef(name = "findItineraryResult", namespace = "http://tempuri.org/", type = JAXBElement.class, required = false)
    protected JAXBElement<Itinerary> findItineraryResult;

    /**
     * Obtient la valeur de la propriété findItineraryResult.
     * 
     * @return
     *     possible object is
     *     {@link JAXBElement }{@code <}{@link Itinerary }{@code >}
     *     
     */
    public JAXBElement<Itinerary> getFindItineraryResult() {
        return findItineraryResult;
    }

    /**
     * Définit la valeur de la propriété findItineraryResult.
     * 
     * @param value
     *     allowed object is
     *     {@link JAXBElement }{@code <}{@link Itinerary }{@code >}
     *     
     */
    public void setFindItineraryResult(JAXBElement<Itinerary> value) {
        this.findItineraryResult = value;
    }

}
