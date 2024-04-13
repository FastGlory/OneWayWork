using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Model
{
    [Table("Stagiaire")]
    public class Stagiaire
    {
        [PrimaryKey]
        [AutoIncrement]
        [Column("Id_Stagiaire")]
        public int Id_Stagiaire { get; set; }
        [Column("Nom_Stagiaire")]
        public string? nom_Stagiaire { get; set; }
        [Column("Prenom_Stagiaire")]
        public string? prenom_Stagiaire { get; set; }
        [Column("Email_Stagiaire")]
        public string? email_Stagiaire { get; set; }
        [Column("Image_Stagiaire")]
        public string? image_Stagiaire { get; set; }
        [Column("MotDePasse_Stagiaire")]
        public string? MotDePasse_Stagiaire { get; set; }
        
    }
 
}
