﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Location.WCFServiceReferences.LocationCallbackServices {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="LocationAlarm", Namespace="http://schemas.datacontract.org/2004/07/Location.TModel.Location.Alarm")]
    [System.SerializableAttribute()]
    public partial class LocationAlarm : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Location.WCFServiceReferences.LocationCallbackServices.LocationAlarmLevel AlarmLevelField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private long AlarmTimeStampField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Location.WCFServiceReferences.LocationCallbackServices.LocationAlarmType AlarmTypeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ContentField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime CreateTimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime HandleTimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private long HandleTimeStampField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Location.WCFServiceReferences.LocationCallbackServices.LocationAlarmHandleType HandleTypeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string HandlerField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Location.WCFServiceReferences.LocationCallbackServices.Personnel PersonnelField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int PersonnelIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Location.WCFServiceReferences.LocationCallbackServices.Tag TagField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int TagIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TypeNameField;
        
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
        public Location.WCFServiceReferences.LocationCallbackServices.LocationAlarmLevel AlarmLevel {
            get {
                return this.AlarmLevelField;
            }
            set {
                if ((this.AlarmLevelField.Equals(value) != true)) {
                    this.AlarmLevelField = value;
                    this.RaisePropertyChanged("AlarmLevel");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public long AlarmTimeStamp {
            get {
                return this.AlarmTimeStampField;
            }
            set {
                if ((this.AlarmTimeStampField.Equals(value) != true)) {
                    this.AlarmTimeStampField = value;
                    this.RaisePropertyChanged("AlarmTimeStamp");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Location.WCFServiceReferences.LocationCallbackServices.LocationAlarmType AlarmType {
            get {
                return this.AlarmTypeField;
            }
            set {
                if ((this.AlarmTypeField.Equals(value) != true)) {
                    this.AlarmTypeField = value;
                    this.RaisePropertyChanged("AlarmType");
                }
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
        public System.DateTime CreateTime {
            get {
                return this.CreateTimeField;
            }
            set {
                if ((this.CreateTimeField.Equals(value) != true)) {
                    this.CreateTimeField = value;
                    this.RaisePropertyChanged("CreateTime");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime HandleTime {
            get {
                return this.HandleTimeField;
            }
            set {
                if ((this.HandleTimeField.Equals(value) != true)) {
                    this.HandleTimeField = value;
                    this.RaisePropertyChanged("HandleTime");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public long HandleTimeStamp {
            get {
                return this.HandleTimeStampField;
            }
            set {
                if ((this.HandleTimeStampField.Equals(value) != true)) {
                    this.HandleTimeStampField = value;
                    this.RaisePropertyChanged("HandleTimeStamp");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Location.WCFServiceReferences.LocationCallbackServices.LocationAlarmHandleType HandleType {
            get {
                return this.HandleTypeField;
            }
            set {
                if ((this.HandleTypeField.Equals(value) != true)) {
                    this.HandleTypeField = value;
                    this.RaisePropertyChanged("HandleType");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Handler {
            get {
                return this.HandlerField;
            }
            set {
                if ((object.ReferenceEquals(this.HandlerField, value) != true)) {
                    this.HandlerField = value;
                    this.RaisePropertyChanged("Handler");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Location.WCFServiceReferences.LocationCallbackServices.Personnel Personnel {
            get {
                return this.PersonnelField;
            }
            set {
                if ((object.ReferenceEquals(this.PersonnelField, value) != true)) {
                    this.PersonnelField = value;
                    this.RaisePropertyChanged("Personnel");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int PersonnelId {
            get {
                return this.PersonnelIdField;
            }
            set {
                if ((this.PersonnelIdField.Equals(value) != true)) {
                    this.PersonnelIdField = value;
                    this.RaisePropertyChanged("PersonnelId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Location.WCFServiceReferences.LocationCallbackServices.Tag Tag {
            get {
                return this.TagField;
            }
            set {
                if ((object.ReferenceEquals(this.TagField, value) != true)) {
                    this.TagField = value;
                    this.RaisePropertyChanged("Tag");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int TagId {
            get {
                return this.TagIdField;
            }
            set {
                if ((this.TagIdField.Equals(value) != true)) {
                    this.TagIdField = value;
                    this.RaisePropertyChanged("TagId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TypeName {
            get {
                return this.TypeNameField;
            }
            set {
                if ((object.ReferenceEquals(this.TypeNameField, value) != true)) {
                    this.TypeNameField = value;
                    this.RaisePropertyChanged("TypeName");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Personnel", Namespace="http://schemas.datacontract.org/2004/07/Location.TModel.Location.Person")]
    [System.SerializableAttribute()]
    public partial class Personnel : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> Abutment_IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AddressField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.DateTime> BirthDayField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.DateTime> BirthTimeStampField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EmailField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool EnabledField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MobileField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NationField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Location.WCFServiceReferences.LocationCallbackServices.Department ParentField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> ParentIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PhoneNumberField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PhotoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PstField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SexField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Location.WCFServiceReferences.LocationCallbackServices.Tag TagField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> TagIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int WorkNumberField;
        
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
        public System.Nullable<int> Abutment_Id {
            get {
                return this.Abutment_IdField;
            }
            set {
                if ((this.Abutment_IdField.Equals(value) != true)) {
                    this.Abutment_IdField = value;
                    this.RaisePropertyChanged("Abutment_Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Address {
            get {
                return this.AddressField;
            }
            set {
                if ((object.ReferenceEquals(this.AddressField, value) != true)) {
                    this.AddressField = value;
                    this.RaisePropertyChanged("Address");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<System.DateTime> BirthDay {
            get {
                return this.BirthDayField;
            }
            set {
                if ((this.BirthDayField.Equals(value) != true)) {
                    this.BirthDayField = value;
                    this.RaisePropertyChanged("BirthDay");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<System.DateTime> BirthTimeStamp {
            get {
                return this.BirthTimeStampField;
            }
            set {
                if ((this.BirthTimeStampField.Equals(value) != true)) {
                    this.BirthTimeStampField = value;
                    this.RaisePropertyChanged("BirthTimeStamp");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Email {
            get {
                return this.EmailField;
            }
            set {
                if ((object.ReferenceEquals(this.EmailField, value) != true)) {
                    this.EmailField = value;
                    this.RaisePropertyChanged("Email");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool Enabled {
            get {
                return this.EnabledField;
            }
            set {
                if ((this.EnabledField.Equals(value) != true)) {
                    this.EnabledField = value;
                    this.RaisePropertyChanged("Enabled");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Mobile {
            get {
                return this.MobileField;
            }
            set {
                if ((object.ReferenceEquals(this.MobileField, value) != true)) {
                    this.MobileField = value;
                    this.RaisePropertyChanged("Mobile");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Nation {
            get {
                return this.NationField;
            }
            set {
                if ((object.ReferenceEquals(this.NationField, value) != true)) {
                    this.NationField = value;
                    this.RaisePropertyChanged("Nation");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Location.WCFServiceReferences.LocationCallbackServices.Department Parent {
            get {
                return this.ParentField;
            }
            set {
                if ((object.ReferenceEquals(this.ParentField, value) != true)) {
                    this.ParentField = value;
                    this.RaisePropertyChanged("Parent");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> ParentId {
            get {
                return this.ParentIdField;
            }
            set {
                if ((this.ParentIdField.Equals(value) != true)) {
                    this.ParentIdField = value;
                    this.RaisePropertyChanged("ParentId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PhoneNumber {
            get {
                return this.PhoneNumberField;
            }
            set {
                if ((object.ReferenceEquals(this.PhoneNumberField, value) != true)) {
                    this.PhoneNumberField = value;
                    this.RaisePropertyChanged("PhoneNumber");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Photo {
            get {
                return this.PhotoField;
            }
            set {
                if ((object.ReferenceEquals(this.PhotoField, value) != true)) {
                    this.PhotoField = value;
                    this.RaisePropertyChanged("Photo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Pst {
            get {
                return this.PstField;
            }
            set {
                if ((object.ReferenceEquals(this.PstField, value) != true)) {
                    this.PstField = value;
                    this.RaisePropertyChanged("Pst");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Sex {
            get {
                return this.SexField;
            }
            set {
                if ((object.ReferenceEquals(this.SexField, value) != true)) {
                    this.SexField = value;
                    this.RaisePropertyChanged("Sex");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Location.WCFServiceReferences.LocationCallbackServices.Tag Tag {
            get {
                return this.TagField;
            }
            set {
                if ((object.ReferenceEquals(this.TagField, value) != true)) {
                    this.TagField = value;
                    this.RaisePropertyChanged("Tag");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> TagId {
            get {
                return this.TagIdField;
            }
            set {
                if ((this.TagIdField.Equals(value) != true)) {
                    this.TagIdField = value;
                    this.RaisePropertyChanged("TagId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int WorkNumber {
            get {
                return this.WorkNumberField;
            }
            set {
                if ((this.WorkNumberField.Equals(value) != true)) {
                    this.WorkNumberField = value;
                    this.RaisePropertyChanged("WorkNumber");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Tag", Namespace="http://schemas.datacontract.org/2004/07/Location.TModel.Location.AreaAndDev")]
    [System.SerializableAttribute()]
    public partial class Tag : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DescribeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
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
        public string Code {
            get {
                return this.CodeField;
            }
            set {
                if ((object.ReferenceEquals(this.CodeField, value) != true)) {
                    this.CodeField = value;
                    this.RaisePropertyChanged("Code");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Describe {
            get {
                return this.DescribeField;
            }
            set {
                if ((object.ReferenceEquals(this.DescribeField, value) != true)) {
                    this.DescribeField = value;
                    this.RaisePropertyChanged("Describe");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
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
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="LocationAlarmLevel", Namespace="http://schemas.datacontract.org/2004/07/DbModel.Tools")]
    public enum LocationAlarmLevel : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        正常 = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        一级告警 = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        二级告警 = 2,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        三级告警 = 3,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        四级告警 = 4,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="LocationAlarmType", Namespace="http://schemas.datacontract.org/2004/07/DbModel.Tools")]
    public enum LocationAlarmType : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        区域告警 = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        消失告警 = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        低电告警 = 2,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        传感器告警 = 3,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        重启告警 = 4,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        非法拆卸 = 5,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="LocationAlarmHandleType", Namespace="http://schemas.datacontract.org/2004/07/DbModel.Tools")]
    public enum LocationAlarmHandleType : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        误报 = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        忽略 = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        确认 = 2,
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Department", Namespace="http://schemas.datacontract.org/2004/07/Location.TModel.Location.Person")]
    [System.SerializableAttribute()]
    public partial class Department : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> Abutment_IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Location.WCFServiceReferences.LocationCallbackServices.Department[] ChildrenField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DescriptionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Location.WCFServiceReferences.LocationCallbackServices.Personnel[] LeafNodesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> ParentIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ShowOrderField;
        
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
        public System.Nullable<int> Abutment_Id {
            get {
                return this.Abutment_IdField;
            }
            set {
                if ((this.Abutment_IdField.Equals(value) != true)) {
                    this.Abutment_IdField = value;
                    this.RaisePropertyChanged("Abutment_Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Location.WCFServiceReferences.LocationCallbackServices.Department[] Children {
            get {
                return this.ChildrenField;
            }
            set {
                if ((object.ReferenceEquals(this.ChildrenField, value) != true)) {
                    this.ChildrenField = value;
                    this.RaisePropertyChanged("Children");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Description {
            get {
                return this.DescriptionField;
            }
            set {
                if ((object.ReferenceEquals(this.DescriptionField, value) != true)) {
                    this.DescriptionField = value;
                    this.RaisePropertyChanged("Description");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Location.WCFServiceReferences.LocationCallbackServices.Personnel[] LeafNodes {
            get {
                return this.LeafNodesField;
            }
            set {
                if ((object.ReferenceEquals(this.LeafNodesField, value) != true)) {
                    this.LeafNodesField = value;
                    this.RaisePropertyChanged("LeafNodes");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> ParentId {
            get {
                return this.ParentIdField;
            }
            set {
                if ((this.ParentIdField.Equals(value) != true)) {
                    this.ParentIdField = value;
                    this.RaisePropertyChanged("ParentId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ShowOrder {
            get {
                return this.ShowOrderField;
            }
            set {
                if ((this.ShowOrderField.Equals(value) != true)) {
                    this.ShowOrderField = value;
                    this.RaisePropertyChanged("ShowOrder");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="LocationCallbackServices.ILocationAlarmService", CallbackContract=typeof(Location.WCFServiceReferences.LocationCallbackServices.ILocationAlarmServiceCallback))]
    public interface ILocationAlarmService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILocationAlarmService/Connect", ReplyAction="http://tempuri.org/ILocationAlarmService/ConnectResponse")]
        void Connect();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILocationAlarmService/DisConnect", ReplyAction="http://tempuri.org/ILocationAlarmService/DisConnectResponse")]
        void DisConnect();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILocationAlarmService/AddAlarmInfo", ReplyAction="http://tempuri.org/ILocationAlarmService/AddAlarmInfoResponse")]
        void AddAlarmInfo(string AlarmInfo);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ILocationAlarmServiceCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/ILocationAlarmService/AlarmInfo")]
        void AlarmInfo(Location.WCFServiceReferences.LocationCallbackServices.LocationAlarm[] localAlarms);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ILocationAlarmServiceChannel : Location.WCFServiceReferences.LocationCallbackServices.ILocationAlarmService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class LocationAlarmServiceClient : System.ServiceModel.DuplexClientBase<Location.WCFServiceReferences.LocationCallbackServices.ILocationAlarmService>, Location.WCFServiceReferences.LocationCallbackServices.ILocationAlarmService {
        
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
        
        public void DisConnect() {
            base.Channel.DisConnect();
        }
        
        public void AddAlarmInfo(string AlarmInfo) {
            base.Channel.AddAlarmInfo(AlarmInfo);
        }
    }
}
