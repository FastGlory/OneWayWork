
using System.Runtime.CompilerServices;

namespace MauiApp1.View;

public partial class InscriptionView : ContentPage
{
	public InscriptionView()
	{
		InitializeComponent();

       
    }

	private async void OnConnexionTapped(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new ConnexionView());
	}





}