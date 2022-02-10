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
