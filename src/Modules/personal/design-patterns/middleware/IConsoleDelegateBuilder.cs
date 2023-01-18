namespace Sandbox;
public interface IConsoleDelegateBuilder {
    ConsoleDelegate Build();
    IConsoleDelegateBuilder Use(Func<object, ConsoleDelegate, Task> middleware);
}