using MediatR;

namespace Sandbox.Runtime
{
    /// <summary>
    /// Represents a handler for <see cref="InputRequest"/>s.
    /// </summary>
    internal class InputRequestHandler : IRequestHandler<InputRequest, string?>
    {
        public async Task<string?> Handle(InputRequest request, CancellationToken cancellationToken)
        {
            Console.WriteLine(request.Prompt);
            string? response = Console.ReadLine();
            return await Task.FromResult(response);
        }
    }
}
