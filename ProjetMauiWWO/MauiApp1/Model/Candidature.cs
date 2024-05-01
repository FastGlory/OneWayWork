using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace MauiApp1.Model
{
    [Table("Candidature")]
    public class Candidature
    {
        [SQLite.Column, AutoIncrement, Column("idCandidature")]
        public int Id_Candidature { get; set; }

        [Column("DescriptionCandidature")]
        public string Description_Candidature { get; set; }


        [Column("LienCandidature")]
        public string Lien_Candidature { get; set; }


        [Column("DocumentCandidature")]
        public string Document_Candidature { get; set; }



    }


}
