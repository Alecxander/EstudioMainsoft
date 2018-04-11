using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using GettingStartedLib;
using System.ServiceModel.Description;
using Utils;

namespace GettingStartedHost
{
    class Program
    {
        static void Main(string[] args)
        { 
            if( Util.seleccionarExample() == Util.EnumExamples.ExampleBasic)
            {
                #region Example basic
                // Step 1 Create a URI to serve as the base address.  
                Uri baseAddress = new Uri("http://localhost:8000/GettingStarted/");

                // Step 2 Create a ServiceHost instance  
                ServiceHost selfHost = new ServiceHost(typeof(CalculatorService), baseAddress);

                try
                {
                    // Step 3 Add a service endpoint.  
                    selfHost.AddServiceEndpoint(typeof(ICalculator), new WSHttpBinding(), "CalculatorService");

                    // Step 4 Enable metadata exchange.  
                    ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                    smb.HttpGetEnabled = true;
                    selfHost.Description.Behaviors.Add(smb);

                    // Step 5 Start the service.  
                    selfHost.Open();
                    Console.WriteLine("The service is ready.[ICalculator]");
                    Console.WriteLine("Press <ENTER> to terminate service.");
                    Console.WriteLine();
                    Console.ReadLine();

                    // Close the ServiceHostBase to shutdown the service.  
                    selfHost.Close();
                }
                catch (CommunicationException ce)
                {
                    Console.WriteLine("An exception occurred: {0}", ce.Message);
                    selfHost.Abort();
                }
                #endregion
            }
            else if( Util.seleccionarExample() == Util.EnumExamples.ExampleFault)
            {
                #region Example Fault
                // Step 1 Create a URI to serve as the base address
                Uri baseAddress = new Uri("http://localhost:8000/GettingStarted/");

                // Step 2 Create a ServiceHost instance
                ServiceHost selfHost = new ServiceHost(typeof(CalculatorService), baseAddress);

                try
                {
                    // Step 3 Add a service endpoint
                    //selfHost.AddServiceEndpoint(typeof(ICalculator), new WSHttpBinding(), "CalculatorService");

                    selfHost.AddServiceEndpoint(typeof(ISampleService), new WSHttpBinding(), "CalculatorService");
                    // Step 4 Enable metadata exchange
                    ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                    smb.HttpGetEnabled = true;
                    selfHost.Description.Behaviors.Add(smb);

                    // Step 5 Start the service
                    selfHost.Open();
                    Console.WriteLine("The service is ready.[ISampleService]");
                    Console.WriteLine("Press <Enter> to teminate service.");
                    Console.WriteLine();
                    Console.ReadLine();

                    // Close the ServiceHostBase to shutdown the service.
                    selfHost.Close();
                }
                catch (TimeoutException timeProblem)
                {
                    Console.WriteLine("The service operation timed out. " + timeProblem.Message);
                    Console.ReadLine();
                    selfHost.Abort();
                }
                catch (FaultException<GreetingFault> greetingFault)
                {
                    Console.WriteLine(greetingFault.Detail.Message);
                    Console.ReadLine();
                    selfHost.Abort();
                }
                catch (FaultException unknownFault)
                {
                    Console.WriteLine("An unknown exception was received. " + unknownFault.Message);
                    Console.ReadLine();
                    selfHost.Abort();
                }
                catch (CommunicationException ce)
                {
                    Console.WriteLine("An exception occurred: {0}", ce.Message);
                    Console.ReadLine();
                    selfHost.Abort();
                }
                #endregion Example Fault
            }
            else if( Util.seleccionarExample() == Util.EnumExamples.ExampleAsincrono)
            {
                #region Example Asincrono
                // Step 1 Create a URI to serve as the base address.  
                Uri baseAddress = new Uri("http://localhost:8000/GettingStarted/");

                // Step 2 Create a ServiceHost instance  
                ServiceHost selfHost = new ServiceHost(typeof(CalculatorService), baseAddress);

                try
                {
                    // Step 3 Add a service endpoint.  
                    selfHost.AddServiceEndpoint(typeof(ISampleServiceAsincrono), new WSHttpBinding(), "CalculatorService");

                    // Step 4 Enable metadata exchange.  
                    ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                    smb.HttpGetEnabled = true;
                    selfHost.Description.Behaviors.Add(smb);

                    // Step 5 Start the service.  
                    selfHost.Open();
                    Console.WriteLine("The service is ready.[ISampleServiceAsincrono]");
                    Console.WriteLine("Press <ENTER> to terminate service.");
                    Console.WriteLine();
                    Console.ReadLine();

                    // Close the ServiceHostBase to shutdown the service.  
                    selfHost.Close();
                }
                catch (CommunicationException ce)
                {
                    Console.WriteLine("An exception occurred: {0}", ce.Message);
                    selfHost.Abort();
                }
                #endregion
            }
        }
    }
}
