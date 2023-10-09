using api_learning_right_project.DTO;
using api_learning_right_project.Interface;
using api_learning_right_project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_learning_right_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly IOrderDetail service;

        public OrderDetailController(IOrderDetail service)
        {
            this.service = service;
        }
        [Route("get-all")]
        [HttpGet]
        public async Task<IActionResult> GetAll() 
        {

            ResponseAPI<List<OrderDetail>> responseAPI = new ResponseAPI<List<OrderDetail>>();
            try
            {
                responseAPI.Data = await this.service.GetAllOrderDetailsAsync();
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
        public async Task<IActionResult> GetById(string id)
        {
            ResponseAPI<OrderDetail> responseAPI = new ResponseAPI<OrderDetail>();
            try
            {
                responseAPI.Data = await this.service.GetOrderDetailByIdAsync(id);
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
        public async Task<IActionResult> AddOrder(OrderDetailDTO orderDetailDTO)
        {
            ResponseAPI<OrderDetail> responseAPI = new ResponseAPI<OrderDetail>();
            try
            {
                responseAPI.Data = await this.service.AddOrderDetailAsync(orderDetailDTO);
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
            ResponseAPI<OrderDetail> responseAPI = new ResponseAPI<OrderDetail>();
            try
            {
                responseAPI.Data = await this.service.DeleteOrderDetailAsync(id);
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
            ResponseAPI<OrderDetail> responseAPI = new ResponseAPI<OrderDetail>();
            try
            {
                responseAPI.Data = await this.service.UpdateOrderDetailAsync(id);
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
