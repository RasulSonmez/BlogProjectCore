using BlogApi.DataAccessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        [HttpGet]
        public IActionResult EmployeeList()
        {
            using var c = new Context();

            var values = c.Employees.ToList();

            return Ok(values);
        }

        [HttpPost]
        public IActionResult EmployeeAdd(Employee employee)
        {
            using var c = new Context();

            c.Add(employee);

            c.SaveChanges();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult EmployeeDelete(int id)
        {
            using var c = new Context();
            var value = c.Employees.Find(id);
            if (value == null)
            {
                return NotFound();
            }
            else
            {
                c.Remove(value);
                c.SaveChanges();
                return Ok(value);
            }

        }


    }
}

