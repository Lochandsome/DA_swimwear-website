using DAChuyenNganh.Application.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAChuyenNganh.Application.Interfaces
{
    public interface IProductService : IDisposable
    {
        List<ProductViewModel> GetAll();
    }
}
