﻿using JinjiProject.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JinjiProject.Dtos.Genres
{
    public class ListGenreDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? Title { get; set; }
        public string ImagePath { get; set; }
        public bool? IsOnHomePage { get; set; }
        public int? Order { get; set; }
        public DateTime DeletedDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string StatusName { get; set; }
        public string CategoryName { get; set; }
        public int CategoryId { get; set; }
    }
}
