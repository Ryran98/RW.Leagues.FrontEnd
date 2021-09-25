using System.ComponentModel.DataAnnotations.Schema;

namespace RW.Leagues.FrontEnd.Models
{
    [Table("tb_Country")]
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}