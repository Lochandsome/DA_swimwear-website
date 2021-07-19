using System;
using System.Collections.Generic;
using System.Text;

namespace DAChuyenNganh.Utilities.Dtos
{
    public abstract class PagedResultBase
    {   //trang hiện tại
        public int CurrentPage { get; set; }

        public int PageCount
        {
            get
            {
                var pageCount = (double)RowCount / PageSize;
                return (int)Math.Ceiling(pageCount);
            }
            set { PageCount = value; }
        }
        public int PageSize { get; set; }
        // tổng số bản ghi
        public int RowCount { get; set; }
        //trang đầu tiên, dòng đầu tiên
        public int FirstRowOnPage
        {
            get
            {
                return (CurrentPage - 1) * PageSize + 1;
            }
        }
        //trang cuối 
        public int LastRowOnPage
        {
            get
            {
                return Math.Min(CurrentPage * PageSize, RowCount);
            }
        }
    }
}
