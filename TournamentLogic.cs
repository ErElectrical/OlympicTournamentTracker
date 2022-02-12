using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentTracker
{
   public static class TournamentLogic
    {
        public static void CreateRounds(TournamentModel Model)
        {
            //Create a Randomized Team order so that match can fix randomly.
            List<TeamModel> randomizedTeams = RandomizedTeamOrder(Model.EnteredTeams);
            //Find number of rounds
            int rounds = FindNumberOfRounds(randomizedTeams.Count());
            //Find no. of byes
            int Byes = NumberOfByes(rounds, randomizedTeams.Count());
            // create First Round,First Round is special because at this time we know about all the teams 
            //that played in round
            Model.Rounds.Add(CreateFirstRound(Byes, randomizedTeams));
            //Create Rest of Rounds
            CreateOtherRounds(Model, rounds);
        }

        private static void CreateOtherRounds(TournamentModel Model, int rounds)
        
        {
            //initialize round to 2 as first round is already created.
            int round = 2;
            //List that contains previous round information
            List<MatchupModel> PreviousRound = Model.Rounds[0];
            //List that contain CurrentRound information.
            List<MatchupModel> CurrRound = new List<MatchupModel>();
            //it will  have information of both the teams that are competing in rounds
            MatchupModel currMatchup = new MatchupModel();

            while (round <= rounds)
            {
                foreach (MatchupModel Match in PreviousRound)
                {
                    //add the entry from Previous round to current round
                    currMatchup.Entries.Add(new MatchupEntryModel { ParentMatchup = Match });
                    
                    if(currMatchup.Entries.Count > 1)
                    {
                        //Initialie the Matchup round
                        currMatchup.MatchupRound = round;
                        //Add the Teams of Rounds to Curr round
                        CurrRound.Add(currMatchup);
                        //refresh the MatchupModel so that Enterd teams get clear from CurrMatchup.
                        currMatchup = new MatchupModel();
                    }

                }
                //Add the Round to currRound
                Model.Rounds.Add(CurrRound);
                //Pass currRound to PreviousRound for Next iteration
                PreviousRound = CurrRound;
                //refersh the CurrRound
                CurrRound = new List<MatchupModel>();
                round += 1;
            }
            
        }
        
        /// <summary>
        /// Crete FIrst Round
        /// get Byes and TeamModel
        /// create a list Of MatchUpModel that will work as a output for Method
        /// creete a another insatnce Of MatchupModel
        /// Traversing through TeamModel and add the team to Entries
        /// inside the Entry we have a MatchupEntryModel and we store the Team to TeamCompeting
        /// </summary>
        /// <param name="byes"></param>
        /// <param name="Teams"></param>
        /// <returns></returns>
        private static List<MatchupModel> CreateFirstRound(int byes,List<TeamModel> Teams)
        {
            List<MatchupModel> output = new List<MatchupModel>();
            MatchupModel curr = new MatchupModel();

            foreach(TeamModel Tm in Teams)
            {
                curr.Entries.Add(new MatchupEntryModel { TeamCompeting = Tm });
                if(byes > 0 || curr.Entries.Count > 1)
                {
                    curr.MatchupRound = 1;
                    output.Add(curr);
                    curr = new MatchupModel();
                    if( byes > 0)
                    {
                        byes--;
                    }
                }
            }
            return output;
        }
        private static int NumberOfByes(int round,int Teamcount)
        {
            int Output=0;
            int TotalTeams = 1;
            for(int i=1; i<=round;i++)
            {
                TotalTeams *= 2;
            }
            Output = TotalTeams - Teamcount;
            return Output;
        }
        private static int FindNumberOfRounds(int TeamCount)
        {
            int output = 1;
            int val = 2;
            while(val < TeamCount)
            {
                output += 1;
                val *= 2;

            }
            return output;
        }
        private static List<TeamModel> RandomizedTeamOrder(List<TeamModel> Teams)
        {
            //Guid genrate a uniquely identified id
            // id takes 16 bytes of memory
            // chances of duplication of id is very small around negligible
            var randomizedTeams = Teams.OrderBy(a => Guid.NewGuid()).ToList();
            return randomizedTeams;
                
        }
    }
}
