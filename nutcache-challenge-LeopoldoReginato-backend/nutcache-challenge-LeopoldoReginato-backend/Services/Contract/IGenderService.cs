using nutcache_challenge_LeopoldoReginato_backend.Models;

namespace nutcache_challenge_LeopoldoReginato_backend.Services.Contract
{
    public interface IGenderService
    {
        Task<List<Gender>> GetList();
    }
}
