// Modifier le ViewModel StagiaireViewModel pour qu'il ressemble à ceci :
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using MauiApp1.Model;
using MauiApp1.Service;

namespace MauiApp1.ViewModel
{
    public class StagiaireViewModel
    {
        private readonly LocalDbService _localDbService;

        public ObservableCollection<Stagiaire> Stagiaires { get; set; }

        public StagiaireViewModel()
        {
            _localDbService = new LocalDbService();
            Stagiaires = new ObservableCollection<Stagiaire>();
            LoadStagiaires();
        }

        private async Task LoadStagiaires()
        {
            var stagiaires = await _localDbService.GetStagiaire();
            foreach (var stagiaire in stagiaires)
            {
                Stagiaires.Add(stagiaire);
            }
        }
    }
}
