using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RW.Leagues.FrontEnd.Models
{
    [Table("tb_Entry")]
    public class Entry
    {
        public int Id { get; set; }
        public Player Player { get; set; }
        [Required]
        public int PlayerId { get; set; }
        public Event Event { get; set; }
        [Required]
        public int EventId { get; set; }
        public AgeGroup AgeGroup { get; set; }
        [Required]
        public int AgeGroupId { get; set; }
        public int? SeedNumber { get; set; }
    }
}