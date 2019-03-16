using GlobalOffensive.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GlobalOffensive.WebAPI.Services
{
    public interface IMatchService
    {
        Task<List<Match>> GetAllMatchesAsync();

        Task<Match> GetMatchByIdAsync(int matchId);

        Task<Tournament> GetTournamentInfo(int matchId);

        Task<Match> AddMatchAsync(Match match);

        Task<bool> UpdateMatchAsync(Match match);

        Task<bool> DeleteMatchAsync(int matchId);
    }
}