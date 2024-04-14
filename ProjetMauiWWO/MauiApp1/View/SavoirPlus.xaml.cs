using Microsoft.Maui.Controls;

namespace MauiApp1.View
{
    public partial class SavoirPlus : ContentPage
    {
        public SavoirPlus()
        {
            InitializeComponent();
        }

        private void OnButtonClicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (button.Text == "Interface conviviale")
            {
                Navigation.PushAsync(new PageInterfaceConviviale());
            }
            else if (button.Text == "La sécurité")
            {
                Navigation.PushAsync(new PageSecurite());
            }
            else if (button.Text == "Gestion complète")
            {
                Navigation.PushAsync(new PageGestionComplete());
            }
        }
    }
}
