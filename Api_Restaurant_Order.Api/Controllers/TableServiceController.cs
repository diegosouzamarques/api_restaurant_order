using Api_Restaurant_Order.Application.DTOs;
using Api_Restaurant_Order.Application.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Api_Restaurant_Order.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableServiceController : ControllerBase
    {
        private readonly ITableService _tableService;

        public TableServiceController(ITableService tableService)
        {
            _tableService = tableService;
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] TableDTO tableDTO)
        {
            try
            {
                var result = await _tableService.CreateAsync(tableDTO);
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
                var result = await _tableService.GetAsync();
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
                var result = await _tableService.GetByIdAsync(id);
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
        public async Task<ActionResult> UpdateAsync([FromBody] TableDTO tableDTO)
        {
            try
            {
                var result = await _tableService.UpdateAsync(tableDTO);
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
                var result = await _tableService.DeleteAsync(id);
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
