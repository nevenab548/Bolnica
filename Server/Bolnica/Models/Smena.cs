using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Bolnica.Models
{
    public class Smena
    {
        [Key]
        [Column("BrojSmene")]
        public int BrojSmene { get; set; }
        [Column("Broj")]
        public int Broj { get; set; }
        [Column("Lekar")]
        [MaxLength(255)]
        public string Lekar { get; set; }
        [JsonIgnore]
        public Bolnica Bolnica{get;set;}
    }
}