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

                // Ici on va récupérer la DB avec la méthode CRUD
                var stagiaires = await _localDbService.GetStagiaires();
                var admin = await _localDbService.GetAdministrateurs();

                // Ici opn va vérifier si jamais sa correspond our pas 
                var authenticatedStagiaire = stagiaires.FirstOrDefault(s => s.nom_Stagiaire == username && s.MotDePasse_Stagiaire == password);
                var authentifcatedAdmin = admin.FirstOrDefault(s => s.Nom_Administrateur == username && s.MotDePasse_Administrateur == password);

                if (authenticatedStagiaire != null)
                {

                    // manière de récupérer et d'utilisé le set. qui va mettre le id dans l'instance 
                    IdSessionServiceApp.Instance.SetSessionId(authenticatedStagiaire.IdSession);

                    // manière qu'on peut récupèrer l'idSession
                    string IdSession = IdSessionServiceApp.Instance.GetSessionId();


                    // Message réussite
                    MessageLabel.Text = $"Connexion réussie. ID de session : {IdSession}";
                    IdSessionLabel.Text = $"IdSession: {IdSession}";

                    // On va mettre un déplacement de navigation ici 
                }
                else
                {
                    // Message erreur coté 
                    MessageLabel.Text = "Nom d'utilisateur ou mot de passe incorrect.";
                }

                if(authentifcatedAdmin != null) {
                    IdSessionServiceApp.Instance.SetSessionId(authentifcatedAdmin.IdSession);

                    // manière qu'on peut récupèrer l'idSession
                    string IdSession = IdSessionServiceApp.Instance.GetSessionId();

                    // Message réussite
                    MessageLabel.Text = $"Connexion réussie. ID de session : {IdSession}";
                    IdSessionLabel.Text = $"IdSession: {IdSession}";
                } else
                {
                    MessageLabel.Text = "Nom d'utilisateur ou mot de passe incorrect.";
                }
            }
            catch (Exception ex)
            {
                // log erreur (trouver sur le net)
                MessageLabel.Text = $"Erreur d'authentification : {ex.Message}";
            }
        }
    }
}