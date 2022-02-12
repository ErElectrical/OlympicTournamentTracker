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

                string[] PrizeId = cols[4].Split('|');
                foreach(string id in PrizeId)
                {
                    Tm.prizes.Add(Prizes.Where(x => x.Id == int.Parse(id)).First());
                }

                //Todo - Write code for Rounds as well

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

        public static void SaveToTournamentModelFile(this List<TournamentModel>Model,string TournamentModelFileName)
        {
            List<string> lines = new List<string>();
            foreach(TournamentModel Tm in Model)
            {
                lines.Add($@"{ Tm.Id },
                             { Tm.TournamentName },
                             { Tm.EntryFees },
                             { ConvertTeamListsToString(Tm.EnteredTeams)  },
                             { ConvertPrizeListsToString(Tm.prizes)},

                          
                             { ConvertRoundListsToString(Tm.Rounds) }");
                  
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
    }
}
