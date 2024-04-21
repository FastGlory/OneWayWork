using MauiApp1.Service;
using Microsoft.Maui.Controls;
using System;
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

                // Ici on va r�cup�rer la DB avec la m�thode CRUD
                var stagiaires = await _localDbService.GetStagiaires();

                // Ici opn va v�rifier si jamais sa correspond our pas 
                var authenticatedStagiaire = stagiaires.FirstOrDefault(s => s.nom_Stagiaire == username && s.MotDePasse_Stagiaire == password);

                if (authenticatedStagiaire != null)
                {
                    // Si l'authentification r�ussit, affichez un message de succ�s
                    MessageLabel.Text = "Connexion r�ussie.";

                    // Vous pouvez �galement naviguer vers une autre page ici si n�cessaire
                }
                else
                {
                    // Si l'authentification �choue, affichez un message d'erreur
                    MessageLabel.Text = "Nom d'utilisateur ou mot de passe incorrect.";
                }
            }
            catch (Exception ex)
            {
                // En cas d'erreur, affichez un message d'erreur
                MessageLabel.Text = $"Erreur d'authentification : {ex.Message}";
            }
        }
    }
}
