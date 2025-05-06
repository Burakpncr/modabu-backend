using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // GET: api/Orders
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _orderService.GetAll();
            if (result.Success)
                return Ok(result.Data);
            return BadRequest(result.Message);
        }

        // POST: api/Orders
        [HttpPost]
        public IActionResult Create([FromBody] Order order)
        {
            var result = _orderService.Add(order);
            if (result.Success)
                return Ok(order);
            return BadRequest(result.Message);
        }

        // PUT: api/Orders
        [HttpPut]
        public IActionResult Update([FromBody] Order order)
        {
            var result = _orderService.Update(order);
            if (result.Success)
                return NoContent();
            return BadRequest(result.Message);
        }

        // DELETE: api/Orders/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _orderService.Delete(id);
            if (result.Success)
                return NoContent();
            return BadRequest(result.Message);
        }
    }
}
