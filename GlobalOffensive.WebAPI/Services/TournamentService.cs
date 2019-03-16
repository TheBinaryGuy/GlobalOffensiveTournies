using GlobalOffensive.WebAPI.Data;
using GlobalOffensive.Models;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GlobalOffensive.WebAPI.Services
{
    public class TournamentService : ITournamentService
    {
        private readonly AppConnFactory _connFactory;

        public TournamentService(AppConnFactory connFactory)
        {
            _connFactory = connFactory;
        }

        public async Task<Tournament> AddTournamentAsync(Tournament tournament)
        {
            using (var db = await _connFactory.OpenDbConnectionAsync())
            {
                await db.SaveAsync(tournament, references: tournament.Matches != null);
                return tournament;
            }
        }

        public async Task<bool> DeleteTournamentAsync(int tournamentId)
        {
            using (var db = await _connFactory.OpenDbConnectionAsync())
            {
                var result = await db.DeleteByIdAsync<Tournament>(tournamentId);
                return Convert.ToBoolean(result);
            }
        }

        public async Task<List<Tournament>> GetAllTournamentsAsync()
        {
            using (var db = await _connFactory.OpenDbConnectionAsync())
            {
                var tournaments = await db.SelectAsync<Tournament>();
                return tournaments;
            }
        }

        public async Task<List<Match>> GetMatches(int tournamentId)
        {
            using (var db = await _connFactory.OpenDbConnectionAsync())
            {
                var tournament = await db.LoadSingleByIdAsync<Tournament>(tournamentId);
                return tournament?.Matches;
            }
        }

        public async Task<Tournament> GetTournamentByIdAsync(int tournamentId)
        {
            using (var db = await _connFactory.OpenDbConnectionAsync())
            {
                return await db.LoadSingleByIdAsync<Tournament>(tournamentId);
            }
        }

        public async Task<bool> UpdateTournamentAsync(Tournament tournament)
        {
            using (var db = await _connFactory.OpenDbConnectionAsync())
            {
                var result = await db.SaveAsync(tournament, references: tournament.Matches != null);
                return !result;
            }
        }
    }
}