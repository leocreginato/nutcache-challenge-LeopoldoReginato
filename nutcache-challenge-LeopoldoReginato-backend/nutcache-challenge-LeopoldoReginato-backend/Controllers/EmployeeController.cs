using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            ResponseApi<List<EmployeeDTO>> _response = new ResponseApi<List<EmployeeDTO>>();

            try
            {
                List<Employee> employees = await _employeeService.GetList();

                if (employees.Count() > 0)
                {
                    List<EmployeeDTO> employeeDTOs = _mapper.Map<List<EmployeeDTO>>(employees);
                    _response = new ResponseApi<List<EmployeeDTO>>() { Status = true, Msg = "Ok", Value = employeeDTOs };
                }
                else
                    _response = new ResponseApi<List<EmployeeDTO>>() { Status = false, Msg = "No data" };

                return StatusCode(StatusCodes.Status200OK, _response);
            }
            catch (Exception ex)
            {
                _response = new ResponseApi<List<EmployeeDTO>>() { Status = false, Msg = ex.Message };

                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(EmployeeDTO request)
        {
            ResponseApi<EmployeeDTO> _response = new ResponseApi<EmployeeDTO>();

            try
            {
                Employee employee = _mapper.Map<Employee>(request);
                Employee employeeCreated = await _employeeService.Add(employee);

                if (employeeCreated.Id != 0)
                {
                    _response = new ResponseApi<EmployeeDTO>() { Status = true, Msg = "Ok", Value = _mapper.Map<EmployeeDTO>(employeeCreated) };
                }
                else
                    _response = new ResponseApi<EmployeeDTO>() { Status = false, Msg = "Could not create employee" };

                return StatusCode(StatusCodes.Status200OK, _response);
            }
            catch (Exception ex)
            {
                _response = new ResponseApi<EmployeeDTO>() { Status = false, Msg = ex.Message };

                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(EmployeeDTO request)
        {
            ResponseApi<EmployeeDTO> _response = new ResponseApi<EmployeeDTO>();

            try
            {
                Employee employee = _mapper.Map<Employee>(request);
                Employee employeeEdited = await _employeeService.Update(employee);

                _response = new ResponseApi<EmployeeDTO>() { Status = true, Msg = "Ok", Value = _mapper.Map<EmployeeDTO>(employeeEdited) };

                return StatusCode(StatusCodes.Status200OK, _response);
            }
            catch (Exception ex)
            {
                _response = new ResponseApi<EmployeeDTO>() { Status = false, Msg = ex.Message };

                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            ResponseApi<bool> _response = new ResponseApi<bool>();

            try
            {
                Employee employeeDeleted = await _employeeService.GetEmployeeById(id);
                bool deleted = await _employeeService.Delete(employeeDeleted);

                if (deleted)
                    _response = new ResponseApi<bool>() { Status = true, Msg = "Ok" };
                else
                    _response = new ResponseApi<bool>() { Status = true, Msg = "Not deleted" };

                return StatusCode(StatusCodes.Status200OK, _response);
            }
            catch (Exception ex)
            {
                _response = new ResponseApi<bool>() { Status = false, Msg = ex.Message };

                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

    }
}
