namespace MauiApp1.View;

public partial class PageAccueil : ContentPage
{
	public PageAccueil()
	{
		InitializeComponent();
	}

    private async void OnButtonClicked(object sender, EventArgs e)
    {
        // Naviguer vers une nouvelle page
        await Navigation.PushAsync(new SavoirPlus());
    }
}