using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using nutcache_challenge_LeopoldoReginato_backend.DTOs;
using nutcache_challenge_LeopoldoReginato_backend.Models;
using nutcache_challenge_LeopoldoReginato_backend.Services.Contract;
using nutcache_challenge_LeopoldoReginato_backend.Utilities;

namespace nutcache_challenge_LeopoldoReginato_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _teamService;
        private readonly IMapper _mapper;

        public TeamController(ITeamService teamService, IMapper mapper)
        {
            _teamService = teamService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            ResponseApi<List<TeamDTO>> _response = new ResponseApi<List<TeamDTO>>();

            try
            {
                List<Team> teams = await _teamService.GetList();
                if (teams.Count() > 0)
                {
                    List<TeamDTO> teamDTOs = _mapper.Map<List<TeamDTO>>(teams);
                    _response = new ResponseApi<List<TeamDTO>>() { Status = true, Msg = "Ok", Value = teamDTOs };
                }
                else
                    _response = new ResponseApi<List<TeamDTO>>() { Status = false, Msg = "No data" };

                return StatusCode(StatusCodes.Status200OK, _response);
            }
            catch (Exception ex)
            {
                _response = new ResponseApi<List<TeamDTO>>() { Status = false, Msg = ex.Message };

                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }
    }
}
