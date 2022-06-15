using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameHub.Models
{
    public class KomentarIgrica
    {
        [Key]
        public int Id { get; set; }
        public string Tekst { get; set; }
        [Range(0, 10)]
        public int Ocjena { get; set; }
        [ForeignKey("Igrica")]
        public int IgricaId { get; set; }

        [ForeignKey("AspNetUsers")]
        public string KorisnikId { get; set; }

        public KomentarIgrica() { }
    }
}
