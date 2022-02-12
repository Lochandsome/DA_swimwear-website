using DAChuyenNganh.Application.Dapper.Interfaces;
using DAChuyenNganh.Application.Interfaces;
using DAChuyenNganh.Extensions;
using Dapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DAChuyenNganh.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IReportService _reportService;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IConfiguration _configuration;

        public HomeController(IReportService reportService, IHostingEnvironment hostingEnvironment, IConfiguration configuration)
        {
            _reportService = reportService;
            _hostingEnvironment = hostingEnvironment;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            var email = User.GetSpecificClaim("Email");

            return View();
        }

        public async Task<IActionResult> GetRevenue(string fromDate, string toDate)
        {
            return new OkObjectResult(await _reportService.GetReportAsync(fromDate, toDate));
        }
        //public async Task<IActionResult> ExportExcel(string fromDate, string toDate)
        //{
        //    using (var sqlConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
        //    {
        //        await sqlConnection.OpenAsync();
        //        var sql = string.Empty;
        //        // nó sẽ là 1 tập dyamicPrameters
        //        var dynamicParameters = new DynamicParameters();
        //        var now = DateTime.Now;

        //        var firstDayOfMonth = new DateTime(now.Year, now.Month, 1);
        //        var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
        //        // sau đó ép nó vào từ data sẽ truyền sang, nếu mặc định 2 dòng dưới là null thì sẽ lấy ngày đầu tiên của tháng, trong tháng này, trong tháng hiện tại.
        //        dynamicParameters.Add("@fromDate", string.IsNullOrEmpty(fromDate) ? firstDayOfMonth.ToString("yyyy-MM-dd") : fromDate);
        //        dynamicParameters.Add("@toDate", string.IsNullOrEmpty(toDate) ? lastDayOfMonth.ToString("yyyy-MM-dd") : toDate);
   

        //        string sWebRootFolder = _hostingEnvironment.WebRootPath;
        //        string sFileName = $"RevenueStatistic_{DateTime.Now:yyyy-MM-dd-yyyy-hh-mm-ss}.xlsx";

        //        string templateDocument = Path.Combine(sWebRootFolder, "templates", "RevenueTemplate.xlsx");

        //        string url = $"{Request.Scheme}://{Request.Host}/{"export-files"}/{sFileName}";
        //        FileInfo file = new FileInfo(Path.Combine(sWebRootFolder, "export-files", sFileName));
        //        if (file.Exists)
        //        {
        //            file.Delete();
        //            file = new FileInfo(Path.Combine(sWebRootFolder, sFileName));
        //        }
        //        //var result = await sqlConnection.OpenAsync<;
        //        var revenues = await _reportService.GetReportAsync(fromDate, toDate);
        //        using (ExcelPackage package = new ExcelPackage(file))
        //        {
        //            ExcelWorksheet workSheet = package.Workbook.Worksheets.Add("Revenue");                    
        //            var index = 2;
        //            foreach(var item in revenues)
        //            {
        //                workSheet.Cells["A" + index].Value = item.Date.ToString("yyyy-MM-dd");
        //                workSheet.Cells["B" + index].Value = item.Revenue;
        //                workSheet.Cells["C" + index].Value = item.Profit;
        //                index++;
        //            }
        //            // add a new worksheet to the empty workbook
                    
        //            workSheet.Cells.AutoFitColumns();
        //            package.Save(); //Save the workbook.
        //        }
        //        return new OkObjectResult(url);
        //    }
        //}


        public async Task<IActionResult> ExportExcel(string fromDate, string toDate)
        {
            using (var sqlConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                string sFileName = $"RevenueStatistic_{DateTime.Now:yyyy-MM-dd-yyyy-hh-mm-ss}.xlsx";
                await sqlConnection.OpenAsync();
                // nó sẽ là 1 tập dyamicPrameters
                var dynamicParameters = new DynamicParameters();
                var now = DateTime.Now;

                var firstDayOfMonth = new DateTime(now.Year, now.Month, 1);
                var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
                // sau đó ép nó vào từ data sẽ truyền sang, nếu mặc định 2 dòng dưới là null thì sẽ lấy ngày đầu tiên của tháng, trong tháng này, trong tháng hiện tại.
                dynamicParameters.Add("@fromDate", string.IsNullOrEmpty(fromDate) ? firstDayOfMonth.ToString("yyyy-MM-dd") : fromDate);
                dynamicParameters.Add("@toDate", string.IsNullOrEmpty(toDate) ? lastDayOfMonth.ToString("yyyy-MM-dd") : toDate);
                var sql = string.Empty;
                string sWebRootFolder = _hostingEnvironment.WebRootPath;
                string templateDocument = Path.Combine(sWebRootFolder, "templates", "RevenueTemplate.xlsx");
                string directory = Path.Combine(sWebRootFolder, "export-files");
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                string fileUrl = $"{Request.Scheme}://{Request.Host}/export-files/{sFileName}";
                FileInfo file = new FileInfo(Path.Combine(directory, sFileName));
                if (file.Exists)
                {
                    file.Delete();
                    file = new FileInfo(Path.Combine(sWebRootFolder, sFileName));
                }
                //var result = await sqlConnection.OpenAsync<;
                var revenues = await _reportService.GetReportAsync(fromDate, toDate);
                using (ExcelPackage package = new ExcelPackage(file))
                {
                    ExcelWorksheet workSheet = package.Workbook.Worksheets.Add("Revenue");
                    //var workSheet = package.Workbook.Worksheets.Add("Sheet1");
                    using (ExcelRange Rng = workSheet.Cells[1, 1, 1, 24])
                    {
                        
                        Rng.Style.Font.Bold = true;
                        Rng.Style.Font.Italic = true;
                        Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rng.Style.Fill.BackgroundColor.SetColor(Color.Aqua);
                        Rng.Style.Border.BorderAround(ExcelBorderStyle.Medium);
                    }
                    
                    
                    workSheet.Cells[1, 1].Value = "Ngày tạo";
                    workSheet.Cells[1, 2].Value = "Doanh thu";
                    workSheet.Cells[1, 3].Value = "Lợi nhuận";
                    var index = 2;
                    foreach (var item in revenues)
                    {
                        workSheet.Cells["A" + index].Value = item.Date.ToString("yyyy-MM-dd");
                        workSheet.Cells["B" + index].Value = item.Revenue;
                        workSheet.Cells["C" + index].Value = item.Profit;
                        workSheet.Cells[2, 5].Value = "=SUM(C:C)";
                        index++;                        
                    }
                    
                    // add a new worksheet to the empty workbook

                    workSheet.Cells.AutoFitColumns();
                    package.Save(); //Save the workbook.
                }
                return new OkObjectResult(fileUrl);
            }
        }


    }
}
