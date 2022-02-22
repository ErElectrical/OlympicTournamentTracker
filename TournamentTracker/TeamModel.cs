using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TournamentTracker
{
    
    public class TeamModel
    {

        public int Id { get; set;  }
        public string TeamName { get; set; }
        //instead of initiliase it trough constructor we do it with new keyword it self.
        public List<PersonModel> Teammembers { get; set; } = new List<PersonModel>();

        

         
    }
}