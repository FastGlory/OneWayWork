namespace MauiApp1.View;

public partial class PageAccueil : ContentPage
{
	public PageAccueil()
	{
		InitializeComponent();
	}

    private async void OnButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SavoirPlus());
    }
}