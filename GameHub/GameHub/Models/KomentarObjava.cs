namespace GameHub.Models
{
    public class KomentarObjava : Komentar
    {
        public int Id { get; set; }
        public int Lajkovi { get; set; }

        public KomentarObjava() { }
    }
}
