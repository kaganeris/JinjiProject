﻿using JinjiProject.Core.Entities.Concrete;
using JinjiProject.Core.Utilities.Results.Concrete;
using JinjiProject.Dtos.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JinjiProject.BusinessLayer.Managers.Abstract
{
    public interface ICategoryService
    {
        public Task<DataResult<Category>> CreateCategoryAsync(CreateCategoryDto createCategoryDto);
        public Task<DataResult<Category>> UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);
        public Task<DataResult<List<Category>>> UpdateAllCategoryAsync(List<UpdateCategoryDto> updateCategoryDto);
        public Task<DataResult<Category>> SoftDeleteCategoryAsync(int id);
        public Task<DataResult<List<ListCategoryDto>>> GetAllByExpression(Expression<Func<Category, bool>> expression);

        public Task<DataResult<Category>> HardDeleteCategoryAsync(int id);
        public Task<DataResult<List<ListCategoryDto>>> GetAllCategory();
        public Task<DataResult<GetCategoryDto>> GetCategoryById(int id);
        public Task<DataResult<GetCategoryDto>> GetFilteredCategory(Expression<Func<Category, bool>> expression);
    }
}
