﻿using AutoMapper;
using JinjiProject.BusinessLayer.Helpers;
using JinjiProject.Core.Entities.Concrete;
using JinjiProject.Core.Enums;
using JinjiProject.Dtos.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JinjiProject.BusinessLayer.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<UpdateProductDiscountDto, Product>().ReverseMap();
            CreateMap<UpdateProductDiscountDto, GetProductDto>().ReverseMap();
            CreateMap<CreateProductDto, Product>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap()
                .ForMember(dest => dest.ImagePath, opt => opt.Condition(src => src.ImagePath != null))
                .ForMember(dest => dest.ImagePathSecond, opt => opt.Condition(src => src.ImagePathSecond != null))
                .ForMember(dest => dest.ImagePathThirth, opt => opt.Condition(src => src.ImagePathThirth != null));
            CreateMap<GetProductDto, UpdateProductDto>().ReverseMap();
            CreateMap<Product, ListProductDto>().ForMember(dest => dest.GenreName, opt => opt.MapFrom(src => src.Genre.Name)).ForMember(dest => dest.StatusName, opt => opt.MapFrom(opt => GetEnumDescription.Description(opt.Status))).ReverseMap();
            
            CreateMap<ListProductDto, DeletedProductListDto>().ReverseMap();
            CreateMap<GetProductDto, Product>().ReverseMap()
                .ForMember(dest => dest.SizeName, opt => opt.MapFrom(opt => GetEnumDescription.Description(opt.Size)))
                .ForMember(dest => dest.GenreName, opt => opt.MapFrom(src => src.Genre.Name))
                .ForMember(dest => dest.MaterialName, opt => opt.MapFrom(src => src.Material.Name))
                .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand.Name));

            CreateMap<GetProductDto, CreateProductDto>().ReverseMap();
        }
    
    }
}
