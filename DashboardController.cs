using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Player_Dashboard
{
    public class DashboardController : Controller
    {
        private readonly AppDbContext _dbContext;

        public DashboardController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index(int playerId)
        {
            // Fetch player and gameplay stats for the given playerId
            var player = _dbContext.Players.FirstOrDefault(p => p.Id == playerId);
            var gameplayStats = _dbContext.GameplayStats.FirstOrDefault(gs => gs.PlayerId == playerId);

            if (player == null || gameplayStats == null)
            {
                return NotFound(); // Handle scenario where player or stats not found
            }

            // Pass data to view
            var viewModel = new DashboardViewModel
            {
                PlayerId = player.Id,
                Username = player.Username,
                Email = player.Email,
                TotalGamesPlayed = gameplayStats.TotalGamesPlayed,
                TotalWins = gameplayStats.TotalWins,
                TotalLosses = gameplayStats.TotalLosses,
                WinPercentage = CalculateWinPercentage(gameplayStats.TotalWins, gameplayStats.TotalGamesPlayed)
            };

            return View(viewModel);
        }

        private double CalculateWinPercentage(int totalWins, int totalGamesPlayed)
        {
            if (totalGamesPlayed == 0)
            {
                return 0;
            }
            return (double)totalWins / totalGamesPlayed * 100;
        }
    }
}
