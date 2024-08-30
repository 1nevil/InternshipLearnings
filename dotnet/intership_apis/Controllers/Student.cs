using Microsoft.AspNetCore.Mvc;


/*
 
 ActionResult: Use ActionResult when you need to return a specific type of response (e.g., view, content, redirect) and don't require asynchronous handling.


 IActionResult: Use IActionResult when you need more flexibility in response handling, asynchronous operations, or custom responses.

Example:

Using ActionResult
public ActionResult Index()
{
    return View();
}

// Using IActionResult
public IActionResult About()
{
    // Perform some asynchronous operation
    Task.Delay(1000).Wait();

    return Content("About page");
}
 
 */

namespace intership_apis.Controllers
{

   public class StudentObj
    {
        public int Sid { get; set; }
        public string Name { get; set; }
    }

    public class ServerError
    {
        public string message { get; set; }
        public string errorMessage { get; set; }

    }

    [Route("api/[controller]")]
    [ApiController]
    public class Student : ControllerBase
    {
        List<StudentObj> students = new List<StudentObj>();

        public Student()
        {
           
                students.Add(new StudentObj { Sid = 1, Name="javal" });
                students.Add(new StudentObj { Sid = 2, Name = "ram" });
                students.Add(new StudentObj { Sid = 3, Name = "jamin" });
                students.Add(new StudentObj { Sid = 4, Name = "ujval" });

           
        }

        //Problem with this return type is we cannot use notFound and ok status code
        [HttpGet("/")]
        public List<StudentObj> GetAllStudents()
        {
            return students;
        }

        //It not display what is Schema type in swwager
        [HttpGet("/getStudent/IActionResult/NoSchema")]
        public IActionResult GetAllStudentsIActionResult()
        {
            return Ok(students);
        }


        //It not display what is return type in swwager
        [HttpGet("/getStudent/IActionResult/DisplaySchemaType")]
        [ProducesResponseType(typeof(StudentObj[]),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ServerError),StatusCodes.Status500InternalServerError)]

        // [ProducesResponseType(typeof(List<StudentObj>),StatusCodes.Status200OK)]
        public IActionResult GetAllStudentsIActionResultWithModel()
        {
            return Ok(students);
        }


        //It not display what is return type in swwager
        [HttpGet("/getStudent/ActionResult")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]   
        [ProducesResponseType(typeof(ServerError),StatusCodes.Status500InternalServerError)]
        public ActionResult<StudentObj[]> GetAllStudentsActionResult()
        {
            return Ok(students);
        }
    }
}
    