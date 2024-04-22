using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Model
{
    [Table("Administrateur")]
    public class Administrateur
    {
        [PrimaryKey]
        [AutoIncrement]
        [Column("Id_Administrateur")]
        public int Id_Administrateur { get; set; }

        [Column("Nom_Administrateur")]
        public string? Nom_Administrateur { get; set; }

        [Column("Prenom_Administrateur")]
        public string? Prenom_Administrateur { get; set; }

        [Column("Email_Administrateur")]
        public string? Email_Administrateur { get; set; }

        [Column("MotDePasse_Administrateur")]
        public string? MotDePasse_Administrateur { get; set; }

        [Column("IsAdmin")]
        public bool IsAdmin { get; set; } = true; // Par défaut, tous les administrateurs seront considérés comme des administrateurs
    }
}
