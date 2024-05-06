using MauiApp1.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MauiApp1.Service
{
    public class LocalDbService
    {
        private const string DB_NAME = "OneWayWork.db3";
        private readonly SQLiteAsyncConnection _connection;

        public LocalDbService()
        {
            _connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, DB_NAME));
            _connection.ExecuteAsync("PRAGMA foreign_keys = ON").Wait(); // Active la possibilité de faire des foreign_key / Trouvé dans le net mais je sais pas si c'est vraiment efficace
            InitializeDatabaseAsync().Wait(); // Initialize the database
        }

        public async Task InitializeDatabaseAsync()
        {
            await _connection.CreateTableAsync<Stagiaire>();
            await _connection.CreateTableAsync<Stage>();
            await _connection.CreateTableAsync<Entreprise>();
            await _connection.CreateTableAsync<Candidature>();

            await InsertData(); // On insère les donnée importantes
        }

        // Méthodes CRUD pour la table Stagiaire
        public async Task<List<Stagiaire>> GetStagiaires()
        {
            return await _connection.Table<Stagiaire>().ToListAsync();
        }

        public async Task<Stagiaire> GetStagiaireById(int id)
        {
            return await _connection.Table<Stagiaire>().Where(x => x.Id_Stagiaire == id).FirstOrDefaultAsync();
        }

        public async Task AddStagiaire(Stagiaire stagiaire)
        {
            await _connection.InsertAsync(stagiaire);
        }

        public async Task UpdateStagiaire(Stagiaire stagiaire)
        {
            await _connection.UpdateAsync(stagiaire);
        }

        public async Task DeleteStagiaire(Stagiaire stagiaire)
        {
            await _connection.DeleteAsync(stagiaire);
        }

        // Méthodes CRUD pour la table Stage
        public async Task<List<Stage>> GetStages()
        {
            return await _connection.Table<Stage>().ToListAsync();
        }

        public async Task<Entreprise> GetEntrepriseById(int id)
        {
            return await _connection.Table<Entreprise>().Where(x => x.Id_Entreprise == id).FirstOrDefaultAsync();
        }


        // FAUT CORRIGER ET TROUVER UN MOYEN DE RÉCUPÈRER LES ID DES ENTREPRSIE QUI CORRESPOND A DES ID STAGES
        // ################################################################################################################
        public async Task<Stage> GetStageById(int id)
        {
            var stage = await _connection.Table<Stage>().Where(x => x.Id_Stage == id).FirstOrDefaultAsync();
            if (stage != null)
            {
                stage.Entreprise = await GetEntrepriseById(stage.Id_Entreprise);
            }
            return stage;
        }

        public async Task<List<int>> GetStageIdsByEntrepriseId(int entrepriseId)
        {
            var stages = await _connection.Table<Stage>().Where(x => x.Id_Entreprise == entrepriseId).ToListAsync();
            var stageIds = stages.Select(stage => stage.Id_Stage).ToList();
            return stageIds;
        }
        // ################################################################################################################

        public async Task CreateStage(Stage stage)
        {
            await _connection.InsertAsync(stage);
        }

        public async Task UpdateStage(Stage stage)
        {
            await _connection.UpdateAsync(stage);
        }

        public async Task DeleteStage(Stage stage)
        {
            await _connection.DeleteAsync(stage);
        }

        // Méthodes CRUD pour la table Entreprise
        public async Task<List<Entreprise>> GetEntreprises()
        {
            return await _connection.Table<Entreprise>().ToListAsync();
        }
        public async Task<List<Stage>> GetStagesByEntrepriseId(int entrepriseId)
        {
            return await _connection.Table<Stage>().Where(x => x.Id_Entreprise == entrepriseId).ToListAsync();
        }


        public async Task<Entreprise> GetEntrepriseByNom(string nom)
        {
            return await _connection.Table<Entreprise>().Where(x => x.Nom_Entreprise == nom).FirstOrDefaultAsync();
        }

        public async Task AddEntreprise(Entreprise entreprise)
        {
            await _connection.InsertAsync(entreprise);
        }

        public async Task UpdateEntreprise(Entreprise entreprise)
        {
            await _connection.UpdateAsync(entreprise);
        }

        public async Task DeleteEntreprise(Entreprise entreprise)
        {
            await _connection.DeleteAsync(entreprise);
        }

        // Méthode CRDU pour les candidatures ++++++++++++++++++++++++++++++++++++++++++++++++++++++

        public async Task<List<Candidature>> GetCandidature()
        {
            return await _connection.Table<Candidature>().ToListAsync();
        }

        public async Task SaveCandidature(Candidature candidature)
        {

            if (candidature == null)
            {
                throw new ArgumentNullException(nameof(candidature));
            }

            await _connection.InsertAsync(candidature);

        }

        public async Task<List<Candidature>> GetdraftFromUser(string idSession)
        {
            if (string.IsNullOrWhiteSpace(idSession))
            {
                throw new ArgumentNullException(nameof(idSession));
            }

            return await _connection.Table<Candidature>()
                .Where(c => c.IdSession == idSession) 
                .ToListAsync();
        }

        // Insertion de données de test
        public async Task InsertData()
        {
            var stagiaires = await _connection.Table<Stagiaire>().ToListAsync();
            if (stagiaires.Count == 0)
            {
                var stagiairesToAdd = new List<Stagiaire>
                    {
                        // On rajoute ici les stagiaire pour voir s'il s'affiche bien  !
                        new Stagiaire { nom_Stagiaire = "Alice", prenom_Stagiaire = "Dupont", email_Stagiaire = "alice.dupont@example.com", MotDePasse_Stagiaire = "alice_password", image_Stagiaire = "dotnet_bot.png" ,IdSession = "12412", IdEntrepriseChoice=null },
                        new Stagiaire { nom_Stagiaire = "Bob", prenom_Stagiaire = "Martin", email_Stagiaire = "bob.martin@example.com", MotDePasse_Stagiaire = "bob_password", image_Stagiaire = "imagea.png" ,IdSession = "45423", IdEntrepriseChoice=null },
                        new Stagiaire { nom_Stagiaire = "Claire", prenom_Stagiaire = "Dubois", email_Stagiaire = "claire.dubois@example.com", MotDePasse_Stagiaire = "claire_password", image_Stagiaire = "imageb.png" ,IdSession = "89785", IdEntrepriseChoice=null },
                        new Stagiaire { nom_Stagiaire = "David", prenom_Stagiaire = "Garcia", email_Stagiaire = "david.garcia@example.com", MotDePasse_Stagiaire = "david_password", image_Stagiaire = "imagec.png" ,IdSession = "34232", IdEntrepriseChoice=null },
                        new Stagiaire { nom_Stagiaire = "Emma", prenom_Stagiaire = "Lefevre", email_Stagiaire = "emma.lefevre@example.com", MotDePasse_Stagiaire = "emma_password", image_Stagiaire = "imaged.png" , IdSession = "45472", IdEntrepriseChoice=null },
                        new Stagiaire { nom_Stagiaire = "Fabien", prenom_Stagiaire = "Leroy", email_Stagiaire = "fabien.leroy@example.com", MotDePasse_Stagiaire = "fabien_password", image_Stagiaire = "imagee.png" , IdSession = "12124", IdEntrepriseChoice=null },
                        new Stagiaire { nom_Stagiaire = "Gabrielle", prenom_Stagiaire = "Moreau", email_Stagiaire = "gabrielle.moreau@example.com", MotDePasse_Stagiaire = "gabrielle_password", image_Stagiaire = "imagef.png" , IdSession = "87765", IdEntrepriseChoice=null },
                        new Stagiaire { nom_Stagiaire = "Hugo", prenom_Stagiaire = "Thomas", email_Stagiaire = "hugo.thomas@example.com", MotDePasse_Stagiaire = "hugo_password", image_Stagiaire = "imageg.png"    , IdSession = "325765", IdEntrepriseChoice=null },
                        new Stagiaire { nom_Stagiaire = "Ines", prenom_Stagiaire = "Dufour", email_Stagiaire = "ines.dufour@example.com", MotDePasse_Stagiaire = "ines_password", image_Stagiaire = "imageh.png" , IdSession = "48093", IdEntrepriseChoice=null },
                        new Stagiaire { nom_Stagiaire = "Julie", prenom_Stagiaire = "Roux", email_Stagiaire = "julie.roux@example.com", MotDePasse_Stagiaire = "julie_password", image_Stagiaire = "imagei.png" , IdSession = "65322", IdEntrepriseChoice=null },
                        new Stagiaire { nom_Stagiaire = "Gorge", prenom_Stagiaire = "Stevensen", email_Stagiaire = "Gorge.Stevensen@example.com", MotDePasse_Stagiaire = "Gorge_password", image_Stagiaire = "imageaj.png" , IdSession = "235665", IdEntrepriseChoice=null  }
                    };

                foreach (var stagiaire in stagiairesToAdd)
                {
                    // Vérification des doublons ! 
                    var existingStagiaire = await _connection.Table<Stagiaire>().FirstOrDefaultAsync(s => s.nom_Stagiaire == stagiaire.nom_Stagiaire && s.prenom_Stagiaire == stagiaire.prenom_Stagiaire);
                    if (existingStagiaire == null)
                    {
                        await _connection.InsertAsync(stagiaire);
                    }
                }
            }

            var entreprises = await _connection.Table<Entreprise>().ToListAsync();
            if (entreprises.Count == 0)
            {
                var entreprisesToAdd = new List<Entreprise>
                    {
                       // On rajoute ici les Entreprise pour voir s'il s'affiche bien  !
                        new Entreprise { Id_Entreprise=1 ,Nom_Entreprise = "Bell", Email_Entreprise = "Bel@gmail.com", Image_Entreprise = "bell_logo.png", MotDePasse_Entreprise = "motdepasse123", IsAdmin = false ,Description_Entreprise="L'entreprise télécommunication" },
                        new Entreprise { Id_Entreprise=2 ,Nom_Entreprise = "Amazon", Email_Entreprise = "Amazone@gmail.com", Image_Entreprise = "amazon_logo.png", MotDePasse_Entreprise = "motdepasse456", IsAdmin = false ,Description_Entreprise="Entreprise LUGUBRE" },
                        new Entreprise { Id_Entreprise=3,Nom_Entreprise = "Ubisoft", Email_Entreprise = "Ubisoft@gmail.com", Image_Entreprise = "ubisoft_logo.png", MotDePasse_Entreprise = "motdepasse789", IsAdmin = false,Description_Entreprise="je sais pas quoi dire"  },
                        new Entreprise { Id_Entreprise=4 ,Nom_Entreprise = "Google", Email_Entreprise = "Google@gmail.com", Image_Entreprise = "google_logo.png", MotDePasse_Entreprise = "motdepasse101112", IsAdmin = false,Description_Entreprise="Tuto youtube comment faire du pyton"  },
                        new Entreprise { Id_Entreprise=5,Nom_Entreprise = "Alkegen", Email_Entreprise = "Alkegen@gmail.com", Image_Entreprise = "alkegen_logo.png", MotDePasse_Entreprise = "motdepasse131415", IsAdmin = false,Description_Entreprise="Je me suis fait hack mon compte sauvez moi !"  }
                    };

                foreach (var entreprise in entreprisesToAdd)
                {
                    await _connection.InsertAsync(entreprise);
                }
            }

            var stages = await _connection.Table<Stage>().ToListAsync();
            if (stages.Count == 0)
            {
                var stagesToAdd = new List<Stage>
                {
                    // On rajoute ici les Entreprise pour voir s'il s'affiche bien  !

                    // Raison bug 1  : J'ai oublié de mettre Id_Entreprise TRÈS IMPORTANT sinon DB morte
                    new Stage {Id_Stage=1,Nom_Stage = "Adminstrateur Réseau", Id_Entreprise = 1, IsDispo_Stage = true, Salaire_Stage = 30.50, Image_Stage = "bell.png",Description_Stage ="Ceci est le stage de Bell" },
                    new Stage {Id_Stage=2, Nom_Stage = "Programmeur Junior", Id_Entreprise = 2, IsDispo_Stage = false, Salaire_Stage = 45.50, Image_Stage = "amazon.png",Description_Stage ="123 viva l'algérie" },
                    new Stage {Id_Stage=3, Nom_Stage = "Testeur", Id_Entreprise = 3, IsDispo_Stage = true, Salaire_Stage = 55, Image_Stage = "ubisoft.png",Description_Stage ="Ceci est le stage de ubisoft" },
                    new Stage {Id_Stage=4, Nom_Stage = "Analyste Data", Id_Entreprise = 4, IsDispo_Stage = true, Salaire_Stage = 21, Image_Stage = "google.png",Description_Stage ="Ceci est le stage de Google" },
                    new Stage {Id_Stage=5, Nom_Stage = "Administrateur Système", Id_Entreprise = 5, IsDispo_Stage = false, Salaire_Stage = 19.50, Image_Stage = "alkegen.png",Description_Stage ="Ceci est le stage de alkegane" }
                };

                foreach (var stage in stagesToAdd)
                {
                    // Vérification des doublons
                    var existingStage = await _connection.Table<Stage>().FirstOrDefaultAsync(s => s.Nom_Stage == stage.Nom_Stage);
                    if (existingStage == null)
                    {
                        await _connection.InsertAsync(stage);
                    }
                }
            }
        }

        // Très utile pour les test. Après chaque modification faudra les appelé pour voir si ce n'est pas des anciennes données
        public async Task DeleteAllStagiaires()
        {
            await _connection.DeleteAllAsync<Stagiaire>();
        }

       
        public async Task DeleteAllStages()
        {
            await _connection.DeleteAllAsync<Stage>();
        }
        public async Task DeleteAllEntreprises()
        {
            await _connection.DeleteAllAsync<Entreprise>();
        }


    }
}
