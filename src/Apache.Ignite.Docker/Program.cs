using System;
using System.Threading;
using Apache.Ignite.Core;

namespace Apache.Ignite.Docker
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Starting Ignite.NET...");

            Ignition.Start();

            Console.WriteLine("Ignite.NET started!");

            Thread.Sleep(Timeout.Infinite);
        }
    }
}
