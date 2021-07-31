using DAChuyenNganh.Application.ViewModels.Product;
using DAChuyenNganh.Utilities.Dtos;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAChuyenNganh.Models.ProductViewModels
{
    public class CatalogViewModel
    {
        public PagedResult<ProductViewModel> Data { get; set; }

        public ProductCategoryViewModel Category { set; get; }

        public string SortType { set; get; }

        public int? PageSize { set; get; }
        // SortType là danh sách vị trí sắp xếp
        public List<SelectListItem> SortTypes { get; } = new List<SelectListItem>
        {
            new SelectListItem(){Value = "lastest",Text = "Lastest"},
            new SelectListItem(){Value = "price",Text = "Price"},
            new SelectListItem(){Value = "name",Text = "Name"},
        };
        // cái này để liệt kê ra cho dropdown pagesize
        public List<SelectListItem> PageSizes { get; } = new List<SelectListItem>
        {
            new SelectListItem(){Value = "5",Text = "5"},
            new SelectListItem(){Value = "10",Text = "10"},
            new SelectListItem(){Value = "15",Text = "15"},
        };
    }
}
