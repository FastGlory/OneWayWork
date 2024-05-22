using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Model
{
    [Table("Candidature")]
    public class Candidature
    {
        [PrimaryKey]
        [AutoIncrement]
        [Column("Id_Candidature")]
        public int Id_Candidature { get; set; }
        [Column("Description_Candidature")]
        public string? Description_Candidature { get; set; }
        [Column("Lien_Candidature")]
        public string? Lien_Candidature { get; set; }

        [Column("Document_Candidature")]
        public byte[] Document_Candidature { get; set; }


        [Column("Date_Candidature")]
        public DateTime? Date_Candidature { get; set; }

        [Column("Is_Draft‎")]
        public bool Is_Draft { get; set; } = false;

        [Column("Is_Accepted ‎")]
        public bool Is_Accepted { get; set; } = false;

        [Column("Is_Declined ‎")]
        public bool Is_Declined { get; set; } = false;

        [Column("StatusColor ‎")]
        public string? StatusColor { get; set; }


        [Column("Status ‎")]
        public string? Status { get; set; }


        [Column("IdSession")]  //Clé étrangère
        public string? IdSession { get; set; }


        [Column("Nom_Stage")]  // clee étrangère
        public string? Nom_Stage { get; set; }

        [Column("Nom_Stagiaire")]  // clee étrangère
        public string? nom_Stagiaire { get; set; }
        [Column("Prenom_Stagiaire")] //Clé étrangère
        public string? prenom_Stagiaire { get; set; }

    }

}
