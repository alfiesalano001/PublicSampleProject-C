using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace CoreProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClassesController : Controller
    {
        readonly ILogger<ClassesController> _logger;
        public ClassesController(ILogger<ClassesController> logger)
        {
            _logger = logger;
        }

        [HttpGet("GetAllSubjects")]
        public IActionResult GetAll()

        {
            try
            {
                _logger.LogInformation($"ClassesController - GetAllSubjects.");
                //var items = _menuService.GetAllMenuItem();

                //if (items == null)
                //    return new NotFoundResult();

                return Ok();
            }

            catch (Exception ex)
            {
                _logger.LogError($"Exception error for MenuController/GetAll Error: {ex}");
                return BadRequest($"GetAllSubjects - {ex}");
            }
        }
    }
}
