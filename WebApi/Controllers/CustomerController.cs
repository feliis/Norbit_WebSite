using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]

    public class CustomerController : Controller
    {
        [Route("Add/[controller]")]
        [HttpPost]
        public IActionResult AddCustomer([FromBody] Customer NewCustomer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            using (ContextDB DB = new ContextDB())
            {
                NewCustomer.id_customer = NewCustomer.NewIndex();
                DB.Add(NewCustomer);
                DB.SaveChanges();
                return Ok();
            }
        }

        [Route("Show/[controller]")]
        [HttpGet]
        public IActionResult Show()
        {
            ContextDB DB = new ContextDB();
            var customer = DB.customer.ToList();
            return Ok(customer);
        }

        [Route("Delete/[controller]")]
        [HttpDelete]
        public IActionResult DeleteCustomerByID(int id_customer)
        {
            using (ContextDB DB = new ContextDB())
            {
                Customer data = DB.customer.Find(id_customer);
                if (data != null)
                {
                    DB.customer.Remove(data);
                    DB.SaveChanges();
                    return Ok();
                }
                return BadRequest(ModelState);

            }
        }
    }
}
