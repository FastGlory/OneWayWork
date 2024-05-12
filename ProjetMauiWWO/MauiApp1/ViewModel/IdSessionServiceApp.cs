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
        }

        // méthode get
        public string GetSessionId()
        {
            return IdSession;
        }
    }


}
