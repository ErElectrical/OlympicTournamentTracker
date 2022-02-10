using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentTracker
{
    /// <summary>
    /// InterFace Created for DataConnection
    /// As according to my requirement I have to save My data at DB and Txt file
    /// </summary>
    public interface Idataconnection
    {
        PrizeModel CreatePrize(PrizeModel Model);

        PersonModel CreatePlayer(PersonModel Model);

        TeamModel CreateTeam(TeamModel Model);

        List<PersonModel> GetPerson_All();
    }
}
