using Newtonsoft.Json;

namespace Sandbox.QuickTests;

public sealed class ParameterizedConstructorTests
{
    [Fact]
    public void JsonConvert_ParameterizedConstructor_DeserializesCorrectly()
    {
        var sample = new ParameterizedConstructorTestType(foo: 32);
        var json = JsonConvert.SerializeObject(sample);
        var actualResult = JsonConvert.DeserializeObject<ParameterizedConstructorTestType>(json);
        Assert.NotNull(actualResult);
        Assert.Equal(32, actualResult.Foo);
    }

    private sealed class ParameterizedConstructorTestType(int foo)
    {
        public int Foo { get; set; } = foo;
    }
}
