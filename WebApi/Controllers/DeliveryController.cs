using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]

    public class DeliveryController : Controller
    {
        [Route("Add/[controller]")]
        [HttpPost]
        public IActionResult AddDelivery([FromBody] Delivery NewDelivery)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            using (ContextDB DB = new ContextDB())
            {
                NewDelivery.id_delivery = NewDelivery.NewIndex();
                DB.Add(NewDelivery);
                DB.SaveChanges();
                return Ok();
            }
        }

        [Route("Show/[controller]")]
        [HttpGet]
        public IActionResult Show()
        {
            ContextDB DB = new ContextDB();
            var delivery = DB.delivery.ToList();
            return Ok(delivery);
        }

        [Route("Delete/[controller]")]
        [HttpDelete]
        public IActionResult DeleteDeliveryByID(int id_delivery)
        {
            using (ContextDB DB = new ContextDB())
            {
                Delivery data = DB.delivery.Find(id_delivery);
                if (data != null)
                {
                    DB.delivery.Remove(data);
                    DB.SaveChanges();
                    return Ok();
                }
                return BadRequest(ModelState);

            }
        }
    }
}
