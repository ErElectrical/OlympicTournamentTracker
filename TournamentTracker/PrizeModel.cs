using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentTracker
{
    public class PrizeModel
    {
        /// <summary>
        /// Represents the PlaceNumber for Prize
        /// </summary>
        
        public int Id { get; set; }
        public int  PlaceNumber { get; set; }
        /// <summary>
        /// Presents the Placename for Prize 
        /// </summary>
        public  string PlaceName { get; set; }

        /// <summary>
        /// Amount of the Prize
        /// </summary>
        public decimal PrizeAmount { get; set; }
        /// <summary>
        /// Reprsents ths PrizePercentage 
        /// </summary>
        public double PrizePercentage { get; set; }

        public PrizeModel()
        {

        }

        /// <summary>
        /// Constructor that will do validation of data weather the data is applicable to real store into real varibles or not
        /// </summary>
        /// <param name="PlaceNumber"></param>
        /// <param name="PlaceName"></param>
        /// <param name="PrizeAmount"></param>
        /// <param name="PrizePercentage"></param>
        public PrizeModel(string PlaceNumber,string PlaceName,string PrizeAmount,string PrizePercentage)
        {
            this.PlaceName = PlaceName;

            int PlaceNumberValue = 0;
            int.TryParse(PlaceNumber, out PlaceNumberValue);
            this.PlaceNumber = PlaceNumberValue;

            decimal PrizeAmountvalue = 0;
            decimal.TryParse(PrizeAmount, out PrizeAmountvalue);
            this.PrizeAmount = PrizeAmountvalue;

            double PrizePercentageValue = 0;
            double.TryParse(PrizePercentage, out PrizePercentageValue);
            this.PrizePercentage = PrizePercentageValue;

        }
    }
}
