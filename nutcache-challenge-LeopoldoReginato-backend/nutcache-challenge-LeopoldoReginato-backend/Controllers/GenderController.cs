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
    public class GenderController : ControllerBase
    {
        private readonly IGenderService _genderService;
        private readonly IMapper _mapper;

        public GenderController(IGenderService genderService, IMapper mapper)
        {
            _genderService = genderService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            ResponseApi<List<GenderDTO>> _response = new ResponseApi<List<GenderDTO>>();

            try
            {
                List<Gender> genders = await _genderService.GetList();
                if (genders.Count() > 0)
                {
                    List<GenderDTO> genderDTOs = _mapper.Map<List<GenderDTO>>(genders);
                    _response = new ResponseApi<List<GenderDTO>>() { Status = true, Msg = "Ok", Value = genderDTOs };
                }
                else
                    _response = new ResponseApi<List<GenderDTO>>() { Status = false, Msg = "No data" };

                return StatusCode(StatusCodes.Status200OK, _response);
            }
            catch (Exception ex)
            {
                _response = new ResponseApi<List<GenderDTO>>() { Status = false, Msg = ex.Message };
                
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }
    }
}
