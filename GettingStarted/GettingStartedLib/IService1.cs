using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Net.Security;

namespace GettingStartedLib
{
    #region Example basic
    [ServiceContract(Namespace = "http://Microsoft.ServiceModel.Samples")]
   public interface ICalculator
    {
        [OperationContract]
        double Add(double n1, double n2);
        [OperationContract]
        double Subtract(double n1, double n2);
        [OperationContract]
        double Multiply(double n1, double n2);
        [OperationContract]
        double Divide(int n1, int n2);
    }
    #endregion

    #region Example Fault
    [ServiceContract(Namespace = "http://microsoft.wcf.documentation")]
    public interface ISampleService
    {
        [OperationContract]
        [FaultContractAttribute(
          typeof(GreetingFault),
          Action = "http://www.contoso.com/GreetingFault",
          ProtectionLevel = ProtectionLevel.EncryptAndSign
          )]
        string SampleMethod(string msg);
    }

    [DataContractAttribute]
    public class GreetingFault
    {
        private string report;

        public GreetingFault(string message)
        {
            this.report = message;
        }

        [DataMemberAttribute]
        public string Message
        {
            get { return this.report; }
            set { this.report = value; }
        }
    }
    #endregion

    #region Example Session

    public interface ICalculatorSession
    {
        [OperationContract(IsOneWay = true, IsInitiating = true, IsTerminating = false)]
        void Clear();
        [OperationContract(IsOneWay = true, IsInitiating = false, IsTerminating = false)]
        void AddTo(double n);
        [OperationContract(IsOneWay = true, IsInitiating = false, IsTerminating = false)]
        void SubtractFrom(double n);
        [OperationContract(IsOneWay = true, IsInitiating = false, IsTerminating = false)]
        void MultiplyBy(double n);
        [OperationContract(IsOneWay = true, IsInitiating = false, IsTerminating = false)]
        void DivideBy(double n);
        [OperationContract(IsInitiating = false, IsTerminating = true)]
        double Equals();

     }

        #endregion

    #region Example Asincrono
    [ServiceContract(Namespace = "http://microsoft.wcf.documentation")]
    public interface ISampleServiceAsincrono
    {
        [OperationContract]
        string SampleMethodAsincrono(string msg);

        [OperationContract(AsyncPattern = true)]
        IAsyncResult BeginSampleMethod(string msg, AsyncCallback callback, object asyncState);

        //Note: There is no OperationContractAttribute for the method.
        string EndSampleMethod(IAsyncResult result);

        [OperationContract(AsyncPattern = true)]
        IAsyncResult BeginServiceAsyncMethod(string msg, AsyncCallback callback, object asyncState);

        // Note: There is no OperationContractAttribute for the method.
        string EndServiceAsyncMethod(IAsyncResult result);
    }
    https://docs.microsoft.com/es-es/dotnet/framework/wcf/reliable-services
    #endregion
}



