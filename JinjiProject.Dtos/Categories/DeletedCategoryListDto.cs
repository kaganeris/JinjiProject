﻿using JinjiProject.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JinjiProject.Dtos.Categories
{
    public class DeletedCategoryListDto
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DeletedDate { get; set; }
        public string StatusName { get; set; }
    }
}
