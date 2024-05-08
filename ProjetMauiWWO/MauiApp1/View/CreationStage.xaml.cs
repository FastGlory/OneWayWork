using MauiApp1.Model;
using MauiApp1.Service;
using MauiApp1.ViewModel;

namespace MauiApp1.View
{
    public partial class CreationStage : ContentPage
    {
        private readonly LocalDbService _localDbService;
        private int idEntreprise ;

        public CreationStage(LocalDbService dbService)
        {
            _localDbService = dbService;
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            string idSession = IdSessionServiceApp.Instance.GetSessionId();
            IdSessionLabel.Text = $"IdSession: {idSession}";

            var entreprise = await _localDbService.GetEntrepriseBySessionId(idSession);
            if (entreprise != null)
            {
                idEntreprise = entreprise.Id_Entreprise;
            }
        }

        private async void EnregistrerStage(object sender, EventArgs e)
        {
            string Nom = NomStage.Text;
            string Description = DescriptionStage.Text;
            string SalaireText = SalaireStage.Text;

            try
            {
                if (string.IsNullOrWhiteSpace(Nom) || string.IsNullOrWhiteSpace(Description) || string.IsNullOrWhiteSpace(SalaireText))
                {
                    MessageLabel.Text = "Veuillez saisir tous les champs.";
                    return;
                }

                
                double? Salaire = double.Parse(SalaireText); // Trouvé en ligne StackOverFlow

                var stage = await _localDbService.GetStages();

                var VerificationStageDoublons = stage.FirstOrDefault(s => s.Nom_Stage == Nom);
                if (VerificationStageDoublons != null)
                {
                    MessageLabel.Text = "Stage déjà existant.";
                    return;
                }
                if (IdSessionServiceApp.Instance.GetSessionId() == null)
                {
                    MessageLabel.Text = "Vous n'avez pas les autorisations";
                }
                else
                {
                    
                    var ajoutStage = new Stage
                    {
                        Nom_Stage = Nom,
                        IsDispo_Stage = true,
                        Image_Stage = "neutral.png",
                        Salaire_Stage = Salaire,
                        Description_Stage = Description,
                        Id_Entreprise = idEntreprise
                    };

                    // Ajout dans la base de données avec la méthode CRUD
                    await _localDbService.AddStage(ajoutStage);

                    MessageLabel.Text = "Stage créé avec succès.";

                    // Naviguer vers une autre page si nécessaire
                }
            }
            catch (Exception ex)
            {
                MessageLabel.Text = $"Erreur lors de la création du stage : {ex.Message}";
            }
        }


        private async void AnnulationStage(object sender, EventArgs e)
        {
            MessageLabel.Text = "Test";
        }

    }
}