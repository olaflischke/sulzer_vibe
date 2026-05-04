namespace CopilotPlayground;

public class DemoClass
{
    // Eine Funktion, die Celsius in Fahrenheit umrechnet
    public double CelsiusToFahrenheit(double celsius)
    {
        return (celsius * 9 / 5) + 32;
    }

    // Asynchrone Schwester der CelsiusToFahrenheit Funktion
    public async Task<double> CelsiusToFahrenheitAsync(double celsius)
    {
        return await Task.Run(() => (celsius * 9 / 5) + 32);
    }

    // Eine Funktion, die Fahrenheit in Celsius umrechnet
    public double FahrenheitToCelsius(double fahrenheit)
    {
        return (fahrenheit - 32) * 5 / 9;
    }

    // Asynchrone Schwester der FahrenheitToCelsius Funktion mit ValueTask
    public ValueTask<double> FahrenheitToCelsiusAsync(double fahrenheit)
    {
        return ValueTask.FromResult((fahrenheit - 32) * 5 / 9);
    }
}
