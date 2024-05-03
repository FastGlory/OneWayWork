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
    public partial class Stagiaire_Page : ContentPage
    {
        private readonly LocalDbService _localDbService;
        private ObservableCollection<Stagiaire> filteredStagiaires;

        public ObservableCollection<Stagiaire> Stagiaires { get; set; }

        public Stagiaire_Page(LocalDbService dbService)
        {
            InitializeComponent();
            string IdSession = IdSessionServiceApp.Instance.GetSessionId();
            IdSessionLabel.Text = $"IdSession: {IdSession}";
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
                var stagiaires = await _localDbService.GetStagiaires();
              
                foreach (var stagiaire in stagiaires)
                {
                    Stagiaires.Add(stagiaire);
                }

               
                UpdateFilteredStagiaires(Stagiaires);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Impossible de récupérer les stagiaires: {ex.Message}", "OK");
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

        private void SelectionStagiaire(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }

            var selectedStagiaire = e.SelectedItem as Stagiaire;
            if (selectedStagiaire != null)
            {
                NomStagiaire.Text = selectedStagiaire.nom_Stagiaire;
                PrenomStagiaire.Text = selectedStagiaire.prenom_Stagiaire;
                EmailStagiaire.Text = selectedStagiaire.email_Stagiaire;
                EntrepriseAcceptation.Text = selectedStagiaire.IdEntrepriseChoice != null ? selectedStagiaire.IdEntrepriseChoice.ToString() : "Ce stagiaire est actuellement à la recherche d'un stage";
                ImageStagiaire.Source = selectedStagiaire.image_Stagiaire;


                // On active la fonctionnalité pour rendre visible
                // si on veut on pourra rajouter une fonctionnalité s'il reclick sa va annulé IsVisible
                ShowInformations.IsVisible = true;
            }
        }


    }
}


// Filtre : https://support.syncfusion.com/kb/article/11354/how-to-filter-the-items-in-net-maui-listview-sflistview-using-mvvm?isInternalRefresh=False 
// La majorité des try catch erreur on été trouvé dans le net pour accélérer le processus de vérification