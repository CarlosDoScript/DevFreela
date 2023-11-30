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
            return Ok(); 
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProjectModel createProject)
        {
            if (createProject.Title.Length > 50)
                return BadRequest();

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateProjectModel updateProject)
        {
            if (updateProject.Description.Length > 200)
                return BadRequest();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return NoContent();
        }

        [HttpPost("{id}/comments")]
        public async Task<IActionResult> PostComment(int id, [FromBody] CreateCommentModel createComment)
        {
            return NoContent();
        }

        [HttpPut("{id}/start")]
        public async Task<IActionResult> Start(int id)
        {
            return NoContent();
        }

        [HttpPut("{id}/finish")]
        public async Task<IActionResult> Finish(int id)
        {
            return NoContent();
        }
    }
}
