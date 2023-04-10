using Api_Restaurant_Order.Application.DTOs;
using Api_Restaurant_Order.Application.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Api_Restaurant_Order.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisheDrinkController : ControllerBase
    {
        private readonly IDisheDrinkService _disheDrinkService;

        public DisheDrinkController(IDisheDrinkService disheDrinkService)
        {
            _disheDrinkService = disheDrinkService;
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] DisheDrinkDTO disheDrinkDTO)
        {
            try
            {
                var result = await _disheDrinkService.CreateAsync(disheDrinkDTO);
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
                var result = await _disheDrinkService.GetAsync();
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
                var result = await _disheDrinkService.GetByIdAsync(id);
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
        public async Task<ActionResult> UpdateAsync([FromBody] DisheDrinkDTO disheDrinkDTO)
        {
            try
            {
                var result = await _disheDrinkService.UpdateAsync(disheDrinkDTO);
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
                var result = await _disheDrinkService.DeleteAsync(id);
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
