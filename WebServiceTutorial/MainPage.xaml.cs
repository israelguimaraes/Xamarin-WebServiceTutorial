using System;
using System.ComponentModel;
using WebServiceTutorial.Service;
using Xamarin.Forms;

namespace WebServiceTutorial
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private readonly RestService _restService;

        public MainPage()
        {
            InitializeComponent();
            _restService = new RestService();
        }

        private async void OnButtonClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cityEntry.Text))
                return;

            var uri = GenerateRequestUri(Constants.OpenWeatherMapEndpoint);
            var weatherData = await _restService.GetWeatherDataAsync(uri);
            BindingContext = weatherData;
        }

        private string GenerateRequestUri(string endpoint)
        {
            var requestUri = endpoint;
            requestUri += $"?q={cityEntry.Text}";
            requestUri += "&units=imperial";
            requestUri += $"&APPID={Constants.OpenWeatherMapAPIKey}";
            return requestUri;
        }
    }
}
