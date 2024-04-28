using MauiApp1.Model;
using MauiApp1.Service;
using MauiApp1.ViewModel;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace MauiApp1.View;

public partial class PageEntrepriseWWO : ContentPage
{
    private readonly LocalDbService _localDbService;
    private ObservableCollection<Entreprise> filteredEntreprises;

    public ObservableCollection<Entreprise> Entreprises { get; set; }

    public PageEntrepriseWWO(LocalDbService dbService)
    {
        InitializeComponent();
        string IdSession = IdSessionServiceApp.Instance.GetSessionId();
        IdSessionLabel.Text = $"IdSession: {IdSession}";
        _localDbService = dbService;
        Entreprises = new ObservableCollection<Entreprise>();
        filteredEntreprises = new ObservableCollection<Entreprise>();
        BindingContext = this;
        listView.ItemsSource = filteredEntreprises;
        LoadEntreprisesAsync();
       
    }

    // Code d'affichage des entreprises
    protected override void OnAppearing()
    {
        base.OnAppearing();
    }

    private async Task LoadEntreprisesAsync()
    {
        try
        {
            var entreprises = await _localDbService.GetEntreprises();

            foreach (var entreprise in entreprises)
            {
                Entreprises.Add(entreprise);
            }

            UpdateFilteredEntreprises(Entreprises);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error loading entreprises: {ex.Message}");
        }
    }

    private async void OnDeleteAllEntreprisesButtonClicked(object sender, EventArgs e)
    {
        try
        {
            Debug.WriteLine("Deleting all entreprises...");
            await _localDbService.DeleteAllEntreprises();
            Debug.WriteLine("Entreprises deleted successfully.");
            await LoadEntreprisesAsync();
            Debug.WriteLine("Entreprises reloaded successfully.");
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error deleting entreprises: {ex.Message}");
        }
    }

    // Code pour le filtre

    private void OnSearchButtonPressed(object sender, EventArgs e)
    {
        FilterEntreprises(filterText.Text);
    }

    private void FilterEntreprises(string searchText)
    {
        if (string.IsNullOrWhiteSpace(searchText))
        {
            UpdateFilteredEntreprises(Entreprises);
            return;
        }

        var filtered = Entreprises.Where(s =>
            s.Nom_Entreprise.ToLower().Contains(searchText.ToLower()) ||
            s.Email_Entreprise.ToLower().Contains(searchText.ToLower())).ToList();

        UpdateFilteredEntreprises(new ObservableCollection<Entreprise>(filtered));
    }

    private void UpdateFilteredEntreprises(ObservableCollection<Entreprise> filteredList)
    {
        filteredEntreprises.Clear();
        foreach (var entreprise in filteredList)
        {
            filteredEntreprises.Add(entreprise);
        }
    }
}
