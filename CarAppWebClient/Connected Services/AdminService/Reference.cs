﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CarAppWebClient.AdminService {
    using System.Data;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="AdminService.AdminServiceSoap")]
    public interface AdminServiceSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/PopulateUsers", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet PopulateUsers(bool isBanned);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/PopulateUsers", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> PopulateUsersAsync(bool isBanned);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SearchUsers", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet SearchUsers(bool isBanned, int Id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SearchUsers", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> SearchUsersAsync(bool isBanned, int Id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/banUser", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        void banUser(int Id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/banUser", ReplyAction="*")]
        System.Threading.Tasks.Task banUserAsync(int Id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/unbanUser", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        void unbanUser(int Id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/unbanUser", ReplyAction="*")]
        System.Threading.Tasks.Task unbanUserAsync(int Id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/deleteUser", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        void deleteUser(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/deleteUser", ReplyAction="*")]
        System.Threading.Tasks.Task deleteUserAsync(int id);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface AdminServiceSoapChannel : CarAppWebClient.AdminService.AdminServiceSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AdminServiceSoapClient : System.ServiceModel.ClientBase<CarAppWebClient.AdminService.AdminServiceSoap>, CarAppWebClient.AdminService.AdminServiceSoap {
        
        public AdminServiceSoapClient() {
        }
        
        public AdminServiceSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public AdminServiceSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AdminServiceSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AdminServiceSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Data.DataSet PopulateUsers(bool isBanned) {
            return base.Channel.PopulateUsers(isBanned);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> PopulateUsersAsync(bool isBanned) {
            return base.Channel.PopulateUsersAsync(isBanned);
        }
        
        public System.Data.DataSet SearchUsers(bool isBanned, int Id) {
            return base.Channel.SearchUsers(isBanned, Id);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> SearchUsersAsync(bool isBanned, int Id) {
            return base.Channel.SearchUsersAsync(isBanned, Id);
        }
        
        public void banUser(int Id) {
            base.Channel.banUser(Id);
        }
        
        public System.Threading.Tasks.Task banUserAsync(int Id) {
            return base.Channel.banUserAsync(Id);
        }
        
        public void unbanUser(int Id) {
            base.Channel.unbanUser(Id);
        }
        
        public System.Threading.Tasks.Task unbanUserAsync(int Id) {
            return base.Channel.unbanUserAsync(Id);
        }
        
        public void deleteUser(int id) {
            base.Channel.deleteUser(id);
        }
        
        public System.Threading.Tasks.Task deleteUserAsync(int id) {
            return base.Channel.deleteUserAsync(id);
        }
    }
}
