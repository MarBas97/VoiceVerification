﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SpeakerRecognitionClient.MyServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="MyServiceReference.IServiceOperations")]
    public interface IServiceOperations {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceOperations/SendData", ReplyAction="http://tempuri.org/IServiceOperations/SendDataResponse")]
        void SendData(float[] data);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceOperations/SendData", ReplyAction="http://tempuri.org/IServiceOperations/SendDataResponse")]
        System.Threading.Tasks.Task SendDataAsync(float[] data);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceOperations/GetData", ReplyAction="http://tempuri.org/IServiceOperations/GetDataResponse")]
        float[] GetData();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceOperations/GetData", ReplyAction="http://tempuri.org/IServiceOperations/GetDataResponse")]
        System.Threading.Tasks.Task<float[]> GetDataAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceOperationsChannel : SpeakerRecognitionClient.MyServiceReference.IServiceOperations, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceOperationsClient : System.ServiceModel.ClientBase<SpeakerRecognitionClient.MyServiceReference.IServiceOperations>, SpeakerRecognitionClient.MyServiceReference.IServiceOperations {
        
        public ServiceOperationsClient() {
        }
        
        public ServiceOperationsClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceOperationsClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceOperationsClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceOperationsClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void SendData(float[] data) {
            base.Channel.SendData(data);
        }
        
        public System.Threading.Tasks.Task SendDataAsync(float[] data) {
            return base.Channel.SendDataAsync(data);
        }
        
        public float[] GetData() {
            return base.Channel.GetData();
        }
        
        public System.Threading.Tasks.Task<float[]> GetDataAsync() {
            return base.Channel.GetDataAsync();
        }
    }
}