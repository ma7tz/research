using System;
using System.IO;
using Nancy;
using NLog;

namespace DemoService
{
    public sealed class VersionModule : NancyModule
    {
        private const string Path = "version.txt";
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public VersionModule()
        {
            Get("/version", _ =>
            {
                Logger.Info(DateTime.Now + ": " + Request.Url);

                var number = File.Exists(Path) ? File.ReadAllText(Path) : "tbd";

                var response = new Version
                {
                    Number = number,
                    Software = GetType().AssemblyQualifiedName,
                    Server = Environment.MachineName.ToLower()
                };

                return Response.AsXml(response);
            });
        }

        public sealed class Version
        {
            public string Number { get; set; }
            public string Software { get; set; }
            public string Server { get; set; }
        }
    }
}