using Microsoft.Extensions.Hosting;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) => Console.WriteLine(""))
    .Build();