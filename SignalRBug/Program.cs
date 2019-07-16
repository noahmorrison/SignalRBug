using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace SignalRBug
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebHost.CreateDefaultBuilder(args)
                .UseUrls("http://localhost:7778")
                .UseStartup<Startup>()
                .Build()
                .Run();
        }
    }
}