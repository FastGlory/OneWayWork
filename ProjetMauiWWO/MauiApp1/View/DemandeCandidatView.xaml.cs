using MauiApp1.Model;
using MauiApp1.Service;
using MauiApp1.ViewModel;

namespace MauiApp1.View;

public partial class DemandeCandidatView : ContentPage
{

    private readonly LocalDbService _localDbService;
    public DemandeCandidatView(LocalDbService localDbService)
    {



        InitializeComponent();
        _localDbService = localDbService;
        string idSession = IdSessionServiceApp.Instance.GetSessionId(); // on prend le session idd pour enregistrer le brouillon d�pendant du compte de la personne
        
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


            var candidature = new Candidature  // on cr�e une instance de la camdidaturre et on la stock dans la database
            {
                Description_Candidature = description,
                Lien_Candidature = linkCandidat,
                IdSession = idSession,
                Is_Draft = true,
               
            };

            await _localDbService.SaveCandidature(candidature);
            MessageLabel.Text = "Brouillon Enregistr� avec succ�s.";

        }
        catch (InvalidOperationException ex)  // au cas ou
        {

            MessageLabel.Text = $"Erreur lors de la cr�ation du brouillon: {ex.Message}";
        }

        catch (Exception ex)
        {

            MessageLabel.Text = $"Erreur inconnu: {ex.Message}";
        }


    }




}




