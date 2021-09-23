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
    }
}