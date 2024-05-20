using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.ViewModel
{

    public class IdSessionServiceApp
    {
       // Permet de crée une instance dans toute l'application et de stocker pour notre la variable
        private static IdSessionServiceApp _instance;

        public static IdSessionServiceApp Instance
        {
            get
            {
                // On créer l'instance si elle n'exist epas
                if (_instance == null)
                {
                    _instance = new IdSessionServiceApp();
                }
                return _instance;
            }
        }

        public string IdSession { get;  set; }

        // méthode pour le set
        public void SetSessionId(string id)
        {
            IdSession = id;
            // Ici ca va permettre de pouvoir offrir la possibilité selon l'instance de Appshell de mettre à jours sa visibilité en fonction de sont IdSession
            // si vous l'enlever ce que ca va faire c'est que sa va belle bien caché les pages selon l'id Session mais seulement 1 fois (impossible de recharger)
            ((AppShell)Shell.Current).OptionVisible();
            
        }

        // méthode get
        public string GetSessionId()
        {
            return IdSession;
        }
    }


}

// La ligne 34 est inspiré de ce code : https://stackoverflow.com/questions/75551165/switch-app-shell-tab-programmatically-to-current-page-on-tab-not-with-gotoasync + une vidéo : 