# AcmeCommChecker
This handy dandy little SPA uses the OpenWeather 5 day / 3 hour API to give you a 5 day calendar for displaying the optimal communication method for contacting your customers based on the following proven criteria:
* The best time to engage a customer via a text message is when it is sunny and warmer than 75
degrees Fahrenheit.
* The best time to engage a customer via email is when it is between 55 and 75 degrees
Fahrenheit.
* The best time to engage a customer via a phone call is when it is less than 55 degrees or when it
is raining.

## Installation

```bash
git clone https://github.com/djuba/AcmeCommChecker.git
cd AcmeCommChecker/ClientApp
npm install
```
Note: you will need to add your own personal OpenWeather API key (https://openweathermap.org/appid) to the OpenWeatherApiKey setting in the appsettings.json configuration file.
