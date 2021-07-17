using DAChuyenNganh.Data.Entities;
using DAChuyenNganh.Data.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAChuyenNganh.Data.EF.Repositories
{
    public class ProductRepository : EFRepository<Product, int>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }
    }
}
