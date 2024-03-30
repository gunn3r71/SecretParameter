using Microsoft.AspNetCore.Mvc;

namespace SecretParameter.Api.Controllers
{
    [Route("api/values")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ValuesController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("connection")]
        public async Task<ActionResult<string>> GetConnectionAsync()
        {
            var connString = _configuration.GetConnectionString("DatabaseConnection") ?? "Oops, não foi possível resgatar a connString";

            return await Task.FromResult(connString);
        }
    }
}
