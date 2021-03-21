using Business.Abstract;
using Core.Utilities.FileOperations;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImageService _carImageService;
        IConfiguration _configuration;

        public CarImagesController(ICarImageService carImageService, IConfiguration configuration)
        {
            _carImageService = carImageService;
            _configuration = configuration;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById([FromForm(Name = ("Id"))] int id)
        {
            var result = _carImageService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add([FromForm] IFormFile imageFile, [FromForm] CarImage entity)
        {
            entity.ImagePath = Guid.NewGuid() + Path.GetExtension(imageFile.FileName);
            var result = _carImageService.Add(entity);
            if (result.Success)
            {
                Operation.WriteImageFile(imageFile, _configuration.GetSection("ImageRootPath").Value, entity.ImagePath);
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update([FromForm] IFormFile imageFile, [FromForm] CarImage entity)
        {
            var deleted = _carImageService.GetById(entity.CarImageId);
            if (deleted.Success)
            {
                Operation.DeleteImageFile(_configuration.GetSection("ImageRootPath").Value, deleted.Data.Single().ImagePath);
            }

            entity.ImagePath = Guid.NewGuid() + Path.GetExtension(imageFile.FileName);
            var updated = _carImageService.Update(entity);
            if (updated.Success)
            {
                Operation.WriteImageFile(imageFile, _configuration.GetSection("ImageRootPath").Value, entity.ImagePath);
                return Ok(updated);
            }
            return BadRequest(updated);
        }
        [HttpPost("delete")]
        public IActionResult Delete([FromForm] CarImage entity)
        {
            var result = _carImageService.GetById(entity.CarImageId);
            if (result.Success)
            {
                Operation.DeleteImageFile(_configuration.GetSection("ImageRootPath").Value, result.Data.Single().ImagePath);
                var deleted = _carImageService.Delete(entity);
                if (deleted.Success) return Ok(deleted);
            }
            return BadRequest();
        }
        [HttpGet("getimagesbycar")]
        public IActionResult GetImagesByCarId(int carId)
        {
            var result = _carImageService.GetImagesByCarId(carId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
