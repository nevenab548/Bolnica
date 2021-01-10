using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Server.Models
{
    [Table("Smena")]
    public class Smena
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }
        [Column("Broj")]
        public int Broj { get; set; }
        [Column("BrojSmene")]
        public int BrojSmene { get; set; }
        [Column("Lekar")]
        [MaxLength(255)]
        public string Lekar { get; set; }
        [JsonIgnore]
        public Bolnica Bolnica { get; set; }
    }
}