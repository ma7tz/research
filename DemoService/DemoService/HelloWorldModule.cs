using System;
using Nancy;
using NLog;

namespace DemoService
{
    public sealed class HelloWorldModule : NancyModule
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public HelloWorldModule()
        {
            Get("/", _ =>
            {
                Logger.Info(DateTime.Now + ": " + Request.Url);

                string name = Request.Query["name"];

                if (string.IsNullOrWhiteSpace(name))
                    name = "World";

                var machine = Environment.MachineName.ToLower();

                return $"Hello {name} from Nancy@{machine}" + Environment.NewLine;
            });
        }
    }
}