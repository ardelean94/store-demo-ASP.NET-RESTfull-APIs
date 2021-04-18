using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Store_demo.Dto;
using Store_demo.Models;

namespace Store_demo.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Product, ProductDto>();
            Mapper.CreateMap<ProductDto, Product>();
        }
    }
}