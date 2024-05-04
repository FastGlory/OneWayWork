using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Model
{

    [Table("Entreprise")]
    public class Entreprise
    {
        [PrimaryKey, AutoIncrement, Column("Id_Entreprise")]
        public int Id_Entreprise { get; set; }

        [Column("Nom_Entreprise")]
        public string? Nom_Entreprise { get; set; }

        [Column("Email_Entreprise")]
        public string? Email_Entreprise { get; set; }

        [Column("Image_Entreprise")]
        public string? Image_Entreprise { get; set; }

        [Column("MotDePasse_Entreprise")]
        public string? MotDePasse_Entreprise { get; set; }
        [Column("Description_Entreprise")]
        public string? Description_Entreprise { get; set; }
        [Column("IsAdmin")]
        public bool IsAdmin { get; set; } = false;
        [Ignore]
        public List<Stage> Stages { get; set; } = new List<Stage>();


    }

}