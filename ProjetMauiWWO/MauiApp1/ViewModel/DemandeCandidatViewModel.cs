using MauiApp1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiApp1.ViewModel
{
    internal class DemandeCandidatViewModel
    {

        public Candidature Candidature { get; set; } = new Candidature();

        public ICommand AddDocCommand { get; set; }

        public DemandeCandidatViewModel()
        {
            AddDocCommand = new Command(AddDocument);

        }

        private async void AddDocument()
        {

        }
    }
}
