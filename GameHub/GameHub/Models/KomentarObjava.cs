using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameHub.Models
{
    public class KomentarObjava
    {
        [Key]
        public int Id { get; set; }
        public string Tekst { get; set; }
        public int Lajkovi { get; set; }
        [ForeignKey("Objava")]
        public int ObjavaId { get; set; }

        public KomentarObjava() { }
    }
}
