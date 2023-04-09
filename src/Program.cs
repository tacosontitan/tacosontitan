using Bonfire.Hosting;

using Sandbox;

// Start the sandbox.
await Ignite.UseIgnition<Startup>(args)
            .RunAsync();