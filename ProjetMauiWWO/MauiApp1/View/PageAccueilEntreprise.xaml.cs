using MauiApp1.ViewModel;

namespace MauiApp1.View;

public partial class PageAccueilEntreprise : ContentPage
{
	public PageAccueilEntreprise()
	{
		InitializeComponent();
        string idSession = IdSessionServiceApp.Instance.GetSessionId();
        IdSessionLabel.Text = $"IdSession: {idSession}";
    }

    private void LogoutButton(object sender, EventArgs e)
    {
        IdSessionServiceApp.Instance.SetSessionId(null);
    }
}