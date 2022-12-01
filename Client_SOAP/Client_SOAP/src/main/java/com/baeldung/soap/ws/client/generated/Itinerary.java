
package com.baeldung.soap.ws.client.generated;

import javax.xml.bind.JAXBElement;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlElementRef;
import javax.xml.bind.annotation.XmlType;


/**
 * <p>Classe Java pour Itinerary complex type.
 * 
 * <p>Le fragment de schéma suivant indique le contenu attendu figurant dans cette classe.
 * 
 * <pre>
 * &lt;complexType name="Itinerary"&gt;
 *   &lt;complexContent&gt;
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType"&gt;
 *       &lt;sequence&gt;
 *         &lt;element name="Error" type="{http://www.w3.org/2001/XMLSchema}boolean" minOccurs="0"/&gt;
 *         &lt;element name="Is_utile" type="{http://www.w3.org/2001/XMLSchema}boolean" minOccurs="0"/&gt;
 *         &lt;element name="Step1" type="{http://schemas.datacontract.org/2004/07/RoutingServeur}Step" minOccurs="0"/&gt;
 *         &lt;element name="Step2" type="{http://schemas.datacontract.org/2004/07/RoutingServeur}Step" minOccurs="0"/&gt;
 *         &lt;element name="Step3" type="{http://schemas.datacontract.org/2004/07/RoutingServeur}Step" minOccurs="0"/&gt;
 *       &lt;/sequence&gt;
 *     &lt;/restriction&gt;
 *   &lt;/complexContent&gt;
 * &lt;/complexType&gt;
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "Itinerary", propOrder = {
    "error",
    "isUtile",
    "step1",
    "step2",
    "step3"
})
public class Itinerary {

    @XmlElement(name = "Error")
    protected Boolean error;
    @XmlElement(name = "Is_utile")
    protected Boolean isUtile;
    @XmlElementRef(name = "Step1", namespace = "http://schemas.datacontract.org/2004/07/RoutingServeur", type = JAXBElement.class, required = false)
    protected JAXBElement<Step> step1;
    @XmlElementRef(name = "Step2", namespace = "http://schemas.datacontract.org/2004/07/RoutingServeur", type = JAXBElement.class, required = false)
    protected JAXBElement<Step> step2;
    @XmlElementRef(name = "Step3", namespace = "http://schemas.datacontract.org/2004/07/RoutingServeur", type = JAXBElement.class, required = false)
    protected JAXBElement<Step> step3;

    /**
     * Obtient la valeur de la propriété error.
     * 
     * @return
     *     possible object is
     *     {@link Boolean }
     *     
     */
    public Boolean isError() {
        return error;
    }

    /**
     * Définit la valeur de la propriété error.
     * 
     * @param value
     *     allowed object is
     *     {@link Boolean }
     *     
     */
    public void setError(Boolean value) {
        this.error = value;
    }

    /**
     * Obtient la valeur de la propriété isUtile.
     * 
     * @return
     *     possible object is
     *     {@link Boolean }
     *     
     */
    public Boolean isIsUtile() {
        return isUtile;
    }

    /**
     * Définit la valeur de la propriété isUtile.
     * 
     * @param value
     *     allowed object is
     *     {@link Boolean }
     *     
     */
    public void setIsUtile(Boolean value) {
        this.isUtile = value;
    }

    /**
     * Obtient la valeur de la propriété step1.
     * 
     * @return
     *     possible object is
     *     {@link JAXBElement }{@code <}{@link Step }{@code >}
     *     
     */
    public JAXBElement<Step> getStep1() {
        return step1;
    }

    /**
     * Définit la valeur de la propriété step1.
     * 
     * @param value
     *     allowed object is
     *     {@link JAXBElement }{@code <}{@link Step }{@code >}
     *     
     */
    public void setStep1(JAXBElement<Step> value) {
        this.step1 = value;
    }

    /**
     * Obtient la valeur de la propriété step2.
     * 
     * @return
     *     possible object is
     *     {@link JAXBElement }{@code <}{@link Step }{@code >}
     *     
     */
    public JAXBElement<Step> getStep2() {
        return step2;
    }

    /**
     * Définit la valeur de la propriété step2.
     * 
     * @param value
     *     allowed object is
     *     {@link JAXBElement }{@code <}{@link Step }{@code >}
     *     
     */
    public void setStep2(JAXBElement<Step> value) {
        this.step2 = value;
    }

    /**
     * Obtient la valeur de la propriété step3.
     * 
     * @return
     *     possible object is
     *     {@link JAXBElement }{@code <}{@link Step }{@code >}
     *     
     */
    public JAXBElement<Step> getStep3() {
        return step3;
    }

    /**
     * Définit la valeur de la propriété step3.
     * 
     * @param value
     *     allowed object is
     *     {@link JAXBElement }{@code <}{@link Step }{@code >}
     *     
     */
    public void setStep3(JAXBElement<Step> value) {
        this.step3 = value;
    }

}
