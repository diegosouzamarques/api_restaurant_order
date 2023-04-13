using Api_Restaurant_Order.Api.Controllers.Authorization;
using Api_Restaurant_Order.Application.DTOs;
using Api_Restaurant_Order.Application.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api_Restaurant_Order.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ItemOrderController : ControllerBase
    {
        private readonly IItemOrderService _itemOrderService;

        public ItemOrderController(IItemOrderService itemOrderService)
        {
            _itemOrderService = itemOrderService;
        }

        #region Documentation
        /// POST api/ItemOrder
        /// <summary>
        ///   Registers an item linked to an order
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     POST
        ///     {
        ///       "disheDrinkId": 5,
        ///       "orderId": 10,
        ///       "price": 15.80
        ///     }
        ///
        /// </remarks>
        /// <response code="200">
        ///      Return will be a registration item linked to an order
        /// </response>
        /// <response code="400">Return with description of what is missing from the request
        /// </response>  
        #endregion
        [HttpPost]
        [Authorize(Roles = UserRoles.Item_Register)]
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

        #region Documentation
        /// Get api/ItemOrder/{id}
        /// <summary>
        ///    Search all items in an order
        /// </summary>
        /// <response code="200">
        ///    Returns all items linked to an order
        /// </response>
        /// <response code="400">Return with description of what is missing from the request
        /// </response>  
        #endregion
        [HttpGet]
        [Route("{id}")]
        [Authorize(Roles = UserRoles.Item_Search)]
        public async Task<ActionResult> GetByIdAsync(int OrderId)
        {
            try
            {
                var result = await _itemOrderService.GetItemsOrderAsync(OrderId);
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
        /// Delete api/ItemOrder/{id}
        /// <summary>
        ///   Removes an order item found by id
        /// </summary>
        /// <response code="200">
        ///    Return will be successfully removed order item
        /// </response>
        /// <response code="400">Return with description of what is missing from the request
        /// </response>  
        #endregion
        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = UserRoles.Item_Delete)]
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
