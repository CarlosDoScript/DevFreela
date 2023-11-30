using DevFreela.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DevFreela.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly OpeningTimeOption _options;
        public ProjectsController(IOptions<OpeningTimeOption> options)
        {
            _options = options.Value;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            await Task.Delay(5000);
            return Ok(); 
        }
    }
}
