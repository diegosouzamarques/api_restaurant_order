using Api_Restaurant_Order.Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api_Restaurant_Order.Application.Services.Interface
{
    public interface IPhotoDisheDrinkService
    {
        Task<ResultService> CreateAsync(PhotoDisheDrinkDTO photoDisheDrinkDTO);
        Task<ResultService<ICollection<int>>> GetPhotosAsync(int disheDrinkId);
        Task<ActionResult> GetDownloadImageAsync(int idPhoto);
    }
}
