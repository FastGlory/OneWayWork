

namespace MauiApp1.View;

public partial class ConnexionView : ContentPage
{
	public ConnexionView()
	{
        InitializeComponent();

        private async void OnInscriptionTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new InscriptionView());
        }

    }

    
}