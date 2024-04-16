using System.Security.Cryptography.X509Certificates;

namespace MauiApp1.View;

public partial class DemandeCandidatView : ContentPage
{
    public DemandeCandidatView()
    {
        InitializeComponent();
    }

    public object ReadOnlyFilePicker { get; private set; }

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

        if (!(pickedDoc.FileName.EndsWith(".doc", StringComparison.OrdinalIgnoreCase)
            || pickedDoc.FileName.EndsWith(".docx", StringComparison.OrdinalIgnoreCase)
            || pickedDoc.FileName.EndsWith(".pdf", StringComparison.OrdinalIgnoreCase)))// si le user choisi un mauvais format , il y'a un message d'avertissment
        {
            await DisplayAlert("Erreur", "Veuiler choisir un document de format pdf our word", "Ok");
            return;
        }


        using var stream = await pickedDoc.OpenReadAsync(); // lire le doc choisis 
        

    }
            

}