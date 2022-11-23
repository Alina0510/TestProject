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
    public class AccountController : ControllerBase
    {
        private readonly RepoHelper _helper;

        public AccountController(RepoHelper helper)
        {
            _helper = helper;
        }
        [HttpGet]
        public IEnumerable<AccountDto> Get()
        {
            return _helper.GetAccounts();
        }
        [HttpPost]
        public IActionResult Create(AccountDto account)
        {
            try
            {
                _helper.CreateAccount(account); 
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                
            }
        }
    }
}