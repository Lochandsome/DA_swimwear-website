using DAChuyenNganh.Data.Entities;
using DAChuyenNganh.Data.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAChuyenNganh.Data.EF.Repositories
{
    public class FeedbackRepository : EFRepository<Feedback, int>, IFeedbackRepository
    {
        public FeedbackRepository(AppDbContext context) : base(context)
        {
        }
    }
}
