using Microsoft.EntityFrameworkCore;
using nutcache_challenge_LeopoldoReginato_backend.Models;
using nutcache_challenge_LeopoldoReginato_backend.Services.Contract;

namespace nutcache_challenge_LeopoldoReginato_backend.Services.Implementation
{
    public class TeamService : ITeamService
    {
        private readonly DBNutcacheContext _dbContext;

        public TeamService(DBNutcacheContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Team>> GetList()
        {
            try
            {
                List<Team> teams = new List<Team>();
                teams = await _dbContext.Teams.ToListAsync();

                return teams;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
