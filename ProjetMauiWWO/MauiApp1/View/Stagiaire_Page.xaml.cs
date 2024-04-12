using MauiApp1.Model;
using MauiApp1.Service;
using System.Collections.ObjectModel;

namespace MauiApp1.View
{
    public partial class Stagiaire_Page : ContentPage
    {
        private readonly LocalDbService _localDbService;
        public ObservableCollection<Stagiaire> Stagiaires { get; set; }

        public Stagiaire_Page(LocalDbService dbService)
        {
            InitializeComponent();
            _localDbService = dbService;
            Stagiaires = new ObservableCollection<Stagiaire>(); 

            
            Task.Run(async () =>
            {
                await _localDbService.InsertDonne();
                await LoadStagiairesAsync(); 
            });
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await LoadStagiairesAsync(); 
        }

        private async Task LoadStagiairesAsync()
        {
            try
            {
                var stagiaires = await _localDbService.GetStagiaire();
                Stagiaires.Clear(); 
                foreach (var stagiaire in stagiaires)
                {
                    Stagiaires.Add(stagiaire);
                }
            }
            catch (Exception ex)
            {
               
                await DisplayAlert("Error", $"Impossible de récupèrer les stagiaires: {ex.Message}", "OK");
            }
        }
    }
}
