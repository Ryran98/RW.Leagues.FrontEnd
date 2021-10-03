using System.ComponentModel.DataAnnotations.Schema;

namespace RW.Leagues.FrontEnd.Models
{
    [Table("tb_AgeGroup")]
    public class AgeGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}