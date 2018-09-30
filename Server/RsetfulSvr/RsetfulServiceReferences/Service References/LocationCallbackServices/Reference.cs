﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace RsetfulServiceReferences.LocationCallbackServices {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="LocationAlarm", Namespace="http://schemas.datacontract.org/2004/07/Location.Model")]
    [System.SerializableAttribute()]
    public partial class LocationAlarm : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ContentField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int TypeField;
        
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
        public string Content {
            get {
                return this.ContentField;
            }
            set {
                if ((object.ReferenceEquals(this.ContentField, value) != true)) {
                    this.ContentField = value;
                    this.RaisePropertyChanged("Content");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Type {
            get {
                return this.TypeField;
            }
            set {
                if ((this.TypeField.Equals(value) != true)) {
                    this.TypeField = value;
                    this.RaisePropertyChanged("Type");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="LocationCallbackServices.ILocationAlarmService", CallbackContract=typeof(RsetfulServiceReferences.LocationCallbackServices.ILocationAlarmServiceCallback))]
    public interface ILocationAlarmService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILocationAlarmService/Connect", ReplyAction="http://tempuri.org/ILocationAlarmService/ConnectResponse")]
        void Connect();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILocationAlarmService/Connect", ReplyAction="http://tempuri.org/ILocationAlarmService/ConnectResponse")]
        System.Threading.Tasks.Task ConnectAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILocationAlarmService/DisConnect", ReplyAction="http://tempuri.org/ILocationAlarmService/DisConnectResponse")]
        void DisConnect();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILocationAlarmService/DisConnect", ReplyAction="http://tempuri.org/ILocationAlarmService/DisConnectResponse")]
        System.Threading.Tasks.Task DisConnectAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILocationAlarmService/AddAlarmInfo", ReplyAction="http://tempuri.org/ILocationAlarmService/AddAlarmInfoResponse")]
        void AddAlarmInfo(string AlarmInfo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILocationAlarmService/AddAlarmInfo", ReplyAction="http://tempuri.org/ILocationAlarmService/AddAlarmInfoResponse")]
        System.Threading.Tasks.Task AddAlarmInfoAsync(string AlarmInfo);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ILocationAlarmServiceCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/ILocationAlarmService/AlarmInfo")]
        void AlarmInfo(RsetfulServiceReferences.LocationCallbackServices.LocationAlarm[] localAlarms);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ILocationAlarmServiceChannel : RsetfulServiceReferences.LocationCallbackServices.ILocationAlarmService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class LocationAlarmServiceClient : System.ServiceModel.DuplexClientBase<RsetfulServiceReferences.LocationCallbackServices.ILocationAlarmService>, RsetfulServiceReferences.LocationCallbackServices.ILocationAlarmService {
        
        public LocationAlarmServiceClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public LocationAlarmServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public LocationAlarmServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public LocationAlarmServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public LocationAlarmServiceClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public void Connect() {
            base.Channel.Connect();
        }
        
        public System.Threading.Tasks.Task ConnectAsync() {
            return base.Channel.ConnectAsync();
        }
        
        public void DisConnect() {
            base.Channel.DisConnect();
        }
        
        public System.Threading.Tasks.Task DisConnectAsync() {
            return base.Channel.DisConnectAsync();
        }
        
        public void AddAlarmInfo(string AlarmInfo) {
            base.Channel.AddAlarmInfo(AlarmInfo);
        }
        
        public System.Threading.Tasks.Task AddAlarmInfoAsync(string AlarmInfo) {
            return base.Channel.AddAlarmInfoAsync(AlarmInfo);
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="LocationCallbackServices.ILocationInfoService", CallbackContract=typeof(RsetfulServiceReferences.LocationCallbackServices.ILocationInfoServiceCallback))]
    public interface ILocationInfoService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILocationInfoService/InfoConnect", ReplyAction="http://tempuri.org/ILocationInfoService/InfoConnectResponse")]
        void InfoConnect();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILocationInfoService/InfoConnect", ReplyAction="http://tempuri.org/ILocationInfoService/InfoConnectResponse")]
        System.Threading.Tasks.Task InfoConnectAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILocationInfoService/DisInfoConnect", ReplyAction="http://tempuri.org/ILocationInfoService/DisInfoConnectResponse")]
        void DisInfoConnect();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILocationInfoService/DisInfoConnect", ReplyAction="http://tempuri.org/ILocationInfoService/DisInfoConnectResponse")]
        System.Threading.Tasks.Task DisInfoConnectAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILocationInfoService/GetInfo", ReplyAction="http://tempuri.org/ILocationInfoService/GetInfoResponse")]
        string[] GetInfo(int i);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILocationInfoService/GetInfo", ReplyAction="http://tempuri.org/ILocationInfoService/GetInfoResponse")]
        System.Threading.Tasks.Task<string[]> GetInfoAsync(int i);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ILocationInfoServiceCallback {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILocationInfoService/GetInfoFromRsetful", ReplyAction="http://tempuri.org/ILocationInfoService/GetInfoFromRsetfulResponse")]
        string[] GetInfoFromRsetful(int i);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ILocationInfoServiceChannel : RsetfulServiceReferences.LocationCallbackServices.ILocationInfoService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class LocationInfoServiceClient : System.ServiceModel.DuplexClientBase<RsetfulServiceReferences.LocationCallbackServices.ILocationInfoService>, RsetfulServiceReferences.LocationCallbackServices.ILocationInfoService {
        
        public LocationInfoServiceClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public LocationInfoServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public LocationInfoServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public LocationInfoServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public LocationInfoServiceClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public void InfoConnect() {
            base.Channel.InfoConnect();
        }
        
        public System.Threading.Tasks.Task InfoConnectAsync() {
            return base.Channel.InfoConnectAsync();
        }
        
        public void DisInfoConnect() {
            base.Channel.DisInfoConnect();
        }
        
        public System.Threading.Tasks.Task DisInfoConnectAsync() {
            return base.Channel.DisInfoConnectAsync();
        }
        
        public string[] GetInfo(int i) {
            return base.Channel.GetInfo(i);
        }
        
        public System.Threading.Tasks.Task<string[]> GetInfoAsync(int i) {
            return base.Channel.GetInfoAsync(i);
        }
    }
}