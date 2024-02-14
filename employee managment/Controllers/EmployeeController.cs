
using Emp.Librarary.Application.IServices;
using Emp.Librarary.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace employee_managment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        // GET: UserManagmentController

        readonly IEmployeeServices _userMamangentServices;

        public EmployeeController(IEmployeeServices userMamangentServices)
        {
            _userMamangentServices = userMamangentServices;
        }

        [HttpPost]
        public async Task<ActionResult> Add(Employee employee)
        {
            try
            {
                return Ok(await _userMamangentServices.Add(employee));

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // GET: UserManagmentController/Details/5
        [HttpPut]
        public async Task<ActionResult> Update(Employee employee)
        {
            try
            {
                return Ok(await _userMamangentServices.Update(employee));

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // GET: UserManagmentController/Create

        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                return Ok(await _userMamangentServices.GetAll());

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("GetById")]
        public async Task<ActionResult> GetById(int EmployeeId)
        {
            try
            {
                return Ok(await _userMamangentServices.GetById(EmployeeId));

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}
