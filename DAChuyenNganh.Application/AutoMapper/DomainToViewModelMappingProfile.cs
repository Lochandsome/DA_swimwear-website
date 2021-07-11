using AutoMapper;
using DAChuyenNganh.Application.ViewModels.Product;
using DAChuyenNganh.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAChuyenNganh.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<ProductCategory, ProductCategoryViewModel>();
        }
    }
}
