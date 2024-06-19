using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Player_Dashboard
{
    public class DashboardViewModel
    {
        public int PlayerId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public int TotalGamesPlayed { get; set; }
        public int TotalWins { get; set; }
        public int TotalLosses { get; set; }
        public double WinPercentage { get; set; }
    }
}
