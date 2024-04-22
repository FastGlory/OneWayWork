using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Model
{
    [Table("Stage")]
    public class Stage
    {
        [PrimaryKey]
        [AutoIncrement]
        [Column("Id_Stage")]
        public int Id_stage { get; set; }
        [Column("Nom_Stage")]
        public string? nom_stage { get; set; }
        [Column("Compagnie_Stage")]
        public string? Compagnie_Stage { get; set; }
        [Column("Email_Stage")]
        public string? email_stage { get; set; }
        [Column("Dispo_Stage")]
        public bool? IsDispo_stage { get; set; }
        [Column("Image_Stage")]
        public string? image_Stage { get; set; }
        [Column("Salaire_Stage")]
        public double priceOffer_Stage { get; set; }




    }
}