using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using GettingStartedClient.ServiceReference1;
using Utils;

namespace GettingStartedClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var example = Util.seleccionarExample();
            if (example == Util.EnumExamples.ExampleBasic)
            {
                #region Example basic
                //// Step 1: Create an instance of the WCF proxy.
                //CalculatorClient client = new CalculatorClient();

                //// Step 2: Call the service operations.
                //// Call the add service operation
                //double value1 = 100.00D;
                //double value2 = 15.99D;
                //double result = client.Add(value1, value2);
                //Console.WriteLine("Add({0},{1}) = {2}", value1, value2, result);

                //// Call the Multiply service operation.  
                //value1 = 9.00D;
                //value2 = 81.25D;
                //result = client.Multiply(value1, value2);
                //Console.WriteLine("Multiply({0},{1}) = {2}", value1, value2, result);

                //// Call the Divide service operation.  
                //value1 = 22;
                //value2 = 5;
                //result = client.Divide(value1, value2);
                //Console.WriteLine("Divide({0},{1}) = {2}", value1, value2, result);



                //// Step 3: Closing the client gracefully closes the connection and clean up resources.
                //client.Close();
                //Console.ReadLine();
                #endregion
            }
            else if ( example == Util.EnumExamples.ExampleFault)
            {
                #region Example Fault
                SampleServiceClient client = new SampleServiceClient();
                try
                {

                    // Test Fault Execption
                    string msg = "Probar el error";
                    string result = client.SampleMethod(msg);
                    Console.WriteLine("Error Fault " + result);

                    client.Close();
                    Console.ReadLine();
                }
                catch (TimeoutException timeProblem)
                {
                    Console.WriteLine("The service operation timed out. " + timeProblem.Message);
                    Console.ReadLine();
                    client.Abort();
                }
                catch (FaultException<GreetingFault> greetingFault)
                {
                    Console.WriteLine(greetingFault.Detail.Message);
                    Console.ReadLine();
                    client.Abort();
                }
                catch (FaultException unknownFault)
                {
                    Console.WriteLine("An unknown exception was received. " + unknownFault.Message);
                    Console.ReadLine();
                    client.Abort();
                }
                catch (CommunicationException ce)
                {
                    Console.WriteLine("An exception occurred: {0}", ce.Message);
                    Console.ReadLine();
                    client.Abort();
                }
                #endregion
            }
            else if(example == Util.EnumExamples.ExampleAsincrono)
            {
                #region Example Asincrono

                ////// Step 1: Create an instance of the WCF proxy
                //SampleServiceAsincronoClient cliente = new SampleServiceAsincronoClient();

                ////// Step 2: Call the service operations.
                //Console.WriteLine(cliente.SampleMethodAsincrono("Metodo SampleMethodAsincrono"));

                //cliente.Close();
                //Console.ReadLine();

                #endregion
            }
        }
    }
}
