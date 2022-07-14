using DomainModels.BindingModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Interface;
using System;

namespace CoreProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : Controller
    {
        readonly ILogger<StudentController> _logger;
        private readonly IStudentService _studentService;

        public StudentController(ILogger<StudentController> logger, IStudentService studentService) 
        {
            _logger = logger;
            _studentService = studentService;
        }

        [HttpGet("GetAllStudents")]
        public IActionResult GetAll()

        {
            try
            {
                //var items = _menuService.GetAllMenuItem();

                //if (items == null)
                //    return new NotFoundResult();

                return Ok();
            }

            catch (Exception ex)
            {
                _logger.LogError($"Exception error for MenuController/GetAll Error: {ex}");
                return BadRequest($"GetAllStudents - {ex}");
            }
        }

        [HttpPut("CreateUpdateStudent")]
        public IActionResult CreateUpdateStudent(StudentViewModel student)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                _logger.LogInformation($"StudentController - CreateUpdateStudent {student}.");
                var response = _studentService.CreateUpdate(student);
                return Ok(response.Result);
            }

            catch (Exception ex)
            {
                _logger.LogError($"Exception error for MenuController/GetAll Error: {ex}");
                return BadRequest($"GetAllStudents - {ex}");
            }
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            try
            {
                _studentService.Delete(id);
                return Ok(id);
            }

            catch (Exception ex)
            {
                _logger.LogError($"Exception error for MenuController/GetAll Error: {ex}");
                return BadRequest($"Delete - {ex}");
            }
        }
    }
}
