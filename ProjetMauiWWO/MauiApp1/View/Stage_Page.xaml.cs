using MauiApp1.Model;
using MauiApp1.Service;
using Microsoft.Maui.Controls;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

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
            _localDbService = dbService;
            Stages = new ObservableCollection<Stage>();
            filteredStages = new ObservableCollection<Stage>();
            BindingContext = this;
            LoadStagesAsync();
        }

        private async Task LoadStagesAsync()
        {
            try
            {
                var stages = await _localDbService.GetStages();

                foreach (var stage in stages)
                {
                    Stages.Add(stage);
                }

                UpdateFilteredStages(Stages);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Impossible de récupérer les stages: {ex.Message}", "OK");
            }
        }

        private void UpdateFilteredStages(ObservableCollection<Stage> filteredList)
        {
            filteredStages.Clear();
            foreach (var stage in filteredList)
            {
                filteredStages.Add(stage);
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
                s.nom_stage.ToLower().Contains(searchText.ToLower()) ||
                s.Compagnie_Stage.ToLower().Contains(searchText.ToLower())).ToList();

            UpdateFilteredStages(new ObservableCollection<Stage>(filtered));
        }

        private async void OnDeleteAllStageButtonClicked(object sender, EventArgs e)
        {
            try
            {
          
                Debug.WriteLine("Deleting all stages...");
                await _localDbService.DeleteAllStages(); 
                Debug.WriteLine("Stages deleted successfully.");

                await LoadStagesAsync();
                Debug.WriteLine("Stagiaires reloaded successfully.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error deleting stagiaires: {ex.Message}");
                await DisplayAlert("Error", $"Error deleting stagiaires: {ex.Message}", "OK");
            }
        }

    }
}


// Le processus de suppression delete est bon pour le début de conception du programme mais sera TRÈS dangeureux lorsque les utilisateurs devronts mettre des données qui eux seront personnalisable. ISSUE OPEN !