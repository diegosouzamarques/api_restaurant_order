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
    public class DisheDrinkController : ControllerBase
    {
        private readonly IDisheDrinkService _disheDrinkService;

        public DisheDrinkController(IDisheDrinkService disheDrinkService)
        {
            _disheDrinkService = disheDrinkService;
        }

        #region Documentation
        /// POST api/DisheDrink
        /// <summary>
        /// Creates a Dish or Drink in the DisheDrink entity
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     POST
        ///     {
        ///       "kind": 1,
        ///       "title": "Tomato soup",
        ///       "descript": "Tomato soup is a soup with tomatoes as the primary ingredient",
        ///       "origin": "USA",
        ///       "type": "Vegetables",
        ///       "volume": 350,
        ///       "price": 15,50
        ///     }
        ///
        /// </remarks>
        /// <response code="200">
        /// Return will be dish or drink registered with id
        /// </response>
        /// <response code="400">Return with description of what is missing from the request
        /// </response>  
        #endregion
        [HttpPost]
        [Authorize(Roles = UserRoles.DisheDrink_Register)]
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

        #region Documentation
        /// Get api/DisheDrink
        /// <summary>
        ///    Search all registered dishes and drinks
        /// </summary>
        /// <response code="200">
        /// Returns list containing all dishes and drinks
        /// </response>
        /// <response code="400">Return with description of what is missing from the request
        /// </response>  
        #endregion
        [HttpGet]
        [Authorize(Roles = UserRoles.DisheDrink_Search)]
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

        #region Documentation
        /// Get api/DisheDrink/{id}
        /// <summary>
        ///    Search for a specific dish or drink by id
        /// </summary>
        /// <response code="200">
        ///    Returns dish or drink found by id
        /// </response>
        /// <response code="400">Return with description of what is missing from the request
        /// </response>  
        #endregion
        [HttpGet]
        [Route("{id}")]
        [Authorize(Roles = UserRoles.DisheDrink_Search)]
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

        #region Documentation
        /// PUT api/DisheDrink
        /// <summary>
        /// Updates information of a dish or drink found by id
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     POST
        ///     {
        ///       "id": 1,
        ///       "kind": 1,
        ///       "title": "Tomato soup",
        ///       "descript": "Tomato soup is a soup with tomatoes as the primary ingredient",
        ///       "origin": "USA",
        ///       "type": "Vegetables",
        ///       "volume": 350,
        ///       "price": 15,50
        ///     }
        ///
        /// </remarks>
        /// <response code="200">
        /// Return will be the dish or drink updated with the information sent
        /// </response>
        /// <response code="400">Return with description of what is missing from the request
        /// </response>  
        #endregion
        [HttpPut]
        [Authorize(Roles = UserRoles.DisheDrink_Edit)]
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

        #region Documentation
        /// Delete api/DisheDrink/{id}
        /// <summary>
        ///  Remove a dish or drink by ID code
        /// </summary>
        /// <response code="200">
        ///    Return will be that dish or drink was successfully removed
        /// </response>
        /// <response code="400">Return with description of what is missing from the request
        /// </response>  
        #endregion
        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = UserRoles.DisheDrink_Delete)]
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
