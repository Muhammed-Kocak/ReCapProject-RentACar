using Core.Entities.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CarImagesDto : IDto
    {
        public int Id { get; set; } = 0;
        public int CarId { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
