using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

Console.WriteLine("📦 Starting sandbox.");
IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(Configure)
    .Build();

host.Run();

void Configure(IServiceCollection services)
{

}
