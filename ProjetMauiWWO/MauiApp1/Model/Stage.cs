using SQLite;
using System;

namespace MauiApp1.Model
{
    [Table("Stage")]
    public class Stage
    {
        [PrimaryKey, AutoIncrement, Column("Id_Stage")]
        public int Id_Stage { get; set; }

        [Column("Nom_Stage")]
        public string? Nom_Stage { get; set; }

        [Column("Dispo_Stage")]
        public bool? IsDispo_Stage { get; set; }

        [Column("Image_Stage")]
        public string? Image_Stage { get; set; }

        [Column("Salaire_Stage")]
        public double? Salaire_Stage { get; set; }

        [Column("Description_Stage")]
        public string? Description_Stage { get; set; }

        [Column("Id_Entreprise")] // Clé étrangère
        public int Id_Entreprise { get; set; }
 
            
        // Propriété de navigation
        [Ignore] // Ignore les autres attributs de entreprise (overload initule)
        public Entreprise Entreprise { get; set; }
    }
}
