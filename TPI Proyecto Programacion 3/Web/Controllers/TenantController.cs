using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Application.Models.TenantModels.Response;
using Application.Models.TenantModels.Request;
using Application.Interfaces;
using Application.Services;
using Application.Models.AppartmentModels.Request;
using System.Linq.Expressions;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenantController : ControllerBase
    {
        // inyeccion de dependencia 
        private readonly ITenantService _tenantService;

        public TenantController(ITenantService tenantService)
        {
            _tenantService = tenantService;
        }

        [HttpGet]
        public ActionResult<List<TenantResponse>> GetAllTenant()
        {
            try
            {
                var response = _tenantService.GetAll();
                return Ok(response);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return NotFound(e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetTenantById([FromRoute] int id)
        {
            try
            {
                var response = _tenantService.GetById(id);
                return Ok(response);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return NotFound(e.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateTenant([FromBody] CreateTenantRequest tenant)
        {
            try
            {
                var response = _tenantService.Create(tenant);
                return Ok(response);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return NotFound(e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTenant([FromRoute] int id, [FromBody] CreateTenantRequest tenant)
        {
            try
            {
                var response = _tenantService.UpdateTenant(id, tenant);
                return Ok(response);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return NotFound(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTenant([FromRoute] int id)
        {
            try
            {
                var response = _tenantService.DeleteTenant(id);
                return Ok(response);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return NotFound(e.Message);
            }
        }

        [HttpPost("tenant/{tenantId}/{appartmentId}")]
        public IActionResult AssignAppartmentToTenant([FromRoute] int tenantId, [FromRoute] int appartmentId)
        {
            try
            {
                var response = _tenantService.AssignAppartmentToTenant(tenantId, appartmentId);
                return Ok("Asignación correcta");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return NotFound(e.Message);
            };
        }

    }
}
