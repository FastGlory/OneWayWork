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
            InitializeDatabaseAsync().Wait(); // On attend la synchronisation de la base de données en premier
        }

        public async Task InitializeDatabaseAsync()
        {
            await _connection.CreateTableAsync<Stagiaire>();
            await _connection.CreateTableAsync<Stage>();
            await _connection.CreateTableAsync<Administrateur>();

            await InsertData(); // Insertion des données de test
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

        public async Task<Stage> GetStageById(int id)
        {
            return await _connection.Table<Stage>().Where(x => x.Id_stage == id).FirstOrDefaultAsync();
        }

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


        // Méthodes CRUD pour la table Administrateur
        public async Task<List<Administrateur>> GetAdministrateurs()
        {
            return await _connection.Table<Administrateur>().ToListAsync();
        }

        public async Task<Administrateur> GetAdministrateurById(int id)
        {
            return await _connection.Table<Administrateur>().Where(x => x.Id_Administrateur == id).FirstOrDefaultAsync();
        }

        public async Task CreateAdministrateur(Administrateur administrateur)
        {
            await _connection.InsertAsync(administrateur);
        }

        public async Task UpdateAdministrateur(Administrateur administrateur)
        {
            await _connection.UpdateAsync(administrateur);
        }

        public async Task DeleteAdministrateur(Administrateur administrateur)
        {
            await _connection.DeleteAsync(administrateur);
        }

        // Insertion de données de test
        public async Task InsertData()
        {
            var stagiaires = await _connection.Table<Stagiaire>().ToListAsync();
            if (stagiaires.Count == 0)
            {
                var stagiairesToAdd = new List<Stagiaire>
                {
                    new Stagiaire { nom_Stagiaire = "Alice", prenom_Stagiaire = "Dupont", email_Stagiaire = "alice.dupont@example.com", MotDePasse_Stagiaire = "alice_password", image_Stagiaire = "dotnet_bot.png" },
                    new Stagiaire { nom_Stagiaire = "Bob", prenom_Stagiaire = "Martin", email_Stagiaire = "bob.martin@example.com", MotDePasse_Stagiaire = "bob_password", image_Stagiaire = "imagea.png" },
                    new Stagiaire { nom_Stagiaire = "Claire", prenom_Stagiaire = "Dubois", email_Stagiaire = "claire.dubois@example.com", MotDePasse_Stagiaire = "claire_password", image_Stagiaire = "imageb.png" },
                    new Stagiaire { nom_Stagiaire = "David", prenom_Stagiaire = "Garcia", email_Stagiaire = "david.garcia@example.com", MotDePasse_Stagiaire = "david_password", image_Stagiaire = "imagec.png" },
                    new Stagiaire { nom_Stagiaire = "Emma", prenom_Stagiaire = "Lefevre", email_Stagiaire = "emma.lefevre@example.com", MotDePasse_Stagiaire = "emma_password", image_Stagiaire = "imaged.png" },
                    new Stagiaire { nom_Stagiaire = "Fabien", prenom_Stagiaire = "Leroy", email_Stagiaire = "fabien.leroy@example.com", MotDePasse_Stagiaire = "fabien_password", image_Stagiaire = "imagee.png" },
                    new Stagiaire { nom_Stagiaire = "Gabrielle", prenom_Stagiaire = "Moreau", email_Stagiaire = "gabrielle.moreau@example.com", MotDePasse_Stagiaire = "gabrielle_password", image_Stagiaire = "imagef.png" },
                    new Stagiaire { nom_Stagiaire = "Hugo", prenom_Stagiaire = "Thomas", email_Stagiaire = "hugo.thomas@example.com", MotDePasse_Stagiaire = "hugo_password", image_Stagiaire = "imageg.png" },
                    new Stagiaire { nom_Stagiaire = "Ines", prenom_Stagiaire = "Dufour", email_Stagiaire = "ines.dufour@example.com", MotDePasse_Stagiaire = "ines_password", image_Stagiaire = "imageh.png" },
                    new Stagiaire { nom_Stagiaire = "Julie", prenom_Stagiaire = "Roux", email_Stagiaire = "julie.roux@example.com", MotDePasse_Stagiaire = "julie_password", image_Stagiaire = "imagei.png" },
                    new Stagiaire { nom_Stagiaire = "Gorge", prenom_Stagiaire = "Stevensen", email_Stagiaire = "Gorge.Stevensen@example.com", MotDePasse_Stagiaire = "Gorge_password", image_Stagiaire = "imageaj.png" }
                };

                foreach (var stagiaire in stagiairesToAdd)
                {
                    // Vérification des doublons
                    var existingStagiaire = await _connection.Table<Stagiaire>().FirstOrDefaultAsync(s => s.nom_Stagiaire == stagiaire.nom_Stagiaire && s.prenom_Stagiaire == stagiaire.prenom_Stagiaire);
                    if (existingStagiaire == null)
                    {
                        await _connection.InsertAsync(stagiaire);
                    }
                }

                var stages = await _connection.Table<Stage>().ToListAsync();
                if (stages.Count == 0)
                {
                    var stagesToAdd = new List<Stage>
                    {
                        new Stage { nom_stage = "Adminstrateur Réseau", Compagnie_Stage = "Bell", email_stage = "Bel@gmail.com", IsDispo_stage = true, priceOffer_Stage = 30.50, image_Stage = "bell.png" },
                        new Stage { nom_stage = "Programmeur Junior", Compagnie_Stage = "Amazon", email_stage = "Amazone@gmail.com", IsDispo_stage = false, priceOffer_Stage = 45.50, image_Stage = "amazon.png" },
                        new Stage { nom_stage = "Testeur", Compagnie_Stage = "Ubisoft", email_stage = "Ubisoft@gmail.com", IsDispo_stage = true, priceOffer_Stage = 55, image_Stage = "ubisoft.png" },
                        new Stage { nom_stage = "Analyste Data", Compagnie_Stage = "Google", email_stage = "Google@gmail.com", IsDispo_stage = true, priceOffer_Stage = 21, image_Stage = "google.png" },
                        new Stage { nom_stage = "Administrateur Système", Compagnie_Stage = "Alkegen", email_stage = "Alkegen@gmail.com", IsDispo_stage = false, priceOffer_Stage = 19.50, image_Stage = "alkegen.png" }
                    };

                    foreach (var stage in stagesToAdd)
                    {
                        // Vérification des doublons
                        var existingStage = await _connection.Table<Stage>().FirstOrDefaultAsync(s => s.nom_stage == stage.nom_stage && s.Compagnie_Stage == stage.Compagnie_Stage);
                        if (existingStage == null)
                        {
                            await _connection.InsertAsync(stage);
                        }
                    }
                }
            }
        }

        public async Task DeleteAllStagiaires()
        {
            await _connection.DeleteAllAsync<Stagiaire>();
        }

       
        public async Task DeleteAllStages()
        {
            await _connection.DeleteAllAsync<Stage>();
        }

    }
}
