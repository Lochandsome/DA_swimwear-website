using DAChuyenNganh.Application.Dapper.Interfaces;
using DAChuyenNganh.Application.Dapper.ViewModels;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace DAChuyenNganh.Application.Dapper.Implementation
{
    public class ReportService : IReportService
    {
        private readonly IConfiguration _configuration;

        public ReportService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // viết cúng giống ADO vậy.
        public async Task<IEnumerable<RevenueReportViewModel>> GetReportAsync(string fromDate, string toDate)
        {
            using (var sqlConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                await sqlConnection.OpenAsync();
                // nó sẽ là 1 tập dyamicPrameters
                var dynamicParameters = new DynamicParameters(); 
                var now = DateTime.Now;

                var firstDayOfMonth = new DateTime(now.Year, now.Month, 1);
                var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
                // sau đó ép nó vào từ data sẽ truyền sang, nếu mặc định 2 dòng dưới là null thì sẽ lấy ngày đầu tiên của tháng, trong tháng này, trong tháng hiện tại.
                dynamicParameters.Add("@fromDate", string.IsNullOrEmpty(fromDate) ? firstDayOfMonth.ToString("MM/dd/yyyy") : fromDate);
                dynamicParameters.Add("@toDate", string.IsNullOrEmpty(toDate) ? lastDayOfMonth.ToString("MM/dd/yyyy") : toDate);
                // sau khi query thì sẽ tạo 2 tham số là formdate và todate và trả về tự map sang đối tượng revenueReportViewModel thủ tục 1 nghiệp vụ thì đặt hêt trong getrevenue lấy theo từng nhánh 1
                try
                {
                    return await sqlConnection.QueryAsync<RevenueReportViewModel>(
                        "GetRevenueDaily", dynamicParameters, commandType: CommandType.StoredProcedure);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
    }
}
