using Api_Restaurant_Order.Application.DTOs;
using Api_Restaurant_Order.Application.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Api_Restaurant_Order.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] OrderDTO orderDTO)
        {
            try
            {
                var result = await _orderService.CreateAsync(orderDTO);
                if (result.IsSuccess)
                    return Ok(result);

                return BadRequest(result);
            }
            catch (Exception ex)
            {
                var result = StatusCode(StatusCodes.Status500InternalServerError, ex.GetaAllMessages());
                return result;
            }

        }

        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            try
            {
                var result = await _orderService.GetAsync();
                if (result.IsSuccess)
                    return Ok(result);

                return BadRequest(result);
            }
            catch (Exception ex)
            {
                var result = StatusCode(StatusCodes.Status500InternalServerError, ex.GetaAllMessages());
                return result;
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetByIdAsync(int id)
        {
            try
            {
                var result = await _orderService.GetByIdAsync(id);
                if (result.IsSuccess)
                    return Ok(result);

                return BadRequest(result);
            }
            catch (Exception ex)
            {
                var result = StatusCode(StatusCodes.Status500InternalServerError, ex.GetaAllMessages());
                return result;
            }
        }


        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromBody] OrderDTO orderDTO)
        {
            try
            {
                var result = await _orderService.UpdateAsync(orderDTO);
                if (result.IsSuccess)
                    return Ok(result);

                return BadRequest(result);
            }
            catch (Exception ex)
            {
                var result = StatusCode(StatusCodes.Status500InternalServerError, ex.GetaAllMessages());
                return result;
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            try
            {
                var result = await _orderService.DeleteAsync(id);
                if (result.IsSuccess)
                    return Ok(result);

                return BadRequest(result);
            }
            catch (Exception ex)
            {
                var result = StatusCode(StatusCodes.Status500InternalServerError, ex.GetaAllMessages());
                return result;
            }
        }

    }
}
