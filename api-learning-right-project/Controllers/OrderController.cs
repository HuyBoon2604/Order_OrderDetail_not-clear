using api_learning_right_project.DTO;
using api_learning_right_project.Interface;
using api_learning_right_project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_learning_right_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrder service;
        public OrderController(IOrder service)
        {
            this.service = service;
        }

        [Route("get-all")]
        [HttpGet]
        public async Task<IActionResult> GetAllOrder()
        {
            ResponseAPI<List<Order>> responseAPI = new ResponseAPI<List<Order>>();
            try
            {
                responseAPI.Data = await this.service.GetAllOrdersAsync();
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.message = ex.Message;
                return BadRequest(ex.Message);
            }
        }

        [Route("add")]
        [HttpPost]
        public async Task<IActionResult> AddOrder(OrderDTO orderDTO)
        {
            ResponseAPI<Order> responseAPI = new ResponseAPI<Order>();
            try
            {
                responseAPI.Data = await this.service.AddOrderAsync(orderDTO);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.message = ex.Message;
                return BadRequest(ex.Message);
            }
        }

        [Route("get-id")]
        [HttpGet]
        public async Task<IActionResult> GetOrderById(string id)
        {
            ResponseAPI<Order> responseAPI = new ResponseAPI<Order>();
            try
            {
                responseAPI.Data = await this.service.GetOrderByIdAsync(id);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.message = ex.Message;
                return BadRequest(ex.Message);
            }
        }


        [Route("delete")]
        [HttpDelete]
        public async Task<IActionResult> DeleteOrder(string id)
        {
            ResponseAPI<Order> responseAPI = new ResponseAPI<Order>();
            try
            {
                responseAPI.Data = await this.service.DeleteOrderAsync(id);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.message = ex.Message;
                return BadRequest(ex.Message);
            }
        }



        [Route("update")]
        [HttpPut]
        public async Task<IActionResult> UpdateOrder(string id)
        {
            ResponseAPI<Order> responseAPI = new ResponseAPI<Order>();
            try
            {
                responseAPI.Data = await this.service.UpdateOrderAsync(id);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.message = ex.Message;
                return BadRequest(ex.Message);
            }
        }
    }
}
