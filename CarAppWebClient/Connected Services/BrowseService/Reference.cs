﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CarAppWebClient.BrowseService {
    using System.Data;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="BrowseService.BrowseServiceSoap")]
    public interface BrowseServiceSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/PopulateGrid", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet PopulateGrid();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/PopulateGrid", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> PopulateGridAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/FilterGrid", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet FilterGrid(
                    string marca, 
                    string model, 
                    string pretMin, 
                    string pretMax, 
                    string varianta, 
                    string combustibil, 
                    string anMin, 
                    string anMax, 
                    string ccMin, 
                    string ccMax, 
                    string putereCPMin, 
                    string putereCPMax, 
                    string kmMin, 
                    string kmMax, 
                    string caroserie, 
                    string culoare, 
                    string cutieViteze, 
                    string locatie);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/FilterGrid", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> FilterGridAsync(
                    string marca, 
                    string model, 
                    string pretMin, 
                    string pretMax, 
                    string varianta, 
                    string combustibil, 
                    string anMin, 
                    string anMax, 
                    string ccMin, 
                    string ccMax, 
                    string putereCPMin, 
                    string putereCPMax, 
                    string kmMin, 
                    string kmMax, 
                    string caroserie, 
                    string culoare, 
                    string cutieViteze, 
                    string locatie);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/getAnounceData", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        CarAppWebClient.BrowseService.Announce getAnounceData(int IdAnunt);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/getAnounceData", ReplyAction="*")]
        System.Threading.Tasks.Task<CarAppWebClient.BrowseService.Announce> getAnounceDataAsync(int IdAnunt);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4161.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class Announce : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string marcaField;
        
        private string modelField;
        
        private string variantaField;
        
        private string caroserieField;
        
        private string combustibilField;
        
        private string cutieVitezeField;
        
        private string culoareField;
        
        private string dataAnuntField;
        
        private string locatieField;
        
        private string descriereField;
        
        private string telefonField;
        
        private int idUserField;
        
        private int idAnuntField;
        
        private int pretField;
        
        private int anField;
        
        private int kmField;
        
        private int putereField;
        
        private int putereKwField;
        
        private int ccField;
        
        private byte[] imagAnuntField;
        
        private byte[] imag1Field;
        
        private byte[] imag2Field;
        
        private byte[] imag3Field;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string marca {
            get {
                return this.marcaField;
            }
            set {
                this.marcaField = value;
                this.RaisePropertyChanged("marca");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string model {
            get {
                return this.modelField;
            }
            set {
                this.modelField = value;
                this.RaisePropertyChanged("model");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string varianta {
            get {
                return this.variantaField;
            }
            set {
                this.variantaField = value;
                this.RaisePropertyChanged("varianta");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string caroserie {
            get {
                return this.caroserieField;
            }
            set {
                this.caroserieField = value;
                this.RaisePropertyChanged("caroserie");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string combustibil {
            get {
                return this.combustibilField;
            }
            set {
                this.combustibilField = value;
                this.RaisePropertyChanged("combustibil");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string cutieViteze {
            get {
                return this.cutieVitezeField;
            }
            set {
                this.cutieVitezeField = value;
                this.RaisePropertyChanged("cutieViteze");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public string culoare {
            get {
                return this.culoareField;
            }
            set {
                this.culoareField = value;
                this.RaisePropertyChanged("culoare");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public string dataAnunt {
            get {
                return this.dataAnuntField;
            }
            set {
                this.dataAnuntField = value;
                this.RaisePropertyChanged("dataAnunt");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public string locatie {
            get {
                return this.locatieField;
            }
            set {
                this.locatieField = value;
                this.RaisePropertyChanged("locatie");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        public string descriere {
            get {
                return this.descriereField;
            }
            set {
                this.descriereField = value;
                this.RaisePropertyChanged("descriere");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=10)]
        public string telefon {
            get {
                return this.telefonField;
            }
            set {
                this.telefonField = value;
                this.RaisePropertyChanged("telefon");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=11)]
        public int idUser {
            get {
                return this.idUserField;
            }
            set {
                this.idUserField = value;
                this.RaisePropertyChanged("idUser");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=12)]
        public int idAnunt {
            get {
                return this.idAnuntField;
            }
            set {
                this.idAnuntField = value;
                this.RaisePropertyChanged("idAnunt");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=13)]
        public int pret {
            get {
                return this.pretField;
            }
            set {
                this.pretField = value;
                this.RaisePropertyChanged("pret");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=14)]
        public int an {
            get {
                return this.anField;
            }
            set {
                this.anField = value;
                this.RaisePropertyChanged("an");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=15)]
        public int km {
            get {
                return this.kmField;
            }
            set {
                this.kmField = value;
                this.RaisePropertyChanged("km");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=16)]
        public int putere {
            get {
                return this.putereField;
            }
            set {
                this.putereField = value;
                this.RaisePropertyChanged("putere");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=17)]
        public int putereKw {
            get {
                return this.putereKwField;
            }
            set {
                this.putereKwField = value;
                this.RaisePropertyChanged("putereKw");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=18)]
        public int cc {
            get {
                return this.ccField;
            }
            set {
                this.ccField = value;
                this.RaisePropertyChanged("cc");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="base64Binary", Order=19)]
        public byte[] imagAnunt {
            get {
                return this.imagAnuntField;
            }
            set {
                this.imagAnuntField = value;
                this.RaisePropertyChanged("imagAnunt");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="base64Binary", Order=20)]
        public byte[] imag1 {
            get {
                return this.imag1Field;
            }
            set {
                this.imag1Field = value;
                this.RaisePropertyChanged("imag1");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="base64Binary", Order=21)]
        public byte[] imag2 {
            get {
                return this.imag2Field;
            }
            set {
                this.imag2Field = value;
                this.RaisePropertyChanged("imag2");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="base64Binary", Order=22)]
        public byte[] imag3 {
            get {
                return this.imag3Field;
            }
            set {
                this.imag3Field = value;
                this.RaisePropertyChanged("imag3");
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
    public interface BrowseServiceSoapChannel : CarAppWebClient.BrowseService.BrowseServiceSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class BrowseServiceSoapClient : System.ServiceModel.ClientBase<CarAppWebClient.BrowseService.BrowseServiceSoap>, CarAppWebClient.BrowseService.BrowseServiceSoap {
        
        public BrowseServiceSoapClient() {
        }
        
        public BrowseServiceSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public BrowseServiceSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BrowseServiceSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BrowseServiceSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Data.DataSet PopulateGrid() {
            return base.Channel.PopulateGrid();
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> PopulateGridAsync() {
            return base.Channel.PopulateGridAsync();
        }
        
        public System.Data.DataSet FilterGrid(
                    string marca, 
                    string model, 
                    string pretMin, 
                    string pretMax, 
                    string varianta, 
                    string combustibil, 
                    string anMin, 
                    string anMax, 
                    string ccMin, 
                    string ccMax, 
                    string putereCPMin, 
                    string putereCPMax, 
                    string kmMin, 
                    string kmMax, 
                    string caroserie, 
                    string culoare, 
                    string cutieViteze, 
                    string locatie) {
            return base.Channel.FilterGrid(marca, model, pretMin, pretMax, varianta, combustibil, anMin, anMax, ccMin, ccMax, putereCPMin, putereCPMax, kmMin, kmMax, caroserie, culoare, cutieViteze, locatie);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> FilterGridAsync(
                    string marca, 
                    string model, 
                    string pretMin, 
                    string pretMax, 
                    string varianta, 
                    string combustibil, 
                    string anMin, 
                    string anMax, 
                    string ccMin, 
                    string ccMax, 
                    string putereCPMin, 
                    string putereCPMax, 
                    string kmMin, 
                    string kmMax, 
                    string caroserie, 
                    string culoare, 
                    string cutieViteze, 
                    string locatie) {
            return base.Channel.FilterGridAsync(marca, model, pretMin, pretMax, varianta, combustibil, anMin, anMax, ccMin, ccMax, putereCPMin, putereCPMax, kmMin, kmMax, caroserie, culoare, cutieViteze, locatie);
        }
        
        public CarAppWebClient.BrowseService.Announce getAnounceData(int IdAnunt) {
            return base.Channel.getAnounceData(IdAnunt);
        }
        
        public System.Threading.Tasks.Task<CarAppWebClient.BrowseService.Announce> getAnounceDataAsync(int IdAnunt) {
            return base.Channel.getAnounceDataAsync(IdAnunt);
        }
    }
}
