using MediatR;

using Microsoft.Extensions.Logging;

namespace Sandbox;

internal class ModuleRequestHandler : IRequestHandler<ModuleRequest, Module?>
{
    private readonly ILogger _logger;
    private readonly ModuleFactory _moduleFactory;
    public ModuleRequestHandler(ModuleFactory factory, ILogger<ModuleRequestHandler> logger)
    {
        _logger = logger;
        _moduleFactory = factory;
    }
    public async Task<Module?> Handle(ModuleRequest request, CancellationToken cancellationToken)
    {
        if (!_moduleFactory.TryCreate(request.Key, out Module? module))
        {
            _logger.LogError("Failed to create module with key '{Key}'.", request.Key);
            return await Task.FromResult<Module?>(null);
        }

        return await Task.FromResult(module);
    }
}