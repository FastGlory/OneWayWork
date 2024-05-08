using MauiApp1.ViewModel;

namespace MauiApp1.View;

public partial class PageAccueilAdmin : ContentPage
{
	public PageAccueilAdmin()
	{
		InitializeComponent();
        string idSession = IdSessionServiceApp.Instance.GetSessionId();
        IdSessionLabel.Text = $"IdSession: {idSession}";
    }

    private void Button_Clicked(object sender, EventArgs e)
    {

    }

    private void LogoutButton(object sender, EventArgs e)
    {
        IdSessionServiceApp.Instance.SetSessionId(null);
    }

}