namespace MauiApp1.View;

public partial class CreationDeStage : ContentPage
{
	public CreationDeStage()
	{
		InitializeComponent();
	}
    private async void OnButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ModifierStage());
    }
}