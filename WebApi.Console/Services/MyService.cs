namespace WebApi.Console.Services;

internal class MyService : IMyService
{
    public string GetValue()
    {
        return "Value From DI Container";
    }
}