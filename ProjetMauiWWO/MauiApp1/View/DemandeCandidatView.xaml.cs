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
        string idSession = IdSessionServiceApp.Instance.GetSessionId();
        IdSessionLabel.Text = $"IdSession: {idSession}";
        string nomStagiaire = string.Empty;

    }

    private async void OnPageDraft(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CandidatureDraftView(_localDbService));
    }


    private async void SaveDraft_Clicked(object sender, EventArgs e)
    {
        string description = AddDescription.Text;
        string linkCandidat = AddLink.Text;
        string idSession = IdSessionServiceApp.Instance.GetSessionId();
        string nomStagiaire = string.Empty;


        try
        {
            if (string.IsNullOrWhiteSpace(description) || string.IsNullOrWhiteSpace(linkCandidat))
            {
                MessageLabel.Text = "Veuillez saisir tous les champs.";  // si il ne met pas tout les champs dans le forms 
                return;

            }

            if (string.IsNullOrWhiteSpace(idSession))
            {
                MessageLabel.Text = "Besoin de se connecter.";
                return;

            }

            nomStagiaire = await _localDbService.GetStagiaireNameAsync(idSession);


            var candidature = new Candidature  // on crée une instance de la camdidaturre et on la stock dans la database
            {
                Description_Candidature = description,
                Lien_Candidature = linkCandidat,
                IdSession = idSession,
                Is_Draft = true,
                Date_Candidature = DateTime.Now,
                nom_Stagiaire = nomStagiaire,
                

            };



            await _localDbService.SaveCandidature(candidature);
            MessageLabel.Text = "Brouillon Enregistré avec succès.";



        }


        catch (Exception ex)
        {

            MessageLabel.Text = $"Erreur inconnu: {ex.Message}";
        }


    }

    private async void SubmitCandidature_Clicked(object sender, EventArgs e)
    {
        string description = AddDescription.Text;
        string linkCandidat = AddLink.Text;
        string idSession = IdSessionServiceApp.Instance.GetSessionId();
        string nomStagiaire = string.Empty;


        try
        {
            if (string.IsNullOrWhiteSpace(description) || string.IsNullOrWhiteSpace(linkCandidat))
            {
                MessageLabel.Text = "Veuillez saisir tous les champs.";  // si il ne met pas tout les champs dans le forms 
                return;

            }

            if (string.IsNullOrWhiteSpace(idSession))
            {
                MessageLabel.Text = "Besoin de se connecter.";
                return;

            }

            nomStagiaire = await _localDbService.GetStagiaireNameAsync(idSession);


            var candidature = new Candidature  // on crée une instance de la camdidaturre et on la stock dans la database
            {
                Description_Candidature = description,
                Lien_Candidature = linkCandidat,
                IdSession = idSession,
                Is_Draft = false,
                Date_Candidature = DateTime.Now,
                nom_Stagiaire = nomStagiaire,


            };



            await _localDbService.SubmitCandidature(candidature);
            MessageLabel.Text = "Candidature envoyé avec succès.";



        }


        catch (Exception ex)
        {

            MessageLabel.Text = $"Erreur inconnu: {ex.Message}";
        }


    }




}




