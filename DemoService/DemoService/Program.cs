using System;
using System.Threading;
using Nancy.Hosting.Self;
using NLog;

namespace DemoService
{
    public static class Program
    {
        private const string Url = "http://localhost:1234";
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public static void Main(string[] args)
        {
            var configs = new HostConfiguration
            {
                UrlReservations = {CreateAutomatically = true}
                //MaximumConnectionCount = 2
            };

            var uri = new Uri(Url);
            var host = new NancyHost(configs, uri);

            host.Start();

            Logger.Info($"Running on {Url}");

            new AutoResetEvent(false).WaitOne();
        }
    }
}