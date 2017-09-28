using System;

namespace RestAPITests.Tests
{
    public class FunctionalTest
    {
        public static void Setup()
        {
            //        System.setProperty("http.proxyHost", "localhost");
            //        System.setProperty("http.proxyPort", "8888");
            string baseHost = System.Environment.GetEnvironmentVariable("server.host");               
                
            Console.WriteLine(baseHost);

            if (baseHost == null)
            {
                baseHost = "http://services.groupkt.com";
            }            
        }

    }
}
