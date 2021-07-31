using DAChuyenNganh.Data.Entities;
using DAChuyenNganh.Data.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAChuyenNganh.Data.EF.Repositories
{
    public class FooterRepository : EFRepository<Footer, string>, IFooterRepository
    {
        public FooterRepository(AppDbContext context) : base(context)
        {
        }
    }
}
