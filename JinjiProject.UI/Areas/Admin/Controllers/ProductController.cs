﻿using AutoMapper;
using JinjiProject.BusinessLayer.Managers.Abstract;
using JinjiProject.BusinessLayer.Validator.ProductValidations;
using JinjiProject.Core.Enums;
using JinjiProject.Dtos.Products;
using JinjiProject.UI.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace JinjiProject.UI.Areas.Admin.Controllers
{
        [Area("Admin")]
    public class ProductController : BaseController
    {

        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> ProductList(bool showWarning = true)
        {
            var productListResult = await _productService.GetAllByExpression(product => product.Status != Status.Deleted);
            var productList = _mapper.Map<List<ListProductDto>>(productListResult.Data);

            if ((productList.Count <= 0 || productList == null) && showWarning)
            {
                NotifyError(productListResult.Message);
            }
            else if (showWarning)
            {
                NotifySuccess(productListResult.Message);
            }

            return View(productList);
        }


        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {

            CreateProductValidator validations = new CreateProductValidator();
            var result = validations.Validate(createProductDto);

            if (result.IsValid)
            {
                var createProductResult = await _productService.CreateProductAsync(createProductDto);
                if (createProductResult.IsSuccess)
                {
                    NotifySuccess(createProductResult.Message);
                }
                else
                {
                    NotifyError(createProductResult.Message);

                }
                return RedirectToAction(nameof(ProductList), new { showWarning = false });
            }

            foreach (var item in result.Errors)
            {
                if (item.ErrorCode == "1")
                {
                    ViewData["NameError"] += item.ErrorMessage + "\n";
                }
                else
                {
                    ViewData["DescriptionError"] += item.ErrorMessage + "\n";

                }
            }
            return View(createProductDto);

        }



        [HttpGet]
        public async Task<IActionResult> UpdateProduct(int id)
        {
            var updateProductResult = await _productService.GetProductById(id);
            if (updateProductResult.IsSuccess)
            {
                UpdateProductDto updateProduct = _mapper.Map<UpdateProductDto>(updateProductResult.Data);
                return View(updateProduct);

            }
            else
            {
                UpdateProductDto updateProduct = _mapper.Map<UpdateProductDto>(updateProductResult.Data);
                NotifyError(updateProductResult.Message);
                return RedirectToAction(nameof(ProductList), new { showWarning = false });
            }



        }


        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            UpdateProductValidator updateProductValidator = new UpdateProductValidator();
            var result = updateProductValidator.Validate(updateProductDto);

            if (result.IsValid)
            {
                var updateProductResult = await _productService.UpdateProductAsync(updateProductDto);

                if (updateProductResult.IsSuccess)
                {

                    NotifySuccess(updateProductResult.Message);

                }
                else
                {
                    NotifyError(updateProductResult.Message);
                }

                return RedirectToAction(nameof(ProductList), new { showWarning = false });
            }

            foreach (var item in result.Errors)
            {
                if (item.ErrorCode == "1")
                {
                    ViewData["NameError"] += item.ErrorMessage + "\n";
                }
                else
                {
                    ViewData["DescriptionError"] += item.ErrorMessage + "\n";

                }
            }
            return View(updateProductDto);


        }


        [HttpGet]
        public async Task<IActionResult> SoftDelete(int id)
        {

            var softDeleteResult = await _productService.SoftDeleteProductAsync(id);


            if (softDeleteResult.IsSuccess)
            {
                NotifySuccess(softDeleteResult.Message);


                return RedirectToAction(nameof(ProductList), new { showWarning = false });
            }
            else
            {
                if (softDeleteResult.Data == null)
                {
                    NotifyError(softDeleteResult.Message);

                    return RedirectToAction(nameof(ProductList), new { showWarning = false });
                }
                NotifyError(softDeleteResult.Message);

                return RedirectToAction(nameof(ProductList), new { showWarning = false });
            }


        }



        [HttpGet]
        public async Task<IActionResult> HardDelete(int id)
        {

            await _productService.HardDeleteProductAsync(id);

            return RedirectToAction(nameof(ProductList));
        }


        [HttpGet]
        public async Task<GetProductDto> GetProduct(int productid)
        {

            var productResult = await _productService.GetProductById(productid);

            return productResult.Data;
        }

        [HttpGet]
        public async Task<IActionResult> DeletedProductList(bool showWarning = true)
        {

            var deletedProduct = await _productService.GetAllByExpression(x => x.Status == Status.Deleted);
            List<DeletedProductListDto> deletedProductList = _mapper.Map<List<DeletedProductListDto>>(deletedProduct.Data);


            if ((deletedProductList.Count <= 0 || deletedProductList == null) && showWarning)
            {
                NotifyError("Silinen Kategori Listesi Boş");
            }
            else if (showWarning)
            {
                NotifySuccess("Silinen Kategoriler Listelendi");

            }
            return View(deletedProductList);

        }


        [HttpGet]
        public async Task<IActionResult> AddAgainProduct(int id)
        {
            var productToAdded = await _productService.GetProductById(id);

            if (productToAdded.Data == null)
            {
                NotifyError(productToAdded.Message);
                return RedirectToAction(nameof(DeletedProductList), new { showWarning = false });
            }
            else
            {

                productToAdded.Data.Status = Status.Active;
                UpdateProductDto updatedToProduct = _mapper.Map<UpdateProductDto>(productToAdded.Data);

                var productToUpdated = await _productService.UpdateProductAsync(updatedToProduct);
                NotifySuccess("Kategori yeniden eklendi.");

                return RedirectToAction(nameof(DeletedProductList), new { showWarning = false });
            }
        }
    }
}