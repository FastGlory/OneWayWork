using MauiApp1.ViewModel;

namespace MauiApp1.View;

public partial class PageAccueilStagiaire : ContentPage
{
	public PageAccueilStagiaire()
	{
		InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        string idSession = IdSessionServiceApp.Instance.GetSessionId();
        IdSessionLabel.Text = $"IdSession: {idSession}";
    }

    private void LogoutButton(object sender, EventArgs e)
    {
        IdSessionServiceApp.Instance.SetSessionId(null);
        IdSessionLabel.Text = $"IdSession: {IdSessionServiceApp.Instance.GetSessionId()}";
    }
}