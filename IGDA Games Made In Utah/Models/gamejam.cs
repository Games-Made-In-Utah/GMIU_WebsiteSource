namespace IGDA_Games_Made_In_Utah.Models
{
    public class GameJam
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string Host { get; set; }
        public DateTime StartDate { get; set; }  // Start Date
        public DateTime EndDate { get; set; }    // End Date
        public DateTime? VotingEndDate { get; set; }  // Optional Voting End Date
        public string Link { get; set; }
    }
}
