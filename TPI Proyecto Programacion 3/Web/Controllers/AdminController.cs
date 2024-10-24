using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Application.Models.AdminModels.Response;
using Application.Models.AdminModels.Request;
using Application.Interfaces;
using Application.Services;
using System.Linq.Expressions;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        // inyeccion de dependencia 
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet]
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

        [HttpGet("{id}")]
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

        [HttpPost]
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

        [HttpPut("{id}")]
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

        [HttpDelete("{id}")]
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
