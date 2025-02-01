using Newtonsoft.Json.Linq;

namespace WeatherApp
{
    public class WeatherApiException : Exception
    {
        public WeatherApiException(string message) : base(message) { }
    }
    
    public class Program
    {
        private static readonly HttpClient HttpClient = new();
        private static string _apiKey = string.Empty;
        private const string BaseApiUrl = "https://api.openweathermap.org/data/2.5/weather";

        public static async Task Main(string[] args)
        {
            try
            {
                await RunWeatherApp();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fatal error: {ex.Message}");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }

        private static async Task RunWeatherApp()
        {
            DisplayWelcomeMessage();
            _apiKey = GetApiKey();

            while (true)
            {
                string location = GetLocationInput();
                
                if (location.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

                await FetchAndDisplayWeather(location);
                
                if (!PromptToContinue())
                {
                    break;
                }
            }
        }

        private static void DisplayWelcomeMessage()
        {
            Console.WriteLine("╔═══════════════════════╗");
            Console.WriteLine("║    Weather App        ║");
            Console.WriteLine("╚═══════════════════════╝");
        }

        private static string GetApiKey()
        {
            while (true)
            {
                Console.Write("\nPlease enter your OpenWeather API Key: ");
                string input = Console.ReadLine()?.Trim() ?? string.Empty;

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Error: API key cannot be empty.");
                    continue;
                }

                return input;
            }
        }

        private static string GetLocationInput()
        {
            while (true)
            {
                Console.Write("\nEnter a location (or 'exit' to quit): ");
                string input = Console.ReadLine()?.Trim() ?? string.Empty;

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Error: Location cannot be empty.");
                    continue;
                }

                return input;
            }
        }

        private static async Task FetchAndDisplayWeather(string location)
        {
            try
            {
                var weatherData = await FetchWeatherData(location);
                DisplayWeatherData(weatherData);
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"\nError fetching weather data: {ex.Message}");
                Console.WriteLine("Please check your internet connection and location spelling.");
            }
            catch (WeatherApiException ex)
            {
                Console.WriteLine($"\nWeather API Error: {ex.Message}");
                Console.WriteLine("Please verify your API key and location.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nUnexpected error: {ex.Message}");
            }
        }

        private static async Task<JObject> FetchWeatherData(string location)
        {
            string url = $"{BaseApiUrl}?q={Uri.EscapeDataString(location)}&appid={_apiKey}&units=metric";
            
            string response = await HttpClient.GetStringAsync(url);
            var weatherData = JObject.Parse(response);
            
            if (weatherData["cod"]?.ToString() != "200")
            {
                throw new WeatherApiException(weatherData["message"]?.ToString() ?? "Unknown API error");
            }
        
            return weatherData;
        }

        private static void DisplayWeatherData(JObject weatherData)
        {
            string cityName = weatherData["name"]?.ToString() ?? "Unknown Location";
            double temperature = weatherData["main"]?["temp"]?.Value<double>() ?? 0;
            string weatherDescription = weatherData["weather"]?[0]?["description"]?.ToString() ?? "No description available";
            double feelsLike = weatherData["main"]?["feels_like"]?.Value<double>() ?? 0;
            int humidity = weatherData["main"]?["humidity"]?.Value<int>() ?? 0;
            double windSpeed = weatherData["wind"]?["speed"]?.Value<double>() ?? 0;

            Console.WriteLine("\n╔════ Weather Report ════╗");
            Console.WriteLine($"  Location: {cityName}");
            Console.WriteLine($"  Temperature: {temperature:F1}°C");
            Console.WriteLine($"  Feels like: {feelsLike:F1}°C");
            Console.WriteLine($"  Condition: {weatherDescription}");
            Console.WriteLine($"  Humidity: {humidity}%");
            Console.WriteLine($"  Wind Speed: {windSpeed:F1} m/s");
            Console.WriteLine("╚═════════════════════════╝");
        }

        private static bool PromptToContinue()
        {
            while (true)
            {
                Console.Write("\nCheck another location? (Y/N): ");
                string input = Console.ReadLine()?.Trim().ToUpper() ?? "N";

                if (input is "Y" or "N")
                {
                    return input == "Y";
                }

                Console.WriteLine("Please enter Y or N.");
            }
        }
    }

}
