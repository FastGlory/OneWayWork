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
using System.Globalization;

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
        IdSessionLabel.Text = $"IdSession: {IdSessionServiceApp.Instance.GetSessionId()}";
        BindingContext = this;
        LoadDraftsAsync(IdSessionServiceApp.Instance.GetSessionId());


    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        string idSession = IdSessionServiceApp.Instance.GetSessionId();
        IdSessionLabel.Text = $"IdSession: {idSession}";
    }

    private async void LoadDraftsAsync(string idSession)
    {
        try
        {
            var drafts = await _localDbService.GetdraftFromUser(idSession);

            foreach (var draft in drafts)
            {
                Drafts.Add(draft);



              

                 if (draft.Is_Accepted)
                {
                    draft.Status = "Vous êtes accepter";
                    draft.StatusColor = "Green";

                }
                else if (!draft.Is_Accepted)
                {

                    draft.Status = "Vous êtes en attente";
                    draft.StatusColor = "White";

                }


                if (draft.Is_Declined)
                {

                    draft.Status = "Vous êtes refuser";
                    draft.StatusColor = "Red";


                }

            }


        




        }
        catch (Exception ex)
        {
            {
                MessageLabel.Text = $"Erreur inconnu: {ex.Message}";
            }


        }



    }

    private async void Button_Clicked_Delete(object sender, EventArgs e)
    {
        var button = (Button)sender;
        var candidature = (Candidature)button.BindingContext;
        await _localDbService.DeleteCandidature(candidature);  // supp de la base de donnee
        Drafts.Remove(candidature); // sup de l'interface

    }


    
    
}









