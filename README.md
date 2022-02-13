# 🌮 Taco's Sandbox 📦
Do you ever get tired of creating console app after console app just to test out ideas or concepts? Well, so do I! This sandbox utilizes reflection to enable a modularized approach to testing new ideas and concepts.

[![Example of runtime execution.](images/screenshot.jpg)](images/screenshot.jpg)

Welcome to my sandbox, wanna play?

## 👋 Hello World

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

## 🎨 Design Patterns
I've implemented plenty of design patterns in my carreer, but the one thing that always bothered me was a lack of demonstrations that related to junior or intermediate knowledge levels. As a result, I've intentionally implemented several design patterns with entry level use-cases.

- [Chain of Responsibility](../../tree/main/modules/personal/design-patterns/chain-of-responsibility) - Fizz Buzz
- [Mediator](../../tree/main/modules/personal/design-patterns/mediator) - Guessing Game

<sub>*If you have any questions regarding a design pattern implementation, feel free to ask a question in the [discussions area](https://github.com/tacosontitan/sandbox/discussions/categories/q-a).*</sub>

## 🔥 Interesting Implementations
Every now and then I stumble across a topic or problem that piques my interest to an extreme degree. When that happens, I like to break it down and try to understand it so that I can share it with others in an intelligent manner.

- [Hamming Distance with Bitwise Operations](modules/personal//HammingDistance.cs)