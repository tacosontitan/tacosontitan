using sandbox;
/// <summary>
/// Represents a basic module that says hello to the world.
/// </summary>
internal sealed class HelloWorld : ConsumableModule {
    /// <summary>
    /// Creates a new instance of the <see cref="HelloWorld" /> module.
    /// </summary>
    public HelloWorld() : base("hello", "Hello World", "Says hello to the world.") { }
    public override void Invoke() => PostMessage("Hello world!");
}