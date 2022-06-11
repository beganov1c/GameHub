namespace GameHub.Models
{
    public class Objava
    {
        public int Id { get; set; }
        public string Tekst { get; set; }
        public int Lajkovi { get; set; }
        public int VlasnikId { get; set; }

        public Objava() { }
    }
}
