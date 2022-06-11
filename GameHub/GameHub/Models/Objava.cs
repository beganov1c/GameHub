using System.ComponentModel.DataAnnotations;

namespace GameHub.Models
{
    public class Objava
    {
        [Key]
        public int Id { get; set; }
        public string Tekst { get; set; }
        public int Lajkovi { get; set; }

        public Objava() { }
    }
}
