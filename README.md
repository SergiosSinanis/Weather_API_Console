# Weather_API_Console
A C# console application that provides real-time weather information using the OpenWeatherMap API. This application allows users to check current weather conditions for any location worldwide.

## Features:

Real-time weather data
Temperature in Celsius
Weather conditions
Location-based search
Error handling
User-friendly interface
Wind speed information
Humidity data
"Feels like" temperature

## Requirements:

.NET 6.0 or higher
Visual Studio 2022 or compatible IDE
OpenWeatherMap API key
Active internet connection

Install required NuGet packages:
Newtonsoft.Json

Build the solution,
Get your API key from OpenWeatherMap (https://openweathermap.org/api),
Run the application

## How to Use:

Start the application
Enter your OpenWeatherMap API key
Type a location name (city, country)
View the weather information
Choose to check another location or exit

Example Output:
Location: London, UK
Temperature: 15.2°C
Feels like: 14.8°C
Condition: Light rain
Humidity: 76%
Wind Speed: 4.1 m/s
Error Handling:

Invalid API key detection
Location not found handling
Network connection errors
API response validation
Input validation

## API Usage Notes:

Free API tier limited to 60 calls per minute
Location names should be clear and specific
Some locations might need country code (e.g., "London,UK")
API responses are in metric units

## Contributing:

Fork the repository
Create a feature branch
Make your changes
Submit a pull request

License:
Copyright [Year] [Your Name]
Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at
Copyhttp://www.apache.org/licenses/LICENSE-2.0
Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.

## Security Notes:

Never commit your API key to the repository
Use environment variables or secure configuration for API keys
Be mindful of API rate limits
Consider implementing API key rotation for production use

## Contact:
sergiosinanis@gmail.com

## Support:
For bugs, feature requests, or questions, please open an issue in the GitHub repository.
Version History:
1.0.0 - Initial release

Basic weather information
Location-based search
Error handling
User interface
API integration

## Future Improvements:

Multiple day forecast
Weather alerts
Location saving
Temperature unit conversion
Graphical weather display
Multiple location comparison
Offline mode with caching
Detailed weather reports
Location autocomplete
Historical weather data

## Dependencies:

Newtonsoft.Json - For parsing JSON API responses
System.Net.Http - For making API requests

## Acknowledgments:

OpenWeatherMap for providing the weather API
All contributors and users of this application
Newtonsoft.Json library maintainers

Note: Remember to keep your API key secure and never share it publicly.
