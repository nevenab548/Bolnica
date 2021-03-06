using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Models
{
    [Table("Bolnica")]
    public class Bolnica
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }
        [Column("Naziv")]
        [MaxLength(255)]
        public string Naziv { get; set; }
        [Column("BrojSoba")]
        [DataType("number")]
        public int BrojSoba { get; set; }
        [Column("KapacitetSobe")]
        [DataType("number")]
        public int KapacitetSobe { get; set; }
        [Column("Usmeni")]
        [DataType("number")]
        public int USmeni { get; set; }
        public virtual List<Soba> Sobe { get; set; }
        public virtual List<Smena> Smene { get;set; }
        public virtual List<Lekar> Lekari{get;set;}
        
    }
}