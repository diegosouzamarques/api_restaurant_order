using Api_Restaurant_Order.Application.DTOs;
using Api_Restaurant_Order.Application.Services;
using Api_Restaurant_Order.Application.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Api_Restaurant_Order.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoDisheDrinkController : ControllerBase
    {
        private readonly IPhotoDisheDrinkService _photoService;

        public PhotoDisheDrinkController(IPhotoDisheDrinkService photoService)
        {
            _photoService = photoService;
        }

        [HttpPost]
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


        [HttpGet]
        [Route("{DisheDrinkId}")]
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


        [HttpGet]
        [Route("download/{idPhoto}")]
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
    }
}
