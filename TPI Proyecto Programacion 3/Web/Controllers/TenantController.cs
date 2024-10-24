using Application.Interfaces;
using Contract.TenantModels.Request;
using Contract.TenantModels.Response;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TenantController : ControllerBase
    {
        private readonly ITenantService _tenantService;

        public TenantController(ITenantService tenantService)
        {
            _tenantService = tenantService;
        }

        [HttpGet]
        public ActionResult<List<TenantResponse>> GetAllTenants()
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
        public IActionResult CreateTenant([FromBody] TenantRequest tenant)
        {
            var response = new TenantResponse();
            string locationUrl = string.Empty;

            try
            {
                response = _tenantService.Create(tenant);

                string baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
                string apiAndEndpointUrl = $"api/tenants/{response.Id}";
                locationUrl = $"{baseUrl}/{apiAndEndpointUrl}";
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return Created(locationUrl, response);
        }
    }
}