namespace GameHub.Models
{
    public class Igrica
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public double SrednjaOcjena { get; set; }
        public string Autor { get; set; }
        public Zanr Zanr { get; set; }
        public bool RRated { get; set; }

        public Igrica() { }
    }
}
