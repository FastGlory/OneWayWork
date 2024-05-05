using MauiApp1.Model;
using MauiApp1.Service;
using MauiApp1.ViewModel;
using System.Net.Mime;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.CompilerServices;

namespace MauiApp1.View;

public partial class DemandeCandidatView : ContentPage
{

    private readonly LocalDbService _localDbService;
    
    public DemandeCandidatView(LocalDbService localDbService)
    {



        _localDbService = localDbService;
        InitializeComponent();
    }

    private async void SaveDraft_Clicked(object sender, EventArgs e) 
    {
        string description = AddDescription.Text;
        string linkCandidat = AddLink.Text;
        string idSession = IdSessionServiceApp.Instance.GetSessionId();


        try
        {
            if (string.IsNullOrWhiteSpace(description) || string.IsNullOrWhiteSpace(linkCandidat))
            {
                MessageLabel.Text = "Veuillez saisir tous les champs.";  // si il ne met pas tout les champs dans le forms 
                return;

            }

          
                var candidature = new Candidature  // on crée une instance de la camdidaturre et on la stock dans la database
                {
                    Description_Candidature = description,
                    Lien_Candidature = linkCandidat,
                    IdSession = idSession,
                    Is_Draft = true,

                };

            

            await _localDbService.SaveCandidature(candidature);
            MessageLabel.Text = "Brouillon Enregistré avec succès.";

            

        }


        catch (Exception ex)
        {

            MessageLabel.Text = $"Erreur inconnu: {ex.Message}";
        }


    }




}




