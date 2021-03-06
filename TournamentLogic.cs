using System;
using System.Collections.Generic;
using System.Configuration;
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
            UpdateTournamentsResult(Model);
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

                        if (currMatchup.Entries.Count > 1)
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
            private static List<MatchupModel> CreateFirstRound(int byes, List<TeamModel> Teams)
            {
                List<MatchupModel> output = new List<MatchupModel>();
                MatchupModel curr = new MatchupModel();

                foreach (TeamModel Tm in Teams)
                {
                    curr.Entries.Add(new MatchupEntryModel { TeamCompeting = Tm });
                    if (byes > 0 || curr.Entries.Count > 1)
                    {
                        curr.MatchupRound = 1;
                        output.Add(curr);
                        curr = new MatchupModel();
                        if (byes > 0)
                        {
                            byes--;
                        }
                    }
                }
                return output;
            }
            private static int NumberOfByes(int round, int Teamcount)
            {
                int Output = 0;
                int TotalTeams = 1;
                for (int i = 1; i <= round; i++)
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
                while (val < TeamCount)
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

            public static void UpdateTournamentsResult(TournamentModel model)
            {
            int startingRound = model.CheckCurrentRound();
            List<MatchupModel> toscore = new List<MatchupModel>();
            foreach(List<MatchupModel> round in model.Rounds)
            {
                foreach(MatchupModel rm in round)
                {
                    if(rm.winner == null &&
                    rm.Entries.Any(x => x.Score != 0) ||
                    rm.Entries.Count == 1)
                    {
                        toscore.Add(rm);
                    }
                }
            }
                MarkingWinnerMatchups(toscore);
                AdvanceWinner(toscore,model);
                SqlDataConnection sql = new SqlDataConnection();
                toscore.ForEach(x => sql.UpdateMatchup(x));
                int endingRound = model.CheckCurrentRound();
                if(endingRound > startingRound)
                {
                   model.AlertUsersToNewRound();
                }

            }
            
        public static void AlertUsersToNewRound(this TournamentModel model)
        {
            int currentRoundNumber = model.CheckCurrentRound();
            List<MatchupModel> currentRound = model.Rounds.Where(x => x.First().MatchupRound == currentRoundNumber).First();
            foreach(MatchupModel matchup in currentRound)
            {
                foreach(MatchupEntryModel me in matchup.Entries)
                {
                    foreach(PersonModel p in me.TeamCompeting.Teammembers)
                    {
                        AlertPersonToNewRound(p, me.TeamCompeting.TeamName, matchup.Entries.Where(x => x.TeamCompeting != me.TeamCompeting).FirstOrDefault());
                    }
                }
            }
        }
        
        private static void AlertPersonToNewRound(PersonModel p,string teamName,MatchupEntryModel competitor)
        {
            if(p.Email.Length == 0)
            {
                return;
            }
            string fromAddress = " ";
            string to = " ";
            string subject = " ";
           
            StringBuilder body = new StringBuilder();
            if(competitor != null)
            {
                subject = $" you have a new matchup with {competitor.TeamCompeting.TeamName}";
                body.AppendLine("<h1>You have a new matchup</h1>");
                body.AppendLine("<strong>competitor : </strong>");
                body.AppendLine(competitor.TeamCompeting.TeamName);
                body.AppendLine();
                body.AppendLine();
                body.AppendLine("Have a great time!");
                body.AppendLine("~Tournament Tracker");

            }
            else
            {
                subject = $"You have a bye week this round";
                body.AppendLine("Enjoy your round off");
                body.AppendLine("~Tournament Tracker");
            }

            to =p.Email;
            fromAddress = ConnectionConfig.AppKeyLookup("senderEmail");

            EmailLogic.SendEmail(fromAddress, to, subject, body.ToString());
        }
            private static int CheckCurrentRound(this TournamentModel model)
            {
                int output = 1;
                foreach(List<MatchupModel> round in model.Rounds)
                {
                    if(round.All(x =>x.winner != null))
                    {
                        output++;
                    }
                    else
                    {
                    return output;
                    }
                
                }
                return output;
                SqlDataConnection sql = new SqlDataConnection();
                sql.CompleteTournament(model);
                return output - 1;




        }

        private static void CompleteTournament(TournamentModel model)
        {
            SqlDataConnection sql = new SqlDataConnection();
            sql.CompleteTournament(model);
            TeamModel winners = model.Rounds.Last().First().winner;
            TeamModel runnerup = model.Rounds.Last().First().Entries.Where(x => x.TeamCompeting != winners).First().TeamCompeting;
            PrizeModel firstPlacePrize = model.prizes.Where(x => x.PlaceNumber == 1).FirstOrDefault();
            PrizeModel secondPlacePrie = model.prizes.Where(x => x.PlaceNumber == 2).FirstOrDefault();

            decimal totalincome = model.EnteredTeams.Count * model.EntryFees;
            decimal winnerPrize = 0;
            decimal runnerupperPrize = 0;


            if (model.prizes.Count() > 0)
            {
                
                if(firstPlacePrize != null)
                {
                    winnerPrize = firstPlacePrize.calculatePrizePayout(totalincome);
                }
                if(secondPlacePrie != null)
                {
                    runnerupperPrize = secondPlacePrie.calculatePrizePayout(totalincome);
                }
               


            }
            //send Email to all tournament
            string subject = " ";

            StringBuilder body = new StringBuilder();
          
            subject =$"In { model.TournamentName },{ winners.TeamName } has won";

            body.AppendLine("<h1>We have a WINNER </h1>");
            body.AppendLine("<strong>Congratulation to our winner on a great tournament </strong>");

            body.AppendLine("<br />");
            if(winnerPrize > 0)
            {
                body.AppendLine($" {winners.TeamName} will recive { winnerPrize }</p>");

            }
            if(runnerupperPrize > 0)
            {
                body.AppendLine($"<p> {runnerup.TeamName} will reciev { runnerupperPrize }");
            }

            body.AppendLine($"<p> Thanks all to great tournament</p>");
            body.AppendLine("~Tournament Tracker ");

            List<string> bcc = new List<string>();
            foreach( TeamModel t in model.EnteredTeams)
            {
                foreach(PersonModel p in t.Teammembers)
                {
                    if(p.Email.Length > 0)
                    {
                        bcc.Add(p.Email);
                    }
                }
            }
            EmailLogic.SendEmail(new List<string>(), bcc, subject, body.ToString());

            //CompleteTournaemnt
            model.CompleteTournament();

            

        }

        private static decimal calculatePrizePayout(this PrizeModel prize,decimal totalIncome)
        {
            decimal output = 0;
            if(prize.PrizeAmount > 0 )
            {
                output = prize.PrizeAmount;
            }
            else
            {
                output = decimal.Multiply(totalIncome , Convert.ToDecimal(prize.PrizePercentage / 100));



            }
            return output;
        }
        private static  void AdvanceWinner(List<MatchupModel> model,TournamentModel tournaments)
            {
                foreach(MatchupModel m in model)
                {
                    foreach(List<MatchupModel> round in tournaments.Rounds )
                    {
                        foreach(MatchupModel rm in round)
                        {
                            foreach(MatchupEntryModel me in rm.Entries)
                            {
                                if(me.ParentMatchup != null)
                                {
                                    if(me.ParentMatchup.id == m.id)
                                    {
                                        me.TeamCompeting = m.winner;
                                        SqlDataConnection sql = new SqlDataConnection();
                                        sql.UpdateMatchup(rm);


                                    }
                                }
                            }
                        }
                    }
                }
            }
            private static void MarkingWinnerMatchups(List<MatchupModel> model)
            {
                string greaterWins = ConfigurationManager.AppSettings["greaterWins"];
                foreach (MatchupModel m in model)
                {

                    if(m.Entries.Count == 1)
                    {
                        m.winner = m.Entries[0].TeamCompeting;
                        continue;
                    
                    }

                    // 0 means false,or low score wins
                    if (greaterWins == "0")
                    {
                        if (m.Entries[0].Score < m.Entries[1].Score)
                        {
                            m.winner = m.Entries[0].TeamCompeting;
                        }
                        else if(m.Entries[1].Score < m.Entries[0].Score)
                        {
                            m.winner = m.Entries[1].TeamCompeting;

                        }
                        else
                        {
                            throw new Exception("we do not allow tie in games");
                        }


                    }
                    else
                    {
                    //1 means true or high score wins
                        if (m.Entries[0].Score > m.Entries[1].Score)
                        { 
                            m.winner = m.Entries[0].TeamCompeting;
                        }
                        else if (m.Entries[1].Score > m.Entries[0].Score)
                        {
                            m.winner = m.Entries[1].TeamCompeting;

                        }
                        else
                        {
                            throw new Exception("we do not allow tie in games");
                        }


                    }
                }
            }
        }
    }

