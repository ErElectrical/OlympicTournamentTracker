﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentTracker;

namespace TournamentTrackerUI
{
    public interface IPrizeRequest
    {
        void PrizeComplete(PrizeModel Model);
    }
}
