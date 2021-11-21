using System;
using System.Globalization;
using System.IO;
using System.Net.Sockets;

namespace InternetTIme
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new TcpClient("time.nist.gov", 13);
            //Net.Sockets             (server, port) 

            using (var streamReader = new StreamReader(client.GetStream()))
            {
                var response = streamReader.ReadToEnd();
                var utcDateTimeString = response.Substring(7, 17);
                var format = "yy-MM-dd HH:mm:ss";
                CultureInfo CI = CultureInfo.InvariantCulture;
                var localDateTime = DateTime.ParseExact(utcDateTimeString, format, CI);
                //Convert to DateTime 
                Console.WriteLine("Response: " + response);
                Console.WriteLine("utcDateTimeString: " + utcDateTimeString);
                Console.WriteLine("\nlocalDateTime: " + localDateTime);
            }
        }
    }
}
