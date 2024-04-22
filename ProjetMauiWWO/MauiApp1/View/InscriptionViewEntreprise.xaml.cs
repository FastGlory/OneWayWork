using MauiApp1.Model;
using MauiApp1.Service;

namespace MauiApp1.View
{
    public partial class InscriptionViewEntreprise : ContentPage
    {
        private readonly LocalDbService _localDbService;

        public InscriptionViewEntreprise(LocalDbService dbService)
        {
            _localDbService = dbService;
            InitializeComponent();
        }

        private async void OnInscriptionTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new InscriptionView(_localDbService));
        }

        private async void CreactionClick(object sender, EventArgs e)
        {
            string nomEntreprise = AddNomEntreprise.Text;
            string email = AddEmailEntreprise.Text;
            string password = AddPasswordEntreprise.Text;
            string codeSecret = CodeSecret.Text;

            try
            {
                if (string.IsNullOrWhiteSpace(nomEntreprise) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(codeSecret))
                {
                    MessageLabel.Text = "Veuillez saisir tous les champs.";
                    return;
                }

                // Vérification du code secret
                if (codeSecret != "XVA123")
                {
                    MessageLabel.Text = "Code secret incorrect.";
                    return;
                }

                var entreprises = await _localDbService.GetEntreprises();

                var existingEntreprise = entreprises.FirstOrDefault(entreprise => entreprise.Email_Entreprise == email);
                if (existingEntreprise != null)
                {
                    MessageLabel.Text = "Compte déjà existant.";
                    return;
                }
                else
                {
                    // On insérer les données improtante
                    var nouvelleEntreprise = new Entreprise
                    {
                        Nom_Entreprise = nomEntreprise,
                        Email_Entreprise = email,
                        MotDePasse_Entreprise = password,
                        IsAdmin = false, // double vérification pour s'assurer que c'est bien false
                        Image_Entreprise = "entreprisedefaut.png"
                    };

                    // Ici avec la méthode crud en rajoute  l'entreprise dans la database
                    await _localDbService.AddEntreprise(nouvelleEntreprise);

                    MessageLabel.Text = "Compte créé avec succès.";
                }
            }
            catch (Exception ex)
            {
                MessageLabel.Text = $"Erreur lors de la création du compte : {ex.Message}";
            }
        }
    }
}
