namespace MauiApp1.View;

public partial class CreationPageStage : ContentPage
{
	public CreationPageStage()
	{
		InitializeComponent();
	}
    private async void OnButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CreationDeStage());
    }
}