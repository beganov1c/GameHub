namespace GameHub.Models
{
    public class KomentarIgrica : Komentar
    {
        public int Id { get; set; }
        public int Ocjena { get; set; }

        public KomentarIgrica() { }
    }
}
