using System.Collections.Generic;
using RW.Leagues.FrontEnd.Models;

namespace RW.Leagues.FrontEnd.ViewModels.Event
{
    public class Detail
    {
        public Models.Event Event { get; set; }
        public List<AgeGroup> AgeGroups { get; set; }
    }
}