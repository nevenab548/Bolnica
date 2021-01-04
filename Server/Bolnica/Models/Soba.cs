using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Bolnica.Models
{
    [Table("Soba")]
    public class Soba
    {
    [Key]
    [Column("Broj sobe")]
    public int BrojSobe { get; set; }
    [Column("Odelenje")]
    [MaxLength(255)]
    public string Odelenje { get; set; }
    [Column("Primljeni")]
    public int Primljeni { get; set; }
    [Column("MaxPrimljeni")]
    public int MaxPrimljeni { get; set; }
    [Column("Hitno")]
    public bool Hitno { get; set; }
    [Column("Pacijenti")]
    public string Pacijenti { get; set; }
    [JsonIgnore]
    public Bolnica Bolnica{get;set;}
    }
}