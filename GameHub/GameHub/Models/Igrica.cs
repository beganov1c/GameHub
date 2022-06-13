using System.ComponentModel.DataAnnotations;

namespace GameHub.Models
{
    public class Igrica
    {
        [Key]
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public double SrednjaOcjena { get; set; }
        public string Autor { get; set; }
        [EnumDataType(typeof(Zanr))]
        public Zanr Zanr { get; set; }
        public bool RRated { get; set; }
        public string Slika { get; set; }
        public Igrica() { }
    }
}
