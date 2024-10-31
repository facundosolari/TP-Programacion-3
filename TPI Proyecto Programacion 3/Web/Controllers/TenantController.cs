using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Application.Models.TenantModels;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenantController : ControllerBase
    {
        private readonly ITenantService _tenantService;

        public TenantController(ITenantService tenantService)
        {
            _tenantService = tenantService;
        }

        [HttpGet]
        [Authorize]
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
        [Authorize]
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
        public IActionResult CreateTenant([FromBody] TenantRequest tenant)
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
        [Authorize(Roles = "Admin,Tenant")]
        public IActionResult UpdateTenant([FromRoute] int id, [FromBody] TenantRequest tenant)
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
        [Authorize(Roles = "Admin,Tenant")]
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

        [HttpPatch("/{tenantId}/{appartmentId}")]
        [Authorize(Roles = "Admin,Tenant")]
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
