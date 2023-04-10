﻿using Api_Restaurant_Order.Application.DTOs;
using Api_Restaurant_Order.Application.DTOs.Validations;
using Api_Restaurant_Order.Application.Services.Interface;
using Api_Restaurant_Order.Domain.Entities;
using Api_Restaurant_Order.Domain.Integrations;
using Api_Restaurant_Order.Domain.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

namespace Api_Restaurant_Order.Application.Services
{
    public class PhotoDisheDrinkService : IPhotoDisheDrinkService
    {
        private readonly IPhotoDisheDrinkRepository _photoDisheDrinkRepo;
        private readonly IMapper _mapper;
        private readonly IDisheDrinkRepository _disheDrinkRepo;
        private readonly ISaveFile _saveFile;
        private readonly string[] extensions = { "png", "jpg", "ico", "bmp" };

        public PhotoDisheDrinkService(IPhotoDisheDrinkRepository photoDisheDrinkRepo, IMapper mapper, IDisheDrinkRepository disheDrinkRepo, ISaveFile saveFile)
        {
            _photoDisheDrinkRepo = photoDisheDrinkRepo;
            _mapper = mapper;
            _disheDrinkRepo = disheDrinkRepo;
            _saveFile = saveFile;
        }

        public async Task<ResultService> CreateAsync(PhotoDisheDrinkDTO photoDisheDrinkDTO)
        {
            if (photoDisheDrinkDTO == null)
                return ResultService.Fail("Objeto deve ser informado");

            var validations = new PhotoDisheDrinkDTOValidator().Validate(photoDisheDrinkDTO);
            if (!validations.IsValid)
                return ResultService.RequestError("Problemas com a validação", validations);

            var disheDrink = await _photoDisheDrinkRepo.GetByIdAsync(photoDisheDrinkDTO.DisheDrinkId);
            if (disheDrink == null)
                return ResultService.Fail("Prato ou Bebida não encontrado");

            int SizeinKB = (int)photoDisheDrinkDTO.File.Length / 1024;

            if (SizeinKB > 512)
                return ResultService.Fail("Arquivo maior que 512 Kylobytes, tamanho original: " + SizeinKB);

            string nomeInvertido = new string(photoDisheDrinkDTO.File.FileName.Reverse().ToArray());
            string extFile = nomeInvertido.Substring(0, nomeInvertido.IndexOf('.'));
            extFile = new string(extFile.Reverse().ToArray());


            if (!extensionAccepted(extFile))
                return ResultService.Fail("Tipo de imagem não permitido, apenas: " + string.Join(", ", extensions));

            await using var memoryStream = new MemoryStream();
            await photoDisheDrinkDTO.File.CopyToAsync(memoryStream);

            var patthImage = _saveFile.Save(memoryStream.ToArray(), extFile);

            var photoDisheDrink = new  PhotoDisheDrink(disheDrink.Id, patthImage);
            await _photoDisheDrinkRepo.CreateAsync(photoDisheDrink);

            return ResultService.Ok("Image salva");
        }

        public async Task<ActionResult> GetDownloadImageAsync(int idPhoto)
        {
            if (idPhoto <= 0)
                throw new Exception("Id da foto deve ser informado");

            var photo = await _photoDisheDrinkRepo.GetByIdAsync(idPhoto);

            if (photo == null)
                throw new Exception("Foto não encontrada");

            if (string.IsNullOrEmpty(photo.Url))
                throw new Exception("Foto não encontrada");


            var fileStream = new FileStream(photo.Url, FileMode.Open, FileAccess.Read);

            return new FileStreamResult(fileStream, new MediaTypeHeaderValue("application/octet-stream"))
            {
                FileDownloadName = Path.GetFileName(photo.Url).ToLower()
            };
        }

        public async Task<ResultService<ICollection<int>>> GetPhotosAsync(int disheDrinkId)
        {
            if (disheDrinkId <= 0)
                return ResultService.Fail<ICollection<int>>("Id do Prato ou Bebida deve ser informado");

            var disheDrinkPhoto = await _photoDisheDrinkRepo.GetPhotoDisheDrinkAsync(disheDrinkId);

            return ResultService.Ok<ICollection<int>>(_mapper.Map<ICollection<int>>(disheDrinkPhoto));
        }

        private bool extensionAccepted(string extFile)
        {
            if (extensions.Contains(extFile)) return true;

            return false;
        }
    }
}