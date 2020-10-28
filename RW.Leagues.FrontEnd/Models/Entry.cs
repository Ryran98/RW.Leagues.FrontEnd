namespace RW.Leagues.FrontEnd.Models
{
    public class Entry
    {
        public int Id { get; set; }
        public Player Player { get; set; }
        public int PlayerId { get; set; }
        public Event Event { get; set; }
        public int EventId { get; set; }
    }
}