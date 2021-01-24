using Plugin.Geolocator;
using Plugin.ExternalMaps;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Test_Location2
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        double latitude = 0;
        double longitude = 0;

        private async void btnGeolocalizacao_Clicked(object sender, EventArgs e)
        {
            lblGeolocalizacao.Text = "Obtendo a geolocalização....\n";

            try
            {
                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 120;

                var position = await locator.GetPositionAsync(TimeSpan.FromSeconds (120), null, true);

                lblGeolocalizacao.Text += "Status: " + position.Timestamp + "\n";
                lblGeolocalizacao.Text += "Latitude: " + position.Latitude + "\n";
                lblGeolocalizacao.Text += "Longitude: " + position.Longitude;

                latitude = position.Latitude;
                longitude = position.Longitude;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro : ", ex.Message, "OK");
            }
        }

        private async void btnMostrarPosicaoNoMapa_Clicked(object sender, EventArgs e)
        {
            try
            {

                var success = await CrossExternalMaps.Current.
                NavigateTo("Local", latitude, longitude);

            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro : ", ex.Message, "OK");
            }
        }
    }
}
