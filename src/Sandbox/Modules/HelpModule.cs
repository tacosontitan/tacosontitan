using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mauve;

namespace Sandbox;

[Alias("help")]
[Discoverable("Help", "Displays a list of modules available for execution.")]
internal sealed class HelpModule : Module
{
    private readonly ModuleFactory _moduleFactory;
    public HelpModule(ModuleFactory factory) :
        base("Help") =>
        _moduleFactory = factory;
    protected override async Task Work()
    {
        foreach (ModuleDescription description in _moduleFactory.ModuleDescriptions.OrderBy(o => o.Name))
            await Write($"{description.Name}: {description.Description}");
    }
}