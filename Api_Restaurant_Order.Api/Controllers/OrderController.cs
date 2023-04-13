using Api_Restaurant_Order.Api.Controllers.Authorization;
using Api_Restaurant_Order.Application.DTOs;
using Api_Restaurant_Order.Application.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Api_Restaurant_Order.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        #region Documentation
        /// POST api/Order
        /// <summary>
        ///   Register an order
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     POST
        ///     {
        ///       "tableID": 10,
        ///       "requester": "Diego Marques",
        ///       "note": "Mustard sauce"
        ///     }
        ///
        /// </remarks>
        /// <response code="200">
        ///     Return will be the order registered with your Id
        /// </response>
        /// <response code="400">Return with description of what is missing from the request
        /// </response>  
        #endregion
        [HttpPost]
        [Authorize(Roles = UserRoles.Order_Register)]
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

        #region Documentation
        /// Get api/Order
        /// <summary>
        ///    Search all registered orders
        /// </summary>
        /// <response code="200">
        /// Returns list containing all orders
        /// </response>
        /// <response code="400">Return with description of what is missing from the request
        /// </response>  
        #endregion
        [HttpGet]
        [Authorize(Roles = UserRoles.Order_Search)]
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

        #region Documentation
        /// Get api/Order/{id}
        /// <summary>
        ///    Search for a specific Order by id
        /// </summary>
        /// <response code="200">
        ///    Returns Order found by id
        /// </response>
        /// <response code="400">Return with description of what is missing from the request
        /// </response>  
        #endregion
        [HttpGet]
        [Route("{id}")]
        [Authorize(Roles = UserRoles.Order_Search)]
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

        #region Documentation
        /// PUT api/DisheDrink
        /// <summary>
        /// Updates information of a Order found by id
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     POST
        ///     {
        ///       "id": 1,
        ///       "tableID": 10,
        ///       "requester": "Diego Marques",
        ///       "note": "Mustard sauce"
        ///     }
        ///
        /// </remarks>
        /// <response code="200">
        /// Return will be the Order updated with the information sent
        /// </response>
        /// <response code="400">Return with description of what is missing from the request
        /// </response>  
        #endregion
        [HttpPut]
        [Authorize(Roles = UserRoles.Order_Edit)]
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

        #region Documentation
        /// Delete api/Order/{id}
        /// <summary>
        ///  Remove a Order by ID code
        /// </summary>
        /// <response code="200">
        ///    Return will be that Order was successfully removed
        /// </response>
        /// <response code="400">Return with description of what is missing from the request
        /// </response>  
        #endregion
        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = UserRoles.Order_Delete)]
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
