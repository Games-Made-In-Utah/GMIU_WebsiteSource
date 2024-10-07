namespace IGDA_Games_Made_In_Utah.Models
{
    public class IndieDeveloper
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string Website { get; set; }
        public string ReleaseDate { get; set; } // Optional
        public string Developer { get; set; } // Optional
        public int Id { get; internal set; }
    }
}
