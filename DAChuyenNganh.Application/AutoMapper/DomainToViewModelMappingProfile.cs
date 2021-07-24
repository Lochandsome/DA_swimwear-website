using AutoMapper;
using DAChuyenNganh.Application.ViewModels.Product;
using DAChuyenNganh.Application.ViewModels.System;
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
            CreateMap<Product, ProductViewModel>();
            CreateMap<Function, FunctionViewModel>();

            CreateMap<AppUser, AppUserViewModel>();
            CreateMap<AppRole, AppRoleViewModel>();

        }
    }
}
