using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RW.Leagues.FrontEnd.Models
{
    [Table("tb_Event")]
    public class Event
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public EventType Type { get; set; }
        [Required]
        public int TypeId { get; set; }
        public List<Entry> Entries { get; set; }
    }
}