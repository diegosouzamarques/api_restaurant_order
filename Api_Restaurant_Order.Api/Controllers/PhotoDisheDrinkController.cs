using Api_Restaurant_Order.Api.Controllers.Authorization;
using Api_Restaurant_Order.Application.DTOs;
using Api_Restaurant_Order.Application.Services;
using Api_Restaurant_Order.Application.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Api_Restaurant_Order.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoDisheDrinkController : ControllerBase
    {
        private readonly IPhotoDisheDrinkService _photoService;

        public PhotoDisheDrinkController(IPhotoDisheDrinkService photoService)
        {
            _photoService = photoService;
        }

        #region Documentation
        /// POST api/PhotoDisheDrink
        /// <summary>
        ///    Registering and storing the image linked to a dish or drink
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     POST
        ///     {
        ///       "DisheDrinkId": "5",
        ///       "File": "imagem em bytes"
        ///     }
        ///
        /// </remarks>
        /// <response code="200">
        ///   Return will be recorded and image storage 
        /// </response>
        /// <response code="400">Return with description of what is missing from the request
        /// </response>  
        #endregion
        [HttpPost]
        [Authorize(Roles = UserRoles.Photo_Register)]
        public async Task<ActionResult> CreateImageAsync([FromForm] PhotoDisheDrinkDTO photoDisheDrinkDTO)
        {
            try
            {
                var result = await _photoService.CreateAsync(photoDisheDrinkDTO);
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
        /// Get api/PhotoDisheDrink/{DisheDrinkId}
        /// <summary>
        ///   Search all image records of a dish or drink by ID code
        /// </summary>
        /// <response code="200">
        ///    The return will be a list containing all the ID's of the images of the dish or drink located by the ID code
        /// </response>
        /// <response code="400">Return with description of what is missing from the request
        /// </response>  
        #endregion
        [HttpGet]
        [Route("{DisheDrinkId}")]
        [Authorize(Roles = UserRoles.Photo_Search)]
        public async Task<ActionResult> GetByIdAsync(int DisheDrinkId)
        {
            try
            {
                var result = await _photoService.GetPhotosAsync(DisheDrinkId);
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
        /// Get api/PhotoDisheDrink/download/{idPhoto}
        /// <summary>
        ///   Search image located through the entered id code
        /// </summary>
        /// <response code="200">
        ///    Return will be download of localized image
        /// </response>
        /// <response code="400">Return with description of what is missing from the request
        /// </response>  
        #endregion
        [HttpGet]
        [Route("download/{idPhoto}")]
        [Authorize(Roles = UserRoles.Photo_Search)]
        public async Task<ActionResult> DownloadImg(int idPhoto)
        {

            try
            {
                return await _photoService.GetDownloadImageAsync(idPhoto);
            }
            catch (Exception ex)
            {
                var result = ResultService.Fail(ex.GetaAllMessages());

                return BadRequest(result);
            }


        }

        #region Documentation
        /// Delete api/PhotoDisheDrink/{id}
        /// <summary>
        ///  Remove a photo by ID code
        /// </summary>
        /// <response code="200">
        ///    Return will be that photo was successfully removed
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
                var result = await _photoService.DeleteImageAsync(id);

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
