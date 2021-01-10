using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Models
{
    [Table("Lekar")]
    public class Lekar{
        [Key]
        [Column("ID")]
        public int ID { get; set; }
        [Column("Ime")]
        [MaxLength(255)]
        public string Ime { get; set; }
        [Column("Prezime")]
        [MaxLength(255)]
        public string Prezime { get; set; }
        public Bolnica Bolnica { get; set; }
    }
}