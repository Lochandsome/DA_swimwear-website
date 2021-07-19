using DAChuyenNganh.Application.ViewModels.Product;
using DAChuyenNganh.Utilities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAChuyenNganh.Application.Interfaces
{
    public interface IProductService : IDisposable
    {
        List<ProductViewModel> GetAll();

        PagedResult<ProductViewModel> GetAllPaging(int? categoryId, string keyword, int page, int pageSize);

    }
}
