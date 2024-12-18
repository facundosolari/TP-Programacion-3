using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Application.Models.AdminModels;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult<List<AdminResponse>> GetAllAdmin()
        {
            try
            {
                var response = _adminService.GetAll();
                return Ok(response);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return NotFound(e.Message);
            }
        }

        [HttpGet("getById/{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAdminById([FromRoute] int id)
        {
            try
            {
                var response = _adminService.GetById(id);
                return Ok(response);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return NotFound(e.Message);
            }
        }

        [HttpPost("create")]
        [Authorize(Roles = "Admin")]
        public IActionResult CreateAdmin([FromBody] AdminRequest admin)
        {
            try
            {
                var response = _adminService.Create(admin);
                return Ok(response);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return NotFound(e.Message);
            }
        }

        [HttpPut("update/{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult UpdateAdmin([FromRoute] int id, [FromBody] AdminRequest admin)
        {
            try
            {
                var response = _adminService.UpdateAdmin(id, admin);
                return Ok(response);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return NotFound(e.Message);
            }
        }

        [HttpDelete("delete/{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteAdmin([FromRoute] int id)
        {
            try
            {
                var response = _adminService.DeleteAdmin(id);
                return Ok(response);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return NotFound(e.Message);
            }
        }

    }
}
