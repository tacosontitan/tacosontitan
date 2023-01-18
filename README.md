# ⚠️ Stability Warning
*This project is getting a major facelift and as such should not be considered as stable while this message is present.*

# 🌮 Taco's Sandbox 📦
Do you ever get tired of creating console app after console app just to test out ideas or concepts? Well, so do I! This sandbox utilizes reflection to enable a modularized approach to testing new ideas and concepts.

[![Example of runtime execution.](images/screenshot.jpg)](images/screenshot.jpg)

Welcome to my sandbox, wanna play?

## 👋 Hello World

```cs
using Mauve;

namespace Sandbox.Modules;
/// <summary>
/// Represents a basic module that says hello to the world.
/// </summary>
[Alias("hello")]
[Discoverable("Hello World", "Says hello to the world.")]
internal sealed class HelloWorld : Module
{
    /// <summary>
    /// Creates a new instance of the <see cref="HelloWorld" /> module.
    /// </summary>
    public HelloWorld() :
        base("Hello World")
    { }
    protected override async Task Work() =>
        await Write("Hello world!");
}
```

Then simply use `dotnet run` to start the sandbox and enter the key for your module when prompted:

> If you need help at any point, use the `help` command.<br/>
> To exit the application, use the `exit` command.<br/>
> \> hello<br/>
> Hello World: Hello world!

## 🔥 Interesting Implementations
Every now and then I stumble across a topic or problem that piques my interest to an extreme degree. When that happens, I like to break it down and try to understand it so that I can share it with others in an intelligent manner.

### Hamming Distance
The [Hamming distance](https://en.wikipedia.org/wiki/Hamming_distance) is the number of differences between two string-type inputs; or better explained by the aforelinked Wikipedia article:

> *In information theory, the Hamming distance between two strings of equal length is the number of positions at which the corresponding symbols are different.* <sub>[1]</sub>

For example:

> aaabaaa | abababa

In the example above there are *two* differences between the supplied inputs, so therefore the Hamming distance is 2. However, the use-case I found it through was actually working with integers instead of strings, yet its implementation was using string comparison which seemed rather, over the top. I was pretty sure it could be done with bitwise operations, and that led to an implementation [here](modules/personal//HammingDistance.cs) in my sandbox.

## ✒️ Citations
1. Wikipedia contributors. (2021, November 9). Hamming distance. In Wikipedia, The Free Encyclopedia. Retrieved 04:51, February 13, 2022, from https://en.wikipedia.org/w/index.php?title=Hamming_distance&oldid=1054348646
