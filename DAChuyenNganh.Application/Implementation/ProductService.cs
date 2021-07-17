using AutoMapper.QueryableExtensions;
using DAChuyenNganh.Application.Interfaces;
using DAChuyenNganh.Application.ViewModels.Product;
using DAChuyenNganh.Data.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAChuyenNganh.Application.Implementation
{
    public class ProductService : IProductService
    {
        IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public List<ProductViewModel> GetAll()
        {
            return _productRepository.FindAll(x => x.ProductCategory).ProjectTo<ProductViewModel>().ToList();
        }
    }
}
