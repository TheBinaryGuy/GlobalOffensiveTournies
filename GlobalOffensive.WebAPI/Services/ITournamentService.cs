using GlobalOffensive.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GlobalOffensive.WebAPI.Services
{
    public interface ITournamentService
    {
        Task<List<Tournament>> GetAllTournamentsAsync();

        Task<Tournament> GetTournamentByIdAsync(int tournamentId);

        Task<List<Match>> GetMatches(int tournamentId);

        Task<Tournament> AddTournamentAsync(Tournament tournament);

        Task<bool> UpdateTournamentAsync(Tournament tournament);

        Task<bool> DeleteTournamentAsync(int tournamentId);
    }
}