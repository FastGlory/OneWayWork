using System.Net.Mime;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Maui.Controls;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using MauiApp1.Model;
using MauiApp1.Service;
using System.Diagnostics;
using MauiApp1.ViewModel;
using System.Runtime.CompilerServices;

namespace MauiApp1.View;


public partial class DemandeCandidatView : ContentPage
{

    private readonly LocalDbService _localDbService;


    public DemandeCandidatView(LocalDbService dbService)
    {

        InitializeComponent();
        _localDbService = dbService;

    }


    private async void AddToDraft(object sender, EventArgs e, Stagiaire stagiaire)
    {
        string description = AddCandidatureDescription.Text;
        string linkSubmited = AddLinkCandidature.Text;



        try
        {
            if (string.IsNullOrWhiteSpace(description) || string.IsNullOrWhiteSpace(linkSubmited))
            {
                MessageLabelCandidature.Text = "Veuillez saisir tous les champs.";
                return;
            }



            Candidature candidature = new Candidature
            {

                Description_Candidature = description,
                Lien_Candidature = linkSubmited,
                Is_Draft = true,
                Id_Stagiaire = stagiaire.Id_Stagiaire
            };


            await _localDbService.SaveDraftCandidature(stagiaire, candidature);
            MessageLabelCandidature.Text = "Brouillon enregistré avec succès !";
            

        }
        catch (Exception)
        {
            MessageLabelCandidature.Text = "Erreur lors de l'enregistrement du brouillon";
        }



    }


    private void DocBtn_Clicked(object sender, EventArgs e)
    {

    }

    private void SubmitCandidat(object sender, EventArgs e)
    {

    }

    private void SeeMyDraft(object sender, EventArgs e)
    {

    }

    private void Button_Clicked(object sender, EventArgs e)
    {

    }
}




