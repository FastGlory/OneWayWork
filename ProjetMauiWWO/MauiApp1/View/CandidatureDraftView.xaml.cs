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

public partial class CandidatureDraftView : ContentPage
{

    private readonly LocalDbService _localDbService;
    public ObservableCollection<Candidature> Drafts { get; set; }
    public CandidatureDraftView(LocalDbService localDbService)
    {
        InitializeComponent();
        _localDbService = localDbService;
        string idSession = IdSessionServiceApp.Instance.GetSessionId(); // on prend le session idd pour enregistrer le brouillon dépendant du compte de la personne
        Drafts = new ObservableCollection<Candidature>();
        BindingContext = this;
        LoadDraftsAsync();

    }
        

    private async void LoadDraftsAsync()
    {
        try
        {
            string idSession = IdSessionServiceApp.Instance.GetSessionId();
            var drafts = await _localDbService.GetdraftFromUser(idSession);
            drafts.Clear();

            foreach (var draft in drafts)
            {
                Drafts.Add(draft);


            }

        }catch (Exception ex)
        {
            MessageLabel.Text = $"Erreur inconnu: {ex.Message}";
        }
    }
   

    }









