﻿using JinjiProject.Core.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JinjiProject.Dtos.Products
{
    public class UpdateProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public Size? Size { get; set; }
        public float? Height { get; set; }
        public float? Width { get; set; }
        public float? Length { get; set; }
        public float? StrapLength { get; set; }

        public string ImagePath { get; set; }
        public string? ImagePathSecond { get; set; }
        public string? ImagePathThirth { get; set; }
        public IFormFile UploadPath { get; set; }
        public IFormFile? UploadPathSecond { get; set; }
        public IFormFile? UploadPathThirth { get; set; }
        public int? Capacity { get; set; }
        public string MaterialId { get; set; }
        public string CategoryId { get; set; }
        public string BrandId { get; set; }
        public string GenreId { get; set; }


    }
}
