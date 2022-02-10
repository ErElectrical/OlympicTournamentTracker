using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TournamentTracker;

namespace TournamentTrackerUI
{
    /// <summary>
    /// createPrize class will actually validate the data and 
    /// send it to our PrizeModel class where our fields are initialize by the valid values.
    /// </summary>
    /// 

    
    public partial class CreatePrize : Form
    {
        IPrizeRequest CallingForm;
        public CreatePrize(IPrizeRequest Caller)
        {
            InitializeComponent();

            CallingForm = Caller;
        }

        /// <summary>
        /// Method will pass the valid values to PrizeModel class 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreatePrizeButton_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                PrizeModel Model = new PrizeModel(
                    PlaceNumbervalue.Text,
                    PlaceNameValue.Text,
                    PrizeAmountValue.Text,
                    PrizePercentageValue.Text);

                ConnectionConfig.Connections.Add((Idataconnection)Model);

                CallingForm.PrizeComplete(Model);

                this.Close();
            }
           
        }

        /// <summary>
        /// Method validate the CreatePrizeForm Entry
        /// </summary>
        /// <returns></returns>
        private bool ValidateForm()
        {
            bool OutPut = true;
            int PlaceNumber = 0;
            bool PlaceNumberValidate = int.TryParse(PlaceNumbervalue.Text, out PlaceNumber);

            if(PlaceNumberValidate == false)
            {
                OutPut = false;
            }
            if(PlaceNumber < 1)
            {
                OutPut = false;

            }
            if(PlaceNameValue.Text.Length == 0)
            {
                OutPut = false;

            }
            decimal PrizeAmount = 0;
            double PrizePercentage = 0;
            bool PrizeAmountValidate = decimal.TryParse(PrizeAmountValue.Text, out PrizeAmount);
         
            bool PrizePercentageValidate = double.TryParse(PrizePercentageValue.Text, out PrizePercentage);
            if (PrizeAmount < 0 && PrizePercentage < 0)
            {
                OutPut = false;

            }
            if(PrizeAmountValidate == false || PrizePercentageValidate == false)
            {
                OutPut = false;

            }
            if(PrizePercentage <0 || PrizePercentage >100)
            {
                OutPut = false;

            }

            return OutPut;
        }
    }
}
