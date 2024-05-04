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
        [Column("Lien_Candidature ")]
        public string? email_Stagiaire { get; set; }
        [Column("Document_Candidature")]
        public byte[] Document_Candidature { get; set; }

        [Column("Is_Draft‎")] 
        public bool Is_Draft { get; set; } = false;

        [Column("Is_Accepted ‎")] 
        public bool Is_Accepted { get; set; } = false;

        [Column("IdSession")]  //Clé étrangère
        public string? IdSession { get; set; }


    }

}
