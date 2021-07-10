using System;
using System.Collections.Generic;
using System.Text;

namespace DAChuyenNganh.Data.Interfaces
{
    public interface IHasSeoMetaData
    {
        //Tiêu đề trang SEO
        string SeoPageTitle { set; get; }
        //đường dẫn truyền sang html hay url file
        string SeoAlias { set; get; }
        //từ khóa tìm kiếm nhanh kiểu giống tra Google
        string SeoKeywords { set; get; }
        //tiêu đề trang SEO
        string SeoDescription { get; set; }
    }
}
