using DAChuyenNganh.Application.Dapper.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAChuyenNganh.Application.Dapper.Interfaces
{
    public interface IReportService
    {
        Task<IEnumerable<RevenueReportViewModel>> GetReportAsync(string fromDate, string toDate);

        Task<IEnumerable<RevenueReportViewModel>> GetAll();

    }
}
