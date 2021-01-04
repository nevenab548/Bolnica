using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bolnica.Models
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
        public int BrojSoba { get; set; }
        [Column("KapacitetSobe")]
        public int KapacitetSobe { get; set; }
        [Column("BrojSmena")]
        public int BrojSmena { get; set; }
        [Column("Sobe")]
        public virtual List<Soba> Sobe { get; set; }
        [Column("Smene")]
        public virtual List<Smena> Smene { get; set; }

    }
}