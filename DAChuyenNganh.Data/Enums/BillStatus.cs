using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DAChuyenNganh.Data.Enums
{
    public enum BillStatus
    {
        //mới
        [Description("New bill")]
        New,
        //đang xử lý
        [Description("In Progress")]
        InProgress,
        //trả lại
        [Description("Returned")]
        Returned,
        //hủy
        [Description("Cancelled")]
        Cancelled,
        //hoàn thành
        [Description("Completed")]
        Completed
    }
}
