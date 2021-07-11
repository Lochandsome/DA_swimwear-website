using DAChuyenNganh.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAChuyenNganh.Application.ViewModels.Product
{
    public class ProductCategoryViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int? ParentId { get; set; }

        public int? HomeOrder { get; set; }

        public string Image { get; set; }

        public bool? HomeFlag { get; set; }

        public DateTime DateCreated { set; get; }
        public DateTime DateModified { set; get; }
        public int SortOrder { set; get; }
        public Status Status { set; get; }
        public string SeoPageTitle { set; get; }
        public string SeoAlias { set; get; }
        public string SeoKeywords { set; get; }
        public string SeoDescription { set; get; }

        public ICollection<ProductViewModel> Products { set; get; }
    }
}
// 1 số ng hỏi tại sao không dùng entity luôn mà phải dùng viewmodel : tại vì đôi khi trong nghiêp vụ chúng ta muốn thêm
// 1 số thuôc tính nó giúp chúng ta taho tác bên ngoài , gộp 2 model lại thành 1, thif không bị phụ Thuộc vào entity, linh hoạt hơn
