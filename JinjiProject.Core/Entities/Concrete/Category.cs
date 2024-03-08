﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JinjiProject.Core.Entities.Concrete
{
	public class Category : BaseEntity
	{
		public Category()
		{
			Products = new List<Product>();
		}
		public string Name { get; set; }
		public string Description { get; set; }
		public bool? IsOnHomePage { get; set; }
		public int? Order { get; set; }
		public virtual List<Product> Products { get; set; }
	}
}
