using Microsoft.Maui.Controls;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using MauiApp1.Model;
using MauiApp1.Service;
using System.Diagnostics;
using MauiApp1.ViewModel;

namespace MauiApp1.View
{
    public partial class Stage_Page : ContentPage
    {
        private readonly LocalDbService _localDbService;
        private ObservableCollection<Stage> filteredStages;

        public ObservableCollection<Stage> Stages { get; set; }

        public Stage_Page(LocalDbService dbService)
        {
            
            InitializeComponent();
            string IdSession = IdSessionServiceApp.Instance.GetSessionId();
            IdSessionLabel.Text = $"IdSession: {IdSession}";
            _localDbService = dbService;
            Stages = new ObservableCollection<Stage>();
            filteredStages = new ObservableCollection<Stage>();
            BindingContext = this;
            listView.ItemsSource = filteredStages;
           
        }


        private async void OnPageCandidat(object sender, EventArgs e)
        {   
           
            await Navigation.PushAsync(new DemandeCandidatView(_localDbService));
        }

   
        protected override async void OnAppearing()
        {
            
            // Appel de la méthode OnAppearing() de la classe parente (ContentPage)
            base.OnAppearing();
            string idSession = IdSessionServiceApp.Instance.GetSessionId();
            IdSessionLabel.Text = $"IdSession: {idSession}";
            await LoadStagesAsync(); // La on va simplement charger
        } // Permet de montrer les informations des stages à l'utilisateur et le base. c'est une manière de faire référence directement

        private async Task LoadStagesAsync()
        {
            try
            {
                Debug.WriteLine("Chargement des stage..."); // Inutile mais stylé
                var stages = await _localDbService.GetStages();
                Debug.WriteLine($"Nombre de stage AVANT insération: {stages.Count}");

                Stages.Clear();

                foreach (var stage in stages)
                {
                    stage.Entreprise = await _localDbService.GetEntrepriseById(stage.Id_Entreprise);
                    Stages.Add(stage);
                }

                Debug.WriteLine($"Nombre de stage APRÈS insération: {Stages.Count}");

                FilterStages(filterText.Text);

                Debug.WriteLine("Stages loaded successfully.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error loading stages: {ex.Message}");
                await DisplayAlert("Error", $"Unable to retrieve stages: {ex.Message}", "OK"); // On affiche directement le message 
            }
        }


        private async void OnDeleteAllStageButtonClicked(object sender, EventArgs e)
        {

          

                try
                {
                    await _localDbService.DeleteAllStages();
                    await LoadStagesAsync();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error deleting stages: {ex.Message}");
                    await DisplayAlert("Error", $"Error deleting stages: {ex.Message}", "OK");
                }
            
         

        }

        private void OnSearchButtonPressed(object sender, EventArgs e)
        {
            FilterStages(filterText.Text);
        }

        private void FilterStages(string searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText))
            {
                UpdateFilteredStages(Stages);
                return;
            }

            var filtered = Stages.Where(s =>
                s.Nom_Stage.ToLower().Contains(searchText.ToLower()) ||
                (s.Entreprise != null && s.Entreprise.Nom_Entreprise.ToLower().Contains(searchText.ToLower())))
                .ToList(); // Il fuat passer par entreprise pour aller voir ces informations
                
            UpdateFilteredStages(new ObservableCollection<Stage>(filtered));
        }

        private void UpdateFilteredStages(ObservableCollection<Stage> filteredList)
        {
            filteredStages.Clear();
            foreach (var stage in filteredList)
            {
                filteredStages.Add(stage);
            }
        }
        private void SelectionStage(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }

            var selectStage = e.SelectedItem as Stage;
            if (selectStage != null)
            {
                NomStage.Text = selectStage.Nom_Stage;
                DescriptionStage.Text = selectStage.Description_Stage;
                ImageStage.Source = selectStage.Image_Stage;
                EntrepriseRelier.Text = selectStage.Id_Entreprise.ToString();
              
                SalaireStage.Text = selectStage.Salaire_Stage.HasValue ? selectStage.Salaire_Stage.ToString() : "Non spécifié";

               
                DispoStage.Text = selectStage.IsDispo_Stage.HasValue && selectStage.IsDispo_Stage.Value ? "Disponible" : "Non disponible";

               
                ShowInformations.IsVisible = true;
            }
        }



    }
}

// La majorité des try catch erreur on été trouvé dans le net pour accélérer le processus de vérification