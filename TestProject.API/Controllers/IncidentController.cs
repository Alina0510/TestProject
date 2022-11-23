using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestProject.API.Models;
using TestProject.DAL;
using TestProject.Models;
using TestProject.REPO;
using TestProject.REPO.Models;

namespace TestProject.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IncidentController : ControllerBase
    {
        private readonly RepoHelper _helper;

        public IncidentController(RepoHelper helper)
        {
            _helper = helper;
        }
        [HttpPost]
        public IActionResult Create(IncidentDto incident)
        {
            try
            {
                if (!_helper.IsAccountExist(incident.AccountName))
                {
                    return NotFound("Account not exist");
                }
                _helper.IncidentWork(incident); 
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                
            }
        }
    }
}