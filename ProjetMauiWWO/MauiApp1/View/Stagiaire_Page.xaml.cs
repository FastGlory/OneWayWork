using Microsoft.Maui.Controls;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using MauiApp1.Model;
using MauiApp1.Service;
using System.Diagnostics;

namespace MauiApp1.View
{
    public partial class Stagiaire_Page : ContentPage
    {
        private readonly LocalDbService _localDbService;
        private ObservableCollection<Stagiaire> filteredStagiaires;

        public ObservableCollection<Stagiaire> Stagiaires { get; set; }

        public Stagiaire_Page(LocalDbService dbService)
        {
            InitializeComponent();
            _localDbService = dbService;
            Stagiaires = new ObservableCollection<Stagiaire>();
            filteredStagiaires = new ObservableCollection<Stagiaire>();
            BindingContext = this;
            listView.ItemsSource = filteredStagiaires;
            LoadStagiairesAsync();
        }



        // Code d'affichage des stagiaires
        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        private async Task LoadStagiairesAsync()
        {
            try
            {
                var stagiaires = await _localDbService.GetStagiaire();
              
                foreach (var stagiaire in stagiaires)
                {
                    Stagiaires.Add(stagiaire);
                }

               
                UpdateFilteredStagiaires(Stagiaires);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Impossible de r�cup�rer les stagiaires: {ex.Message}", "OK");
            }
        }

        private async void OnDeleteAllStagiairesButtonClicked(object sender, EventArgs e)
        {
            try
            {
                Debug.WriteLine("Deleting all stagiaires...");
                await _localDbService.DeleteAllStagiaires();
                Debug.WriteLine("Stagiaires deleted successfully.");
                await LoadStagiairesAsync();
                Debug.WriteLine("Stagiaires reloaded successfully.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error deleting stagiaires: {ex.Message}");
                await DisplayAlert("Error", $"Error deleting stagiaires: {ex.Message}", "OK");
            }
        }

        // Code pour le filtre



        private void OnSearchButtonPressed(object sender, EventArgs e)
        {
            FilterContacts(filterText.Text);
        }

        private void FilterContacts(string searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText))
            {
               
                UpdateFilteredStagiaires(Stagiaires);
                return;
            }

           
            var filtered = Stagiaires.Where(s =>
                s.nom_Stagiaire.ToLower().Contains(searchText.ToLower()) ||
                s.prenom_Stagiaire.ToLower().Contains(searchText.ToLower())).ToList();

            UpdateFilteredStagiaires(new ObservableCollection<Stagiaire>(filtered));
        }

        private void UpdateFilteredStagiaires(ObservableCollection<Stagiaire> filteredList)
        {
         
            filteredStagiaires.Clear();
            foreach (var stagiaire in filteredList)
            {
                filteredStagiaires.Add(stagiaire);
            }
        }
    }
}


// Filtre : https://support.syncfusion.com/kb/article/11354/how-to-filter-the-items-in-net-maui-listview-sflistview-using-mvvm?isInternalRefresh=False 