using ConsumeApiWithIHttpClientFactory.Dtos;
using ConsumeApiWithIHttpClientFactory.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConsumeApiWithIHttpClientFactory.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CallStudentController : ControllerBase
    {
        private readonly IStudentServices _services;

        public CallStudentController(IStudentServices services)
        {
            this._services = services;
        }
        [HttpPost]
        public async Task<ActionResult<AddStudentResponse>> AddStudent(AddStudentRequest request)
        {
            var result = await _services.AddStudent(request);
            return Ok(result);
        }
        [HttpGet]
        public async Task<ActionResult<List<GetStudentResponse>>> GetStudents()
        {
            var results = await _services.GetAllStudents();
            return Ok(results);
        }
        [HttpGet]
        public async Task<ActionResult<GetStudentResponse>> GetStudentById([FromQuery] int id)
        {
            var result = await _services.GetStudentById(id);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<ActionResult> RemoveStudent([FromQuery] int id)
        {
            await _services.RemoveStudent(id);
            return Ok("successfully Removed");
        }
        [HttpPut]
        public async Task<ActionResult<EditStudentResponse>> EditStudent([FromBody] EditStudentRequest request)
        {
            var result = await _services.EditStudent(request);
            return result;
        }
    }
}
