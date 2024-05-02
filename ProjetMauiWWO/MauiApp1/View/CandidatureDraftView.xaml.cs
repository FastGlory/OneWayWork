using MauiApp1.Model;
using System.Collections.ObjectModel;
using MauiApp1.Model;
using MauiApp1.Service;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
namespace MauiApp1.View;

public partial class CandidatureDraftView : ContentPage
{

    private readonly LocalDbService _localDbService;
    private ObservableCollection<Candidature> _drafts;

    public ObservableCollection<Candidature> Candidature { get; set; }


    public CandidatureDraftView(LocalDbService dbService)
    {

        InitializeComponent();
        _localDbService = dbService;
        Candidature = new ObservableCollection<Candidature>();
        _drafts = new ObservableCollection<Candidature>();
        BindingContext = this;
        
    }
}