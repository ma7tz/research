using System;
using System.Threading.Tasks;
using Nancy;
using NLog;

namespace DemoService
{
    public sealed class StressModule : NancyModule
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public StressModule()
        {
            Get("/fibonacci", async (x, ct) =>
            {
                Logger.Info(DateTime.Now + ": " + Request.Url);

                var fib = await Fib((int) Request.Query["number"]);

                Logger.Info(fib);

                return Response.AsText(fib.ToString());
            });
        }

        private static Task<int> Fib(int f)
        {
            return new TaskFactory<int>().StartNew(delegate
            {
                if (f < 0) return -1;

                switch (f)
                {
                    case 0:
                    case 1:
                        return 0;
                    case 2:
                        return 1;
                    default:
                        return Fib(f - 1).Result + Fib(f - 2).Result;
                }
            });
        }
    }
}