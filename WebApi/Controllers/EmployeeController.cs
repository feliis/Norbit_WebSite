using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]

    public class EmployeeController : Controller
    {
        [Route("Add/[controller]")]
        [HttpPost]
        public IActionResult AddEmployee([FromBody] Employee NewEmployee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            using (ContextDB DB = new ContextDB())
            {
                NewEmployee.id_employee = NewEmployee.NewIndex();
                DB.Add(NewEmployee);
                DB.SaveChanges();
                return Ok();
            }
        }

        [Route("Show/[controller]")]
        [HttpGet]
        public IActionResult Show()
        {
            ContextDB DB = new ContextDB();
            var employee = DB.employee.ToList();
            return Ok(employee);
        }

        [Route("Delete/[controller]")]
        [HttpDelete]
        public IActionResult DeleteEmployeeByID(int id_employee)
        {
            using (ContextDB DB = new ContextDB())
            {
                Employee data = DB.employee.Find(id_employee);
                if (data != null)
                {
                    DB.employee.Remove(data);
                    DB.SaveChanges();
                    return Ok();
                }
                return BadRequest(ModelState);

            }
        }
    }
}
