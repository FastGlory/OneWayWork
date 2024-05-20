using MauiApp1.View;
using MauiApp1.ViewModel;
using System.Linq;

namespace MauiApp1
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            OptionVisible();
        }

        public void OptionVisible()
        {
            string sessionId = IdSessionServiceApp.Instance.GetSessionId();

            if (string.IsNullOrEmpty(sessionId))
            {
                Autorisation(ConnexionPage);
                Refus(StagiairePage);
                Refus(StagePage);
                Refus(EntreprisePage);
                Refus(ViewCandidatureSubmittedPage);
                Refus(CreationStagePage);
                Refus(CandidatureDraftViewPage);
                Refus(PageAccueilAdminPage);
                Refus(PageAccueilEntreprisePage);
                Refus(PageAccueilStagiairePage);
            }
            else if (sessionId.StartsWith("A"))
            {
                Autorisation(ConnexionPage);
                Autorisation(StagiairePage);
                Autorisation(StagePage);
                Autorisation(EntreprisePage);
                Autorisation(ViewCandidatureSubmittedPage);
                Autorisation(CreationStagePage);
                Autorisation(CandidatureDraftViewPage);
                Autorisation(PageAccueilAdminPage);
                Refus(PageAccueilEntreprisePage);
                Refus(PageAccueilStagiairePage);
            }
            else if (sessionId.StartsWith("E"))
            {
                Autorisation(ConnexionPage);
                Autorisation(StagiairePage);
                Autorisation(StagePage);
                Refus(EntreprisePage);
                Autorisation(ViewCandidatureSubmittedPage);
                Autorisation(CreationStagePage);
                Refus(CandidatureDraftViewPage);
                Refus(PageAccueilAdminPage);
                Autorisation(PageAccueilEntreprisePage);
                Refus(PageAccueilStagiairePage);
            }
            else
            {
                Autorisation(ConnexionPage);
                Refus(StagiairePage);
                Autorisation(StagePage);
                Refus(EntreprisePage);
                Autorisation(ViewCandidatureSubmittedPage);
                Refus(CreationStagePage);
                Autorisation(CandidatureDraftViewPage);
                Refus(PageAccueilAdminPage);
                Refus(PageAccueilEntreprisePage);
                Autorisation(PageAccueilStagiairePage);
            }
        }

        private void Autorisation(ShellContent page)
        {
            if (!Items.Contains(page))
            {
                Items.Add(page);
            }
        }
        private void Refus(ShellContent page)
        {
            if (Items.Contains(page))
            {
                Items.Remove(page);
            }
        }
    }
}