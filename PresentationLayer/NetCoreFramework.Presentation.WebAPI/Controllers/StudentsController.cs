using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetCoreFramework.Application.Core.Students;
using NetCoreFramework.Application.Core.DTO.Student;
using NetCoreFramework.Domain.Models;
using NetCoreFramework.Presentation.WebAPI.Filters;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NetCoreFramework.Presentation.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class StudentsController : Controller
    {
        private IStudentService _studentService;
        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;       
        }
        // GET: api/values
        [HttpGet]
        public ActionResult<List<StudentDTO>> Get()
        {
            return Ok(_studentService.GetStudentList());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<StudentDTO> Get(int id)
        {
            return Ok(_studentService.GetStudentById(id));
        }

        // POST api/values
        [HttpPost]
        [ValidateModelState]
        public ActionResult Post([FromBody]Student student) //will be replaced by DTO and CQRS pattern
        {
            _studentService.CreateStudent(student);
            return StatusCode(201);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
