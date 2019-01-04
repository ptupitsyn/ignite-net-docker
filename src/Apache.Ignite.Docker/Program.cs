using System.Threading;
using Apache.Ignite.Core;

namespace Apache.Ignite.Docker
{
    class Program
    {
        static void Main()
        {
            Ignition.Start();
            Thread.Sleep(Timeout.Infinite);
        }
    }
}
