using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RW.Leagues.FrontEnd.Models
{
    [Table("tb_Rank")]
    public class Rank
    {
        public int Id { get; set; }
        public Player Player { get; set; }
        [Required]
        public int PlayerId { get; set; }
        public AgeGroup AgeGroup { get; set; }
        [Required]
        public int AgeGroupId { get; set; }
        public int EventCount { get; set; }
        public double Points { get; set; }
        [Required]
        public DateTime UpdatedAt { get; set; }
    }
}