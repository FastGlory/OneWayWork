using MauiApp1.Service;
using MauiApp1.ViewModel;
using Microsoft.Maui.Controls;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MauiApp1.View
{
    public partial class ConnexionView : ContentPage
    {
        private readonly LocalDbService _localDbService;

        public ConnexionView(LocalDbService localDbService)
        {
            InitializeComponent();
            _localDbService = localDbService;
        }

        private async void OnInscriptionTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new InscriptionView(_localDbService));
        }

        private async void AuthentificationClick(object sender, EventArgs e)
        {
            string username = NomUtilisateur.Text;
            string password = MotDePasseUtilisateur.Text;

            try
            {
                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                {
                    MessageLabel.Text = "Veuillez saisir un nom d'utilisateur et un mot de passe.";
                    return;
                }

                var stagiaires = await _localDbService.GetStagiaires();
                var admin = await _localDbService.GetAdministrateurs();

                var authenticatedStagiaire = stagiaires.FirstOrDefault(s => s.nom_Stagiaire == username && s.MotDePasse_Stagiaire == password);
                var authentifcatedAdmin = admin.FirstOrDefault(s => s.Nom_Administrateur == username && s.MotDePasse_Administrateur == password);

                if (authenticatedStagiaire != null)
                {
                    ReussiteAuthentification(authenticatedStagiaire.IdSession);
                }
                else if (authentifcatedAdmin != null)
                {
                    ReussiteAuthentification(authentifcatedAdmin.IdSession);
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
}
