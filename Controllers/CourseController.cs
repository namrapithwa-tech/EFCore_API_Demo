using EFCore_API_Demo.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCore_API_Demo.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CourseController : Controller
    {
        // Inject ApplicationDbContext class dependency
        private readonly ApplicationDbContext _context;
        public CourseController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/course/getallcourses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetCourse()
        {
            return await _context.Courses.ToListAsync();
        }

        // GET: api/course/getcoursebyid/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetCoursebyID(int id)
        {
            var course = await _context.Courses.FindAsync(id);

            if (course == null)
            {
                return NotFound();
            }

            return course;
        }

        // POST: api/course/addcourse
        [HttpPost]
        public async Task<ActionResult<Course>> AddCourse(Course course)
        {
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudent", new { id = course.CourseId }, course);
        }

        // PUT: api/course/updatecourse/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourse(int id, Course course)
        {
            if (id != course.CourseId)
            {
                return BadRequest();
            }

            try
            {
                _context.Update(course);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                if (!CourseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CourseExists(int id)
        {
            return _context.Courses.Any(e => e.CourseId == id);
        }

    }
}
