using MauiApp1.Model;
using MauiApp1.Service;
using MauiApp1.ViewModel;


namespace MauiApp1.View;

public partial class DemandeCandidatView : ContentPage
{

    private readonly LocalDbService _localDbService;
    public object ReadOnlyFilePicker { get; private set; }
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


    private async void UploadDocBtn(object sender, EventArgs e)
    {
        var typeOfdoc = new FilePickerFileType(    // On veut que le seul type de fichier que l'utilisateur prennent c'est pdf et word pour leur docs, donc on utilise un dictionnaire pour specifier quel types de fichers le user doit prendre

            new Dictionary<DevicePlatform, IEnumerable<string>>
            {
                {DevicePlatform.WinUI, new[] {".doc", ".docx", ".pdf"} },
            });


        var options = new PickOptions // Ici on va definir les types de fichiers du dictionnaire qu'on a cree precedemment 
        {
            FileTypes = typeOfdoc
        };


        var pickedDoc = await FilePicker.Default.PickAsync(options); // dans ce cas, on va pouvoir pick le fichier et avec argument le type de fichiers qu'on veut 
        if (pickedDoc is null)
        {
            return;
        }

        //if (!(pickedDoc.FileName.EndsWith(".doc", StringComparison.OrdinalIgnoreCase)
        //    || pickedDoc.FileName.EndsWith(".docx", StringComparison.OrdinalIgnoreCase)
        //    || pickedDoc.FileName.EndsWith(".pdf", StringComparison.OrdinalIgnoreCase)))// si le user choisi un mauvais format , il y'a un message d'avertissment
        //{
        //    await DisplayAlert("Erreur", "Veuiler choisir un document de format pdf our word", "Ok");
        //    return;
        //}

        using var stream = await pickedDoc.OpenReadAsync(); // lire le doc choisis 


        byte[] docData;

        using (MemoryStream ms = new MemoryStream())
        {
            await stream.CopyToAsync(ms);
            docData = ms.ToArray();
        }


    }





}




