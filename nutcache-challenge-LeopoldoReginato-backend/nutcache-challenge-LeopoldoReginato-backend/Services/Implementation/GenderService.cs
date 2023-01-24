using Microsoft.EntityFrameworkCore;
using nutcache_challenge_LeopoldoReginato_backend.Models;
using nutcache_challenge_LeopoldoReginato_backend.Services.Contract;

namespace nutcache_challenge_LeopoldoReginato_backend.Services.Implementation
{
    public class GenderService : IGenderService
    {
        private readonly DBNutcacheContext _dbContext;

        public GenderService(DBNutcacheContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Gender>> GetList()
        {
            try
            {
                List<Gender> genders = new List<Gender>();
                genders = await _dbContext.Genders.ToListAsync();

                return genders;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
