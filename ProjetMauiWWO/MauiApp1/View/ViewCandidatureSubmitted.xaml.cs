using System.Collections.ObjectModel;
using MauiApp1.Model;
using MauiApp1.Service;
using MauiApp1.ViewModel;
using Microsoft.Maui.Controls;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace MauiApp1.View;

public partial class ViewCandidatureSubmitted : ContentPage
{

    private readonly LocalDbService _localDbService;
    public ObservableCollection<Candidature> CandidatureSubmit { get; set; }
    public ViewCandidatureSubmitted(LocalDbService localDbService)
    {
        InitializeComponent();
        _localDbService = localDbService;
        string idSession = IdSessionServiceApp.Instance.GetSessionId(); // on prend le session idd pour enregistrer le brouillon dépendant du compte de la personne
        CandidatureSubmit = new ObservableCollection<Candidature>();
        IdSessionLabel.Text = $"IdSession: {idSession}";
        BindingContext = this;
        LoadCandidatureAsync();


    }


    private async void LoadCandidatureAsync()
    {
        try
        {
            var CandidatureSubmit = await _localDbService.GetCandidatureFromUser();

            foreach (var candidature in CandidatureSubmit)
            {
                CandidatureSubmit.Add(candidature);

            }

        }
        catch (InvalidOperationException ex)
        {
            MessageLabel.Text = $"Erreur inconnu: {ex.Message}";
        }






    }

   
}








