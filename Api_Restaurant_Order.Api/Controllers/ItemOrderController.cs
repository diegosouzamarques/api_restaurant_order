using Api_Restaurant_Order.Application.DTOs;
using Api_Restaurant_Order.Application.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Api_Restaurant_Order.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemOrderController : ControllerBase
    {
        private readonly IItemOrderService _itemOrderService;

        public ItemOrderController(IItemOrderService itemOrderService)
        {
            _itemOrderService = itemOrderService;
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] ItemOrderDTO itemOrderDTO)
        {
            try
            {
                var result = await _itemOrderService.CreateAsync(itemOrderDTO);
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
                var result = await _itemOrderService.GetAsync();
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
                var result = await _itemOrderService.GetByIdAsync(id);
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
        public async Task<ActionResult> UpdateAsync([FromBody] ItemOrderDTO itemOrderDTO)
        {
            try
            {
                var result = await _itemOrderService.UpdateAsync(itemOrderDTO);
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
                var result = await _itemOrderService.DeleteAsync(id);
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
