using nutcache_challenge_LeopoldoReginato_backend.Models;

namespace nutcache_challenge_LeopoldoReginato_backend.Services.Contract
{
    public interface ITeamService
    {
        Task<List<Team>> GetList();
    }
}
