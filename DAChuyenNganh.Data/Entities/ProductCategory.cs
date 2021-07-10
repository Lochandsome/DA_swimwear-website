using DAChuyenNganh.Data.Enums;
using DAChuyenNganh.Data.Interfaces;
using DAChuyenNganh.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAChuyenNganh.Data.Entities
{
    public class ProductCategory : DomainEntity<int>, IHasSeoMetaData, ISwitchable, ISortable, IDateTracking
    {
        public ProductCategory()
        {
            Products = new List<Product>();
        }
        public string Name { get; set; }

        public string Description { get; set; }

        public int? ParentId { get; set; }

        public int? HomeOrder { get; set; }

        public string Image { get; set; }

        public bool? HomeFlag { get; set; }

        public DateTime DateCreated { set; get; }
        public DateTime DateModified { set; get; }
        public int SortOrder { get; set; }
        public Status Status { set; get; }
        public string SeoPageTitle { set; get; }
        public string SeoAlias { set; get; }
        public string SeoKeywords { set; get; }
        public string SeoDescription { set; get; }

        // tạo ra 1 cái khóa ngoại để hiển thị đến danh sách Product, vì nó chỉ đọc nên cần ICollection để hiệu chỉnh nó
        public virtual ICollection<Product> Products { set; get; }
        
    }
}
