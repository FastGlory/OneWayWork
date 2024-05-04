using System.Net.Mime;
using System.Security.Cryptography.X509Certificates;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using MauiApp1.Model;
using MauiApp1.Service;

namespace MauiApp1.View;

public partial class DemandeCandidatView : ContentPage
{
    private readonly LocalDbService _localDbService;

    public DemandeCandidatView(LocalDbService dbService)
    {

        _localDbService = dbService;
        InitializeComponent();

    }



    private async void UploadDocBtn(object sender, EventArgs e)
    {
        PublicKey publicKey = null;
    }


   












}