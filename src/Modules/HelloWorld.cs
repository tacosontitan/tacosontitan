using Sandbox.Modules;
/// <summary>
/// Represents a basic module that says hello to the world.
/// </summary>
internal sealed class HelloWorld : Module
{
    /// <summary>
    /// Creates a new instance of the <see cref="HelloWorld" /> module.
    /// </summary>
    public HelloWorld() :
        base("hello", "Hello World", "Says hello to the world.")
    { }
    protected override async Task Work() =>
        await Write("Hello world!");
}