﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RoutingServeur.ProxyService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="JCDecauxStation", Namespace="http://schemas.datacontract.org/2004/07/routing_serveurSOAP")]
    [System.SerializableAttribute()]
    public partial class JCDecauxStation : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string addressField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string contractNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string nameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int numberField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private RoutingServeur.ProxyService.Position positionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private RoutingServeur.ProxyService.TotalStands totalStandsField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string address {
            get {
                return this.addressField;
            }
            set {
                if ((object.ReferenceEquals(this.addressField, value) != true)) {
                    this.addressField = value;
                    this.RaisePropertyChanged("address");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string contractName {
            get {
                return this.contractNameField;
            }
            set {
                if ((object.ReferenceEquals(this.contractNameField, value) != true)) {
                    this.contractNameField = value;
                    this.RaisePropertyChanged("contractName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string name {
            get {
                return this.nameField;
            }
            set {
                if ((object.ReferenceEquals(this.nameField, value) != true)) {
                    this.nameField = value;
                    this.RaisePropertyChanged("name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int number {
            get {
                return this.numberField;
            }
            set {
                if ((this.numberField.Equals(value) != true)) {
                    this.numberField = value;
                    this.RaisePropertyChanged("number");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public RoutingServeur.ProxyService.Position position {
            get {
                return this.positionField;
            }
            set {
                if ((object.ReferenceEquals(this.positionField, value) != true)) {
                    this.positionField = value;
                    this.RaisePropertyChanged("position");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public RoutingServeur.ProxyService.TotalStands totalStands {
            get {
                return this.totalStandsField;
            }
            set {
                if ((object.ReferenceEquals(this.totalStandsField, value) != true)) {
                    this.totalStandsField = value;
                    this.RaisePropertyChanged("totalStands");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Position", Namespace="http://schemas.datacontract.org/2004/07/routing_serveurSOAP")]
    [System.SerializableAttribute()]
    public partial class Position : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double latitudeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double longitudeField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double latitude {
            get {
                return this.latitudeField;
            }
            set {
                if ((this.latitudeField.Equals(value) != true)) {
                    this.latitudeField = value;
                    this.RaisePropertyChanged("latitude");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double longitude {
            get {
                return this.longitudeField;
            }
            set {
                if ((this.longitudeField.Equals(value) != true)) {
                    this.longitudeField = value;
                    this.RaisePropertyChanged("longitude");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="TotalStands", Namespace="http://schemas.datacontract.org/2004/07/routing_serveurSOAP")]
    [System.SerializableAttribute()]
    public partial class TotalStands : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private RoutingServeur.ProxyService.Availabilities availabilitiesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int capacityField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public RoutingServeur.ProxyService.Availabilities availabilities {
            get {
                return this.availabilitiesField;
            }
            set {
                if ((object.ReferenceEquals(this.availabilitiesField, value) != true)) {
                    this.availabilitiesField = value;
                    this.RaisePropertyChanged("availabilities");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int capacity {
            get {
                return this.capacityField;
            }
            set {
                if ((this.capacityField.Equals(value) != true)) {
                    this.capacityField = value;
                    this.RaisePropertyChanged("capacity");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Availabilities", Namespace="http://schemas.datacontract.org/2004/07/routing_serveurSOAP")]
    [System.SerializableAttribute()]
    public partial class Availabilities : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int bikesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int electricalBikesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int electricalInternalBatteryBikesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int electricalRemovableBatteryBikesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int mechanicalBikesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int standsField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int bikes {
            get {
                return this.bikesField;
            }
            set {
                if ((this.bikesField.Equals(value) != true)) {
                    this.bikesField = value;
                    this.RaisePropertyChanged("bikes");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int electricalBikes {
            get {
                return this.electricalBikesField;
            }
            set {
                if ((this.electricalBikesField.Equals(value) != true)) {
                    this.electricalBikesField = value;
                    this.RaisePropertyChanged("electricalBikes");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int electricalInternalBatteryBikes {
            get {
                return this.electricalInternalBatteryBikesField;
            }
            set {
                if ((this.electricalInternalBatteryBikesField.Equals(value) != true)) {
                    this.electricalInternalBatteryBikesField = value;
                    this.RaisePropertyChanged("electricalInternalBatteryBikes");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int electricalRemovableBatteryBikes {
            get {
                return this.electricalRemovableBatteryBikesField;
            }
            set {
                if ((this.electricalRemovableBatteryBikesField.Equals(value) != true)) {
                    this.electricalRemovableBatteryBikesField = value;
                    this.RaisePropertyChanged("electricalRemovableBatteryBikes");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int mechanicalBikes {
            get {
                return this.mechanicalBikesField;
            }
            set {
                if ((this.mechanicalBikesField.Equals(value) != true)) {
                    this.mechanicalBikesField = value;
                    this.RaisePropertyChanged("mechanicalBikes");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int stands {
            get {
                return this.standsField;
            }
            set {
                if ((this.standsField.Equals(value) != true)) {
                    this.standsField = value;
                    this.RaisePropertyChanged("stands");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="JCDecauxContract", Namespace="http://schemas.datacontract.org/2004/07/routing_serveurSOAP")]
    [System.SerializableAttribute()]
    public partial class JCDecauxContract : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string nameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string name {
            get {
                return this.nameField;
            }
            set {
                if ((object.ReferenceEquals(this.nameField, value) != true)) {
                    this.nameField = value;
                    this.RaisePropertyChanged("name");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ProxyService.IProxyService")]
    public interface IProxyService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProxyService/GetStationInfo", ReplyAction="http://tempuri.org/IProxyService/GetStationInfoResponse")]
        RoutingServeur.ProxyService.JCDecauxStation GetStationInfo(string contractName, string stationNumber);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProxyService/GetStationInfo", ReplyAction="http://tempuri.org/IProxyService/GetStationInfoResponse")]
        System.Threading.Tasks.Task<RoutingServeur.ProxyService.JCDecauxStation> GetStationInfoAsync(string contractName, string stationNumber);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProxyService/GetListContract", ReplyAction="http://tempuri.org/IProxyService/GetListContractResponse")]
        RoutingServeur.ProxyService.JCDecauxContract[] GetListContract();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProxyService/GetListContract", ReplyAction="http://tempuri.org/IProxyService/GetListContractResponse")]
        System.Threading.Tasks.Task<RoutingServeur.ProxyService.JCDecauxContract[]> GetListContractAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProxyService/GetListStations", ReplyAction="http://tempuri.org/IProxyService/GetListStationsResponse")]
        RoutingServeur.ProxyService.JCDecauxStation[] GetListStations(string contractName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProxyService/GetListStations", ReplyAction="http://tempuri.org/IProxyService/GetListStationsResponse")]
        System.Threading.Tasks.Task<RoutingServeur.ProxyService.JCDecauxStation[]> GetListStationsAsync(string contractName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProxyService/GetStations", ReplyAction="http://tempuri.org/IProxyService/GetStationsResponse")]
        RoutingServeur.ProxyService.JCDecauxStation[] GetStations();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProxyService/GetStations", ReplyAction="http://tempuri.org/IProxyService/GetStationsResponse")]
        System.Threading.Tasks.Task<RoutingServeur.ProxyService.JCDecauxStation[]> GetStationsAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IProxyServiceChannel : RoutingServeur.ProxyService.IProxyService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ProxyServiceClient : System.ServiceModel.ClientBase<RoutingServeur.ProxyService.IProxyService>, RoutingServeur.ProxyService.IProxyService {
        
        public ProxyServiceClient() {
        }
        
        public ProxyServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ProxyServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ProxyServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ProxyServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public RoutingServeur.ProxyService.JCDecauxStation GetStationInfo(string contractName, string stationNumber) {
            return base.Channel.GetStationInfo(contractName, stationNumber);
        }
        
        public System.Threading.Tasks.Task<RoutingServeur.ProxyService.JCDecauxStation> GetStationInfoAsync(string contractName, string stationNumber) {
            return base.Channel.GetStationInfoAsync(contractName, stationNumber);
        }
        
        public RoutingServeur.ProxyService.JCDecauxContract[] GetListContract() {
            return base.Channel.GetListContract();
        }
        
        public System.Threading.Tasks.Task<RoutingServeur.ProxyService.JCDecauxContract[]> GetListContractAsync() {
            return base.Channel.GetListContractAsync();
        }
        
        public RoutingServeur.ProxyService.JCDecauxStation[] GetListStations(string contractName) {
            return base.Channel.GetListStations(contractName);
        }
        
        public System.Threading.Tasks.Task<RoutingServeur.ProxyService.JCDecauxStation[]> GetListStationsAsync(string contractName) {
            return base.Channel.GetListStationsAsync(contractName);
        }
        
        public RoutingServeur.ProxyService.JCDecauxStation[] GetStations() {
            return base.Channel.GetStations();
        }
        
        public System.Threading.Tasks.Task<RoutingServeur.ProxyService.JCDecauxStation[]> GetStationsAsync() {
            return base.Channel.GetStationsAsync();
        }
    }
}
