namespace Sandbox;
internal class ConsoleDelegateBuilder : IConsoleDelegateBuilder {

    #region Fields

    private readonly List<Func<object, ConsoleDelegate, Task>> _middlewares;

    #endregion

    #region Constructor

    public ConsoleDelegateBuilder() => _middlewares = new List<Func<object, ConsoleDelegate, Task>>();

    #endregion

    #region Public Methods

    public ConsoleDelegate Build() => async (input) => await InvokeMiddlewareRecursive(input, 0);
    public IConsoleDelegateBuilder Use(Func<object, ConsoleDelegate, Task> middleware) {
        _middlewares.Add(middleware);
        return this;
    }

    #endregion

    #region Private Methods

    private async Task InvokeMiddlewareRecursive(object input, int currentMiddlewareIndex) {
        // If we have no more middleware, then return null.
        if (currentMiddlewareIndex == _middlewares.Count)
            await Task.CompletedTask;
        else {
            // Invoke the current middleware.
            Func<object, ConsoleDelegate, Task> middleware = _middlewares[currentMiddlewareIndex];
            await middleware(input, async (middlewareInput) => await InvokeMiddlewareRecursive(middlewareInput, ++currentMiddlewareIndex));
        }
    }

    #endregion

}