using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;

namespace GettingStartedLib
{
    public class CalculatorService : ICalculator, ISampleService, ICalculatorSession, ISampleServiceAsincrono
    {
        #region Example basic
        public double Add(double n1, double n2)
        {
            double result = n1 + n2;
            Console.WriteLine("Receive Add({0},{1}", n1, n2);
            //Code added to write output to the console window.
            Console.WriteLine("Return: {0}", result);
            return result;
        }

        public double Subtract(double n1, double n2)
        {
            double result = n1 - n2;
            Console.WriteLine("Received Subtract({0},{1})", n1, n2);
            Console.WriteLine("Return: {0}", result);
            return result;

        }

        public double Multiply(double n1, double n2)
        {
            double result = n1 * n2;
            Console.WriteLine("Received Multiply({0},{1})", n1, n2);
            Console.WriteLine("Return: {0}", result);
            return result;
        }

        public double Divide(int n1, int n2)
        {
            double result = n1 / n2;
            Console.WriteLine("Received Divide({0},{1})", n1, n2);
            Console.WriteLine("Return: {0}", result);
            return result;
        }
        #endregion

        #region Example Fault
        public string SampleMethod(string msg)
        {
            Console.WriteLine("Client said: " + msg);
            // Generate intermittent error behvior
            Random rnd = new Random(DateTime.Now.Millisecond);
            int test = rnd.Next(5);
            if (test % 2 != 0)
                return "The service greets you: " + msg;
            else
            {
                throw new FaultException<GreetingFault>(new GreetingFault("A Greeting error occurred. You said: " + msg), new FaultReason("Prueba de error en cliente"));
            }
        }
        #endregion

        #region Example Session

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public void AddTo(double n)
        {
            throw new NotImplementedException();
        }

        public void SubtractFrom(double n)
        {
            throw new NotImplementedException();
        }

        public void MultiplyBy(double n)
        {
            throw new NotImplementedException();
        }

        public void DivideBy(double n)
        {
            throw new NotImplementedException();
        }

        public double Equals()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Example Asincrono

        public string SampleMethodAsincrono(string msg)
        {
            Console.WriteLine("Called synchronous sample method with \"{0}\"", msg);
            return "The synchronous service greets you: " + msg;
        }

        // This asynchronously implement operation is never called because
        // there is a synchronous version of the same method.
        public IAsyncResult BeginSampleMethod(string msg, AsyncCallback callback, object asyncState)
        {
            Console.WriteLine("BeginSampleMethod called with: " + msg);
            return new CompleteAsyncResult<string>(msg);
        }

        public string EndSampleMethod(IAsyncResult result)
        {
            CompleteAsyncResult<string> resultado = result as CompleteAsyncResult<String>;
            return resultado.Data;
        }

        public IAsyncResult BeginServiceAsyncMethod(string msg, AsyncCallback callback, object asyncState)
        {
            Console.WriteLine("BeginServiceAsyncMethod called with: \"{0}\"", msg);
            return new CompleteAsyncResult<string>(msg);
        }

        public string EndServiceAsyncMethod(IAsyncResult result)
        {
            CompleteAsyncResult<string> resultado = result as CompleteAsyncResult<string>;
            Console.WriteLine("EndServiceAsyncMethod called with: \"{0}\"", resultado.Data);
            return resultado.Data;
        }

        #endregion
    }

    // Simple async result implementation
    class CompleteAsyncResult<T> : IAsyncResult
    {
        T data;

        public CompleteAsyncResult(T data)
        {
            this.data = data;
        }

        public T Data
        {
            get { return data; }
        }

        public object AsyncState
        {
            get
            {
                return (object)data;
            }
        }

        public WaitHandle AsyncWaitHandle
        {
            get { throw new Exception("The method or operation is not implemented"); }
        }

        public bool CompletedSynchronously
        {
            get
            {
                return true;
            }
        }

        public bool IsCompleted
        {
            get
            {
                return true;
            }
        }

        //public object AsyncState => (Object)data;

        //public WaitHandle AsyncWaitHandle => throw new Exception("The method or operation is not implemented.");

        //public bool CompletedSynchronously => true;

        //public bool IsCompleted => true;

    }
}
