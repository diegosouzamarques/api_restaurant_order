using Api_Restaurant_Order.Application.DTOs;
using Api_Restaurant_Order.Application.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Api_Restaurant_Order.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableController : ControllerBase
    {
        private readonly ITableService _tableService;

        public TableController(ITableService tableService)
        {
            _tableService = tableService;
        }

        #region Documentation
        /// POST api/Table 
        /// <summary>
        /// Creates a Table in the Table entity
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     POST
        ///     {
        ///        "title": "Mesa 01",
        ///        "amountPeople": 4, 
        ///        "status": 1
        ///     }
        ///
        /// </remarks>
        /// <response code="200">
        /// Return will be table registered with id
        /// </response>
        /// <response code="400">Return with description of what is missing from the request
        /// </response>  
        #endregion
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

        #region Documentation
        /// Get api/Table
        /// <summary>
        ///    Search all registered Table
        /// </summary>
        /// <response code="200">
        ///    Returns list containing all Table
        /// </response>
        /// <response code="400">Return with description of what is missing from the request
        /// </response>  
        #endregion
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

        #region Documentation
        /// Get api/Table/{id}
        /// <summary>
        ///    Search for a specific Table by id
        /// </summary>
        /// <response code="200">
        ///    Returns Table found by id
        /// </response>
        /// <response code="400">Return with description of what is missing from the request
        /// </response>  
        #endregion
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

        #region Documentation

        #endregion
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

        #region Documentation
        /// Delete api/Table/{id}
        /// <summary>
        ///  Remove a Table by ID code
        /// </summary>
        /// <response code="200">
        ///    Return will be that Table was successfully removed
        /// </response>
        /// <response code="400">Return with description of what is missing from the request
        /// </response>  
        #endregion
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
