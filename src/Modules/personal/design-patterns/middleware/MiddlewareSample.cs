using sandbox;

namespace Sandbox;
public class MiddlewareSample : ConsumableModule {

    #region Constructor

    public MiddlewareSample() : base("mware", "Middleware", "Demonstrates the chain of responsibility pattern using the concept of middleware.") { }

    #endregion

    #region Public Methods

    public override void Invoke()
    {
        // Create a new application builder.
        IConsoleDelegateBuilder app =
            new ConsoleDelegateBuilder().UseFizzBuzzWriter()
                                        .UseFizzWriter()
                                        .UseBuzzWriter()
                                        .UseWriter();

        // Generate some sample input values.
        var inputs = new List<object>
        {
            "Hello World!",
            Math.Sqrt(3.14159)
        };
        for (int i = 0; i < 35; i++)
            inputs.Add(i);

        // Build the delegate and run it through all inputs.
        ConsoleDelegate consoleDelegate = app.Build();
        foreach (object input in inputs)
            _ = consoleDelegate(input);
    }

    #endregion
    
}