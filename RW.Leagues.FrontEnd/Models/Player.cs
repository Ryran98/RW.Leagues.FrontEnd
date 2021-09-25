using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RW.Leagues.FrontEnd.Models
{
    [Table("tb_Player")]
    public class Player
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Country Country { get; set; }
        [Required]
        public int CountryId { get; set; }

        public int Rating { get; set; }
    }
}