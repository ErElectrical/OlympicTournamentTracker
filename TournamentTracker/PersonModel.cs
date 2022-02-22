using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentTracker
{
    public class PersonModel
    {
        /// <summary>
        /// Uniquely identify each player 
        /// </summary>
        public int id { get; set; }


        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string  Email { get; set; }

        public string CellPhoneNumber { get; set; }

        /// <summary>
        /// varible is read only type 
        /// </summary>
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
    }
}
