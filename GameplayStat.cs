using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Player_Dashboard
{
    public class GameplayStat
    {
        public int Id { get; set; }
        public int PlayerId { get; set; } // Foreign key to Player
        public int TotalGamesPlayed { get; set; }
        public int TotalWins { get; set; }
        public int TotalLosses { get; set; }
    }
}
