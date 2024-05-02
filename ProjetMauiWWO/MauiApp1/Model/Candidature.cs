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
    public class Candidature
    {
        [PrimaryKey, AutoIncrement]
        public int Id_Candidature { get; set; }
        public string? Description_Candidature { get; set; }
        public string? Lien_Candidature { get; set; }
        public string? Document_Candidature { get; set; }
        public bool Is_Draft { get; set; } = false;
        public bool Is_Accepted { get; set; } = false;


        [ForeignKey(nameof(Stagiaire))]  // ForeignKey 
        public int Id_Stagiaire { get; set; }
        public Stagiaire Stagiaire { get; set; }




    }


}
