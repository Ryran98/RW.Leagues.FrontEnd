﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RW.Leagues.FrontEnd.Models
{
    [Table("tb_Player")]
    public class Player
    {
        public int Id { get; set; }
        [DisplayName("First Name")] public string FirstName { get; set; }
        [DisplayName("Last Name")] public string LastName { get; set; }
        [NotMapped] public string FullName => $"{FirstName} {LastName}";
        [DisplayName("Data of Birth")] public DateTime DateOfBirth { get; set; }
        public Country Country { get; set; }
        [Required] public int CountryId { get; set; }

        public int Rating { get; set; }
    }
}