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

        protected override async void OnAppearing()
        {
            
            // Appel de la m�thode OnAppearing() de la classe parente (ContentPage)
            base.OnAppearing();
            await LoadStagesAsync(); // La on va simplement charger
        } // Permet de montrer les informations des stages � l'utilisateur et le base. c'est une mani�re de faire r�f�rence directement

        private async Task LoadStagesAsync()
        {
            try
            {
                Debug.WriteLine("Chargement des stage..."); // Inutile mais styl�
                var stages = await _localDbService.GetStages();
                Debug.WriteLine($"Nombre de stage AVANT ins�ration: {stages.Count}");

                Stages.Clear();

                foreach (var stage in stages)
                {
                    stage.Entreprise = await _localDbService.GetEntrepriseById(stage.Id_Entreprise);
                    Stages.Add(stage);
                }

                Debug.WriteLine($"Nombre de stage APR�S ins�ration: {Stages.Count}");

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
    }
}

// La majorit� des try catch erreur on �t� trouv� dans le net pour acc�l�rer le processus de v�rification