# 🌮 Taco's Sandbox 📦
Do you ever get tired of creating console app after console app just to test out ideas or concepts? Well, so do I! This sandbox utilizes reflection to enable a modularized approach to testing new ideas and concepts.

[![Example of runtime execution.](images/screenshot.jpg)](images/screenshot.jpg)

Implementation is as simple as deriving a new `class` from `ConsumableModule`:

```cs
internal sealed class HelloWorld : ConsumableModule {
    public HelloWorld() : base("hello", "Hello World", "Says hello to the world.") { }
    public override void Invoke() => PostMessage("Hello world!");
}
```

Then simply use `dotnet run` to start the sandbox and enter the key for your module when prompted:

> Successfully discovered 1 module(s).<br/>
> If you need help at any point, use the `help` command.<br/>
> To exit the application, use the `exit` command.<br/>
> \> hello<br/>
> Hello World: Hello world!

It's as simple as that! Welcome to my sandbox, wanna play?

## Design Patterns
I've implemented plenty of design patterns in my carreer; you can find solid, easy to follow examples of the following design patterns within this repository.

- [Chain of Responsibility](modules/personal/chain-of-responsibility)

<sub>*If you have any questions regarding a design pattern implementation, feel free to ask a question in the [discussions area](https://github.com/tacosontitan/sandbox/discussions/categories/q-a).*</sub>