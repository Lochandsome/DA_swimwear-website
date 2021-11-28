﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DAChuyenNganh.Application.Dapper.ViewModels
{
    public class RevenueReportViewModel
    {
        public DateTime Date { get; set; }
        public decimal Revenue { get; set; }
        // trên là doanh số, dưới là lợi nhuận.
        public decimal Profit { get; set; }
    }
}
