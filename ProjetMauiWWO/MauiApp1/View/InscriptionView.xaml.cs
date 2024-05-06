

using MauiApp1.Model;
using MauiApp1.Service;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

namespace MauiApp1.View;

public partial class InscriptionView : ContentPage
{
    private readonly LocalDbService _localDbService;
    
    public InscriptionView(LocalDbService dbService)
    {
        _localDbService = dbService;
     
        InitializeComponent();
    }

    private async void OnConnexionTapped(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ConnexionView(_localDbService));
    }

    private async void OnConnexionEntreprise(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new InscriptionViewEntreprise(_localDbService));
    }

    private async void CreactionClick(object sender, EventArgs e)
    {
        string username = AddNom.Text;
        string prenom = AddPrenom.Text;
        string password = AddPassword.Text;
        string email = AddEmail.Text;

        try
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(prenom) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                MessageLabel.Text = "Veuillez saisir tous les champs.";
                return;
            }

            var stagiaires = await _localDbService.GetStagiaires();

            var authenticatedStagiaire = stagiaires.FirstOrDefault(s => s.email_Stagiaire == email);
            if (authenticatedStagiaire != null)
            {
                MessageLabel.Text = "Compte déjà existant.";
                return;
            }
            else
            {
                // Ajout des informations du stagiaire dnas la database
                var nouveauStagiaire = new Stagiaire
                {
                    nom_Stagiaire = username,
                    prenom_Stagiaire = prenom,
                    email_Stagiaire = email,
                    MotDePasse_Stagiaire = password,
                    image_Stagiaire = "neutral.png"
                };

                // Ajout dans la database avec la méthode crud
                await _localDbService.AddStagiaire(nouveauStagiaire);

                MessageLabel.Text = "Compte créé avec succès.";

                // aller vers une autre page
            }
        }
        catch (Exception ex)
        {
            
            MessageLabel.Text = $"Erreur lors de la création du compte : {ex.Message}";
        }
    }


}

