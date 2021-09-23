using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RW.Leagues.FrontEnd.Models
{
    [Table("tb_Match")]
    public class Match
    {
        public int Id { get; set; }
        public Entry EntryA { get; set; }
        [Required]
        public int EntryAId { get; set; }
        public Entry EntryB { get; set; }
        [Required]
        public int EntryBId { get; set; }
        [Required]
        public int Round { get; set; }
        [Required]
        public int PlayerAGamesWon { get; set; }
        [Required]
        public int PlayerBGamesWon { get; set; }
        [Required]
        public string Game1Score { get; set; }
        [Required]
        public string Game2Score { get; set; }
        [Required]
        public string Game3Score { get; set; }
        public string Game4Score { get; set; }
        public string Game5Score { get; set; }

    }
}