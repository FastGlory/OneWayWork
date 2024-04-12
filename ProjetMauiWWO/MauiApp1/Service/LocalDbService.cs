using MauiApp1.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            _connection.CreateTableAsync<Stagiaire>();
            _connection.CreateTableAsync<Stage>();
            _connection.CreateTableAsync<Administrateur>();


        }

        // Ici on appel la méthode crud pour la table Stagiaire
        public async Task<List<Stagiaire>> GetStagiaire()
        {
            return await _connection.Table<Stagiaire>().ToListAsync();
        }
        public async Task<Stagiaire> GetById_stagiaire(int id)
        {
            return await _connection.Table<Stagiaire>().Where(x => x.Id_Stagiaire == id).FirstOrDefaultAsync();
        }

        public async Task Create(Stagiaire stagiaire)
        {
            await _connection.InsertAsync(stagiaire);
        }

        public async Task Update(Stagiaire stagiaire)
        {
            await _connection.UpdateAsync(stagiaire);
        }
        public async Task Delete(Stagiaire stagiaire)
        {
            await _connection.DeleteAsync(stagiaire);
        }

        // Ici on appel la méthode crud pour la table Stage
        public async Task<List<Stage>> GetStage()
        {
            return await _connection.Table<Stage>().ToListAsync();
        }
        public async Task<Stage> GetById_stage(int id)
        {
            return await _connection.Table<Stage>().Where(x => x.Id_stage == id).FirstOrDefaultAsync();
        }

        public async Task Create(Stage stage)
        {
            await _connection.InsertAsync(stage);
        }

        public async Task Update(Stage stage)
        {
            await _connection.UpdateAsync(stage);
        }
        public async Task Delete(Stage stage)
        {
            await _connection.DeleteAsync(stage);
        }


        // Ici on appel la méthode crud pour la table Administrateur

        public async Task<List<Administrateur>> GetAdministrateur()
        {
            return await _connection.Table<Administrateur>().ToListAsync();
        }
        public async Task<Administrateur> GetById_Administrateur(int id)
        {
            return await _connection.Table<Administrateur>().Where(x => x.Id_Administrateur == id).FirstOrDefaultAsync();
        }

        public async Task Create(Administrateur administrateur)
        {
            await _connection.InsertAsync(administrateur);
        }

        public async Task Update(Administrateur administrateur)
        {
            await _connection.UpdateAsync(administrateur);
        }
        public async Task Delete(Administrateur administrateur)
        {
            await _connection.DeleteAsync(administrateur);
        }

        // Ici on va insérer des données test (les stagiaires sont généré par une AI mais le reste vienne de nous)

        public async Task InsertDonne()
        {
            // Ajout de 10 stagiaires
            var stagiaires = new List<Stagiaire>
            {
                new Stagiaire { nom_Stagiaire = "Alice", prenom_Stagiaire = "Dupont", email_Stagiaire = "alice.dupont@example.com", MotDePasse_Stagiaire = "alice_password",image_Stagiaire="dotnet_bot.png" },
                new Stagiaire { nom_Stagiaire = "Bob", prenom_Stagiaire = "Martin", email_Stagiaire = "bob.martin@example.com", MotDePasse_Stagiaire = "bob_password",image_Stagiaire="dotnet_bot.png" },
                new Stagiaire { nom_Stagiaire = "Claire", prenom_Stagiaire = "Dubois", email_Stagiaire = "claire.dubois@example.com", MotDePasse_Stagiaire = "claire_password",image_Stagiaire="dotnet_bot.png" },
                new Stagiaire { nom_Stagiaire = "David", prenom_Stagiaire = "Garcia", email_Stagiaire = "david.garcia@example.com", MotDePasse_Stagiaire = "david_password",image_Stagiaire="dotnet_bot.png" },
                new Stagiaire { nom_Stagiaire = "Emma", prenom_Stagiaire = "Lefevre", email_Stagiaire = "emma.lefevre@example.com", MotDePasse_Stagiaire = "emma_password",image_Stagiaire="dotnet_bot.png" },
                new Stagiaire { nom_Stagiaire = "Fabien", prenom_Stagiaire = "Leroy", email_Stagiaire = "fabien.leroy@example.com", MotDePasse_Stagiaire = "fabien_password",image_Stagiaire="dotnet_bot.png" },
                new Stagiaire { nom_Stagiaire = "Gabrielle", prenom_Stagiaire = "Moreau", email_Stagiaire = "gabrielle.moreau@example.com", MotDePasse_Stagiaire = "gabrielle_password",image_Stagiaire="dotnet_bot.png" },
                new Stagiaire { nom_Stagiaire = "Hugo", prenom_Stagiaire = "Thomas", email_Stagiaire = "hugo.thomas@example.com", MotDePasse_Stagiaire = "hugo_password",image_Stagiaire="dotnet_bot.png" },
                new Stagiaire { nom_Stagiaire = "Ines", prenom_Stagiaire = "Dufour", email_Stagiaire = "ines.dufour@example.com", MotDePasse_Stagiaire = "ines_password",image_Stagiaire="dotnet_bot.png" },
                new Stagiaire { nom_Stagiaire = "Julie", prenom_Stagiaire = "Roux", email_Stagiaire = "julie.roux@example.com", MotDePasse_Stagiaire = "julie_password",image_Stagiaire="dotnet_bot.png" }
            };

            foreach (var stagiaire in stagiaires)
            {
                await _connection.InsertAsync(stagiaire);
            }

            // Ajout de 3 administrateurs
            var administrateurs = new List<Administrateur>
            {
                new Administrateur { Nom_Administrateur = "Redjradj", Prenom_Administrateur = "Juba", Email_Administrateur = "2286754@collegemv.qc.ca", MotDePasse_Administrateur = "admin1_password" },
                new Administrateur { Nom_Administrateur = "Issa", Prenom_Administrateur = "Aya", Email_Administrateur = "2283110@collegemv.qc.ca", MotDePasse_Administrateur = "admin2_password" },
                new Administrateur { Nom_Administrateur = "Chargui", Prenom_Administrateur = "Nadine", Email_Administrateur = "2283110@collegemv.qc.ca", MotDePasse_Administrateur = "admin3_password" }
            };

            foreach (var administrateur in administrateurs)
            {
                await _connection.InsertAsync(administrateur);
            }

            // Ajout de 5 stages
            var stages = new List<Stage>
            {
                new Stage { nom_stage = "Adminstrateur Réseau",     Compagnie_Stage = "Bel", email_stage = "Bel@gmail.com", IsDispo_stage = true, priceOffer_Stage = 30.50 ,image_Stage="dotnet_bot.png"},
                new Stage { nom_stage = "Programmeur Junior",       Compagnie_Stage = "Amazone", email_stage = "Amazone@gmail.com", IsDispo_stage = false, priceOffer_Stage = 45.50 ,image_Stage="dotnet_bot.png"},
                new Stage { nom_stage = "Testeur",                  Compagnie_Stage = "Ubisoft", email_stage = "Ubisoft@gmail.com", IsDispo_stage = true, priceOffer_Stage = 55,image_Stage="dotnet_bot.png" },
                new Stage { nom_stage = "Analyste Data",            Compagnie_Stage = "Google", email_stage = "Google@gmail.com", IsDispo_stage = true, priceOffer_Stage = 21 ,image_Stage="dotnet_bot.png"},
                new Stage { nom_stage = "Administrateur Système",   Compagnie_Stage = "Alkegen", email_stage = "Alkegen@gmail.com", IsDispo_stage = false, priceOffer_Stage = 19.50 ,image_Stage="dotnet_bot.png"}
            };

            foreach (var stage in stages)
            {
                await _connection.InsertAsync(stage);
            }
        }


    }
}

