namespace Sandbox;
internal static class ApplicationBuilderExtensions {
    public static IConsoleDelegateBuilder UseFizzBuzzWriter(this IConsoleDelegateBuilder app) {
        return app.Use(async (value, next) => {
            if (value is int iValue && iValue % 3 == 0 && iValue % 5 == 0)
                Console.WriteLine("Fizz Buzz.");
            else
                await next?.Invoke(value);
        });
    }
    public static IConsoleDelegateBuilder UseFizzWriter(this IConsoleDelegateBuilder app) {
        return app.Use(async (value, next) => {
            if (value is int iValue && iValue % 3 == 0)
                Console.WriteLine("Fizz.");
            else
                await next?.Invoke(value);
        });
    }
    public static IConsoleDelegateBuilder UseBuzzWriter(this IConsoleDelegateBuilder app) {
        return app.Use(async (value, next) => {
            if (value is int iValue && iValue % 5 == 0)
                Console.WriteLine("Buzz.");
            else
                await next?.Invoke(value);
        });
    }
    public static IConsoleDelegateBuilder UseWriter(this IConsoleDelegateBuilder app) {
        return app.Use(async (value, next) => {
            Console.WriteLine(value);
            await next?.Invoke(value);
        });
    }
}