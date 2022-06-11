namespace GameHub.Models
{
    public abstract class Komentar
    {
        public int Id { get; set; }
        public int VlasnikID { get; set; }
        public string Tekst { get; set; }

        public Komentar() { }
    }
}
