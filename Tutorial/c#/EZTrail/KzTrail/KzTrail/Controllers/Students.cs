using Microsoft.AspNetCore.Mvc;

namespace KzTrail.Controllers
{
    //https://localhost:portnumber/api/students
    [Route("api/[controller]")]
    [ApiController]
    public class Students : ControllerBase
    {
        //GET: https://localhost:portnumber/api/students
        [HttpGet]
        public IActionResult GetAllStudents()
        {

            string[] studentNames = new string[] { "Raphi", "Abi", "Kaluzy", "Hilu", "Amina" };

            return Ok(studentNames);
        }
    }
}
