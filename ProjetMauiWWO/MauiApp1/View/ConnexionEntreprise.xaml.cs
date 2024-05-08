using MauiApp1.Service;
using MauiApp1.ViewModel;
using System.Diagnostics;

namespace MauiApp1.View;

public partial class ConnexionEntreprise : ContentPage
{
    private readonly LocalDbService _localDbService;
    public ConnexionEntreprise(LocalDbService dbService)
	{
        _localDbService = dbService;
        InitializeComponent();
	}

    private async void OnConnexionTapped(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new InscriptionViewEntreprise(_localDbService));
    }

    private async void ConnexionAsync(object sender, EventArgs e)
    {
        string username = AddPrenom.Text;
        string password = MotDePasse.Text;
        try
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageLabel.Text = "Veuillez saisir un nom d'utilisateur et un mot de passe.";
                return;
            }

            var entreprise = await _localDbService.GetEntreprises();
           

            var AuthentificationEntentreprise = entreprise.FirstOrDefault(s => s.Nom_Entreprise == username && s.MotDePasse_Entreprise == password);
          

            if (AuthentificationEntentreprise != null)
            {
                ReussiteAuthentification(AuthentificationEntentreprise.IdSession);
                await Navigation.PushAsync(new PageAccueilEntreprise());

            }
            else
            {
                MessageLabel.Text = "Nom d'utilisateur ou mot de passe incorrect.";
            }
        }
            catch (Exception ex)
            {
                Debug.WriteLine($"Erreur d'authentification : {ex}");
                MessageLabel.Text = "Erreur d'authentification. Veuillez réessayer.";
            }
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        string idSession = IdSessionServiceApp.Instance.GetSessionId();
        IdSessionLabel.Text = $"IdSession: {idSession}";
    }
    private void ReussiteAuthentification(string sessionId)
    {
        IdSessionServiceApp.Instance.SetSessionId(sessionId);
        string IdSession = IdSessionServiceApp.Instance.GetSessionId();
        MessageLabel.Text = $"Connexion réussie. ID de session : {IdSession}";
        IdSessionLabel.Text = $"IdSession: {IdSession}";
    }
}
    


