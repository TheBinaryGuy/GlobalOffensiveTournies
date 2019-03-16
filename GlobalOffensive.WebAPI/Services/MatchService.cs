using GlobalOffensive.WebAPI.Data;
using GlobalOffensive.Models;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GlobalOffensive.WebAPI.Services
{
    public class MatchService : IMatchService
    {
        private readonly AppConnFactory _connFactory;

        public MatchService(AppConnFactory connFactory)
        {
            _connFactory = connFactory;
        }

        public async Task<Match> AddMatchAsync(Match match)
        {
            using (var db = await _connFactory.OpenDbConnectionAsync())
            {
                await db.SaveAsync(match);
                return match;
            }
        }

        public async Task<bool> DeleteMatchAsync(int matchId)
        {
            using (var db = await _connFactory.OpenDbConnectionAsync())
            {
                var result = await db.DeleteByIdAsync<Match>(matchId);
                return Convert.ToBoolean(result);
            }
        }

        public async Task<List<Match>> GetAllMatchesAsync()
        {
            using (var db = await _connFactory.OpenDbConnectionAsync())
            {
                return await db.SelectAsync<Match>();
            }
        }

        public async Task<Match> GetMatchByIdAsync(int matchId)
        {
            using (var db = await _connFactory.OpenDbConnectionAsync())
            {
                return await db.LoadSingleByIdAsync<Match>(matchId);
            }
        }

        public async Task<Tournament> GetTournamentInfo(int matchId)
        {
            using (var db = await _connFactory.OpenDbConnectionAsync())
            {
                var match = await db.LoadSingleByIdAsync<Match>(matchId);
                var tournament = await db.SingleByIdAsync<Tournament>(match.TournamentId);
                return tournament;
            }
        }

        public async Task<bool> UpdateMatchAsync(Match match)
        {
            using (var db = await _connFactory.OpenDbConnectionAsync())
            {
                return await db.SaveAsync(match);
            }
        }
    }
}