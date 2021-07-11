using System;
using System.Collections.Generic;
using System.Text;

namespace DAChuyenNganh.Data.Enums
{
    public enum BillStatus
    {
        //mới
        New,
        //đang xử lý
        InProgress,
        //trả lại
        Returned,
        //hủy
        Cancelled,
        //hoàn thành
        Completed
    }
}
