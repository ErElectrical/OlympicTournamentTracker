using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TournamentTracker
{
    public static class TextDataConnectionProcessor
    {
        public static string FullFilePath(this string fileName)
        {
            //$ sign is use for InterPolating string
            //just opposite when we use @
            return $"{ConfigurationManager.AppSettings["Filapath"]}\\{fileName}";
        }

        public static List<string> LoadFile(this string file)
        {
           if(!File.Exists(file))
            {
                return new List<string>();
            }
            return File.ReadAllLines(file).ToList();

        }

        public static List<PrizeModel> ConvertToPrizeModel(this List<string> lines)
        {
            List<PrizeModel> Output = new List<PrizeModel>();

            foreach(string line in lines)
            {
                string[] cols = line.Split(',');
                PrizeModel p = new PrizeModel();
                p.Id = int.Parse(cols[0]);
                p.PlaceNumber = int.Parse(cols[1]);
                p.PlaceName = cols[2];
                p.PrizeAmount = decimal.Parse(cols[3]);
                p.PrizePercentage = double.Parse(cols[4]);
                Output.Add(p);

            }
            return Output;
        }

        public static List<MatchupEntryModel> ConvertToMatchupEntryModel(this List<string> lines)
        {
            List<MatchupEntryModel> output = new List<MatchupEntryModel>();
            foreach(string line in lines)
            {
                string[] cols = line.Split(',');
                MatchupEntryModel Me = new MatchupEntryModel();
                Me.Id = int.Parse(cols[0]);
                Me.TeamCompeting = LookTeamById(int.Parse(cols[1]));
                Me.Score = double.Parse(cols[2]);
                //But ParentMatchup can be null 
                //during first Matchup it will always null at that time our logic crash to fix it
                //we have to check first weather the id is null or not.
                int ParentId = 0;
                if (int.TryParse(cols[3], out ParentId))
                {
                    Me.ParentMatchup = LookMatchupById(ParentId);
                }
                else
                {
                    Me.ParentMatchup = null;
                }
                output.Add(Me);

            }
            return output;
        }

        public static List<PersonModel> ConvertToPersonModel(this List<string> lines)
        {
            List<PersonModel> Model = new List<PersonModel>();

            foreach(string Line in lines)
            {
                string[] cols = Line.Split(',');
                PersonModel p = new PersonModel();
                p.id = int.Parse(cols[0]);
                p.FirstName = cols[1];
                p.LastName = cols[2];
                p.Email = cols[3];
                p.CellPhoneNumber =cols[4];
                Model.Add(p);
            }
            return Model;
        }

        public static List<TeamModel> ConvertToTeamModels(this List<string> lines, string PeopleFileName)
        {
            List<TeamModel> Output = new List<TeamModel>();
            List<PersonModel> People = PeopleFileName.FullFilePath().LoadFile().ConvertToPersonModel();

            foreach(string line in lines)
            {
                string[] cols = line.Split(',');
                TeamModel tm = new TeamModel();
                tm.Id = int.Parse(cols[0]);
                tm.TeamName = cols[1];

                string[] peopleId = cols[2].Split('|');
                foreach(string id in peopleId)
                {
                    tm.Teammembers.Add(People.Where(x => x.id == int.Parse(id)).First());
                }
                Output.Add(tm);
            }
            

            return Output;
        }

        public static List<TournamentModel> ConvertToTournamentsModel(this List<string> lines,
            string TeamModelFileName,
            string PersonModelFileName,
            string PrizeFileName)
        {
            //LayOut for Tournament Text File
            //id,TournamentsNames,Entry fees,(id|id - Entred Teams),(id|id|id -- Prizes),(Rounds -- id^id^id|id^id|)

            List<TournamentModel> Output = new List<TournamentModel>();
            List<TeamModel> Teams = TeamModelFileName.FullFilePath().LoadFile().ConvertToTeamModels(PersonModelFileName);
            List<PrizeModel> Prizes = PrizeFileName.FullFilePath().LoadFile().ConvertToPrizeModel();
            List<MatchupModel> matchup = ConnectionConfig.MatchupModelFile.FullFilePath().LoadFile().ConvertToMatchupModel();

            foreach(string line in lines)
            {
                string[] cols = line.Split(',');
                TournamentModel Tm = new TournamentModel();
                Tm.Id = int.Parse(cols[0]);
                Tm.TournamentName = cols[1];
                Tm.EntryFees = decimal.Parse(cols[2]);

                string[] TeamIds = cols[3].Split('|');
                foreach(string id in TeamIds)
                {
                    Tm.EnteredTeams.Add(Teams.Where(x => x.Id == int.Parse(id)).First());
                }
                if (cols[4].Length > 0)
                {
                    string[] PrizeId = cols[4].Split('|');
                    foreach (string id in PrizeId)
                    {
                        Tm.prizes.Add(Prizes.Where(x => x.Id == int.Parse(id)).First());
                    }
                }

                //Todo - Write code for Rounds as well

                string[] rounds = cols[5].Split('|');
               

                foreach (string round in rounds)
                {
                    string[] mstext = round.Split('^');
                    List<MatchupModel> ms = new List<MatchupModel>();

                    foreach (string matchupmodeltextId in mstext)
                    {
                        ms.Add(matchup.Where(x => x.id == int.Parse(matchupmodeltextId)).First());
                    }
                    Tm.Rounds.Add(ms);
                }


                Output.Add(Tm);
            }
            return Output;
        }
        public static void SaveToPrizeFile(this List<PrizeModel> Model, string fileName)
        {
            List<string> lines = new List<string>();
            foreach(PrizeModel p in Model)
            {
                lines.Add($"{ p.Id },{ p.PlaceNumber },{ p.PlaceName },{ p.PrizeAmount },{ p.PrizePercentage }");
            }
            File.WriteAllLines(fileName.FullFilePath(), lines);
        }

        public static void SaveToPersonFile(this List<PersonModel> Model,string fileName)
        {
            List<String> lines = new List<string>();
            foreach(PersonModel p in Model)
            {
                lines.Add($"{ p.id },{ p.FirstName },{ p.LastName },{ p.Email },{ p.CellPhoneNumber }");
            }
            File.WriteAllLines(fileName.FullFilePath(), lines);
        }

        public static void SaveToTeamModelFile(this List<TeamModel> Model,string filename)
        {
            List<string> lines = new List<string>();
            
            foreach(TeamModel tm in Model)
            {
                lines.Add($" { tm.Id },{ tm.TeamName },{ convertPeopleListToString(tm.Teammembers) }");
            
            }
            File.WriteAllLines(filename.FullFilePath(), lines);
        }

        public static void SaveRoundsTofile( this TournamentModel Model, string MatchupEntryModelFile,string MatchupModelFile)
        {
            //Loop through each round
            foreach(List<MatchupModel> round in Model.Rounds)
            {
                //Loop through each Model
                foreach(MatchupModel Matchup in round)
                {
                    //Load all Matchup from the file
                    //Get the top id and add one
                    //store the id
                    //store the Matchup record
                    Matchup.SaveMatchuptofile(MatchupModelFile, MatchupEntryModelFile);
                }

            }
            //Loop through each Model
            //Get the id for the new Matchup and save record
            //Loop through each Entry and save id of it


        }
        private static List<MatchupEntryModel> ConvertStringToMatchupEntryModel(string input)
        {
            string[] ids = input.Split('|');
            List<MatchupEntryModel> output = new List<MatchupEntryModel>();
            List<MatchupEntryModel> entries = ConnectionConfig.MatchupEntryModelFile.FullFilePath().LoadFile().ConvertToMatchupEntryModel();
            
            foreach(string id in ids)
            {
                output.Add(entries.Where(x => x.Id == int.Parse(id)).First());
                    
            }
            return output;

        }
        private static TeamModel LookTeamById(int id)
        {
            List<string> teams = ConnectionConfig.TeamModelFile.
                FullFilePath().
                LoadFile();
                
               
                
            foreach(string team in teams)
            {
                string[] cols = team.Split(',');
                if(cols[0] == id.ToString())
                {
                    List<string> matchingTeams = new List<string>();
                    matchingTeams.Add(team);
                    return matchingTeams.ConvertToTeamModels(ConnectionConfig.PersonFile).First();
                }

            }
            return null;
        }

        private static MatchupModel LookMatchupById(int id)
        {
            List<string> matchups = ConnectionConfig.MatchupModelFile.FullFilePath().LoadFile();
            foreach(string matchup in matchups)
            {
                string[] cols = matchup.Split(',');
                if(cols[0] == id.ToString())
                {
                    List<string> matchingmatchups = new List<string>();
                    matchingmatchups.Add(matchup);
                    return matchingmatchups.ConvertToMatchupModel().First();
                }
                
            }
            return null;
        }

        public static List<MatchupModel> ConvertToMatchupModel(this List<string> lines)
        {
            //id=0,Entries=1(pipe delimited by id),winner=2,Matchupround=3
            List<MatchupModel> output = new List<MatchupModel>();

            foreach(string line in lines)
            {
                string[] cols = line.Split(',');
                MatchupModel p = new MatchupModel();
                p.id = int.Parse(cols[0]);
                p.Entries = ConvertStringToMatchupEntryModel(cols[1]);
                p.winner = LookTeamById(int.Parse(cols[2]));
                p.MatchupRound = int.Parse(cols[3]);
                output.Add(p);
            }
            return output;
        }
        public static void SaveMatchuptofile(this MatchupModel Matchup,string MatchupModelFile,string MatchupEntryModelFile)
        {
            List<MatchupModel> matchups = MatchupModelFile.FullFilePath().LoadFile().ConvertToMatchupModel();
            int currentId = 1;
            if(matchups.Count > 0)
            {
                currentId = matchups.OrderByDescending(x => x.id).First().id + 1;
            }
            Matchup.id = currentId;
            foreach(MatchupEntryModel Entry in Matchup.Entries)
            {
                Entry.SaveEntryToFile(MatchupEntryModelFile);
            }


            List<string> lines = new List<string>();

            foreach(MatchupModel m in matchups)
            {
                string winner = " ";
                if(m.winner != null)
                {
                    winner = m.winner.Id.ToString();
                }
                lines.Add($"{ m.id },{ ConvertMatchupEntryListToString(m.Entries) },{ winner },{ m.MatchupRound }");
            }
            File.WriteAllLines(ConnectionConfig.MatchupModelFile.FullFilePath(), lines);

        }

        public static void SaveEntryToFile(this MatchupEntryModel MatchupEntry,string MatchupEntryModelFile)
        {
            List<MatchupEntryModel> entries = MatchupEntryModelFile.FullFilePath().LoadFile().ConvertToMatchupEntryModel();
            int currentId = 1;
            if(entries.Count > 0)
            {
                currentId = entries.OrderByDescending(x => x.Id).First().Id + 1;
            }
            MatchupEntry.Id = currentId;
            entries.Add(MatchupEntry);

            List<string> lines = new List<string>();
            foreach(MatchupEntryModel e in entries)
            {
                string ParentMatchupid = " ";
                if(e.ParentMatchup != null)
                {
                    ParentMatchupid = e.ParentMatchup.id.ToString();
                }
                lines.Add($"{ e.Id },{ e.TeamCompeting.Id },{ e.Score },{ ParentMatchupid }");
            }

            //save to file

            File.WriteAllLines(MatchupEntryModelFile.FullFilePath(), lines);
        }

        public static void SaveToTournamentModelFile(this List<TournamentModel>Model,string TournamentModelFileName)
        {
            List<string> lines = new List<string>();
            foreach(TournamentModel Tm in Model)
            {
                lines.Add($@"{ Tm.Id },{ Tm.TournamentName },{ Tm.EntryFees },{ ConvertTeamListsToString(Tm.EnteredTeams)  },{ ConvertPrizeListsToString(Tm.prizes)},{ ConvertRoundListsToString(Tm.Rounds) }");

                  
            }
            File.WriteAllLines(TournamentModelFileName.FullFilePath(), lines);
        }

        private static string ConvertRoundListsToString(List<List<MatchupModel>> Model)
            
        {
            string OutPut = " ";
            if (Model.Count == 0)
            {
                return "";
            }
            foreach(List<MatchupModel> rounds in Model)
            {
                OutPut += $"{ConvertMatchUpListToString(rounds)}";
            }
            OutPut = OutPut.Substring(0, OutPut.Length - 1);
            return OutPut;

        }

        private static string ConvertMatchUpListToString(List<MatchupModel> Matchup)
        {
            string OutPut = " ";
            if (Matchup.Count == 0)
            {
                return "";
            }
            foreach (MatchupModel Tm in Matchup)
            {
                OutPut += $"{ Tm.id }^";
            }
            OutPut = OutPut.Substring(0, OutPut.Length - 1);
            return OutPut;

        }
        private static string ConvertMatchupEntryListToString(List<MatchupEntryModel> entries)
        {
            string output = " ";
            if(entries.Count == 0)
            {
                return " ";
            }
            foreach(MatchupEntryModel e in entries)
            {
                output += $"{ e.Id }|";
            }
            output = output.Substring(0, output.Length - 1);
            return output;
        }
        private static string ConvertPrizeListsToString(List<PrizeModel> Model)
        {
            string OutPut = " ";
            if (Model.Count == 0)
            {
                return "";
            }
            foreach (PrizeModel Tm in Model)
            {
                OutPut += $"{ Tm.Id }|";
            }
            OutPut = OutPut.Substring(0, OutPut.Length - 1);
            return OutPut;

        }

        private static string ConvertTeamListsToString(List<TeamModel> Model)
        {
            string OutPut = " ";
            if(Model.Count == 0)
            {
                return "";
            }
            foreach(TeamModel Tm in Model)
            {
                OutPut += $"{ Tm.Id }|";
            }
            OutPut = OutPut.Substring(0, OutPut.Length - 1);
            return OutPut;

        }
        private static  string convertPeopleListToString(List<PersonModel> Model)
        {
            string Output = " ";
            if (Model.Count == 0)
            {
                return "";
            }
            foreach(PersonModel p in Model)
            {
                Output += $"{ p.id }|";
            }

            // to remove the | at last id we inserted
            Output = Output.Substring(0, Output.Length - 1);
            return Output;
            

        }

        public static void UpdateMatchupToFile(this MatchupModel matchup)
        {
            List<MatchupModel> matchups = ConnectionConfig.MatchupModelFile.FullFilePath().LoadFile().ConvertToMatchupModel();
            MatchupModel oldmatchup = new MatchupModel();
            foreach (MatchupModel m in matchups)
            {
                if (m.id == matchup.id)
                {
                    oldmatchup = m;
                }
            }
            matchups.Remove(oldmatchup);
            matchups.Add(matchup);
            foreach (MatchupEntryModel me in matchup.Entries)
            {
                UpdateEntryToFile(me);
            }

            //save to file
            List<string> lines = new List<string>();

            foreach (MatchupModel m in matchups)
            {
                string winner = " ";
                if (m.winner != null)
                {
                    winner = m.winner.Id.ToString();

                }
                lines.Add($"{ m.id },{ ConvertMatchupEntryListToString(m.Entries) },{ winner},{ m.MatchupRound }");
            }
            File.WriteAllLines(ConnectionConfig.MatchupModelFile.FullFilePath(), lines);

        }


        public static void UpdateEntryToFile(this MatchupEntryModel MatchupEntry)
        {
            List<MatchupEntryModel> entries = ConnectionConfig.MatchupEntryModelFile.FullFilePath().LoadFile().ConvertToMatchupEntryModel();
            MatchupEntryModel oldentry = new MatchupEntryModel();
            foreach(MatchupEntryModel e in entries)
            {
                if(e.Id == MatchupEntry.Id)
                {
                    oldentry = e;
                }
            }
            entries.Remove(oldentry);
            entries.Add(MatchupEntry);

            List<string> lines = new List<string>();
            foreach (MatchupEntryModel e in entries)
            {
                string ParentMatchupid = " ";
                if (e.ParentMatchup != null)
                {
                    ParentMatchupid = e.ParentMatchup.id.ToString();
                }
                lines.Add($"{ e.Id },{ e.TeamCompeting.Id },{ e.Score },{ ParentMatchupid }");
            }

            //save to file

            File.WriteAllLines(ConnectionConfig.MatchupEntryModelFile.FullFilePath(), lines);
        }


    }
}
