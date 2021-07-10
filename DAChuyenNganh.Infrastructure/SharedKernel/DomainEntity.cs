using System;
using System.Collections.Generic;
using System.Text;

namespace DAChuyenNganh.Infrastructure.SharedKernel
{
    public abstract class DomainEntity<T>
    {
        // triển khai hàm này để cho nhưng entity nào kế thừa nó có thể truyền vào kiểu dữ liệu ID
        public T Id { get; set; }

        /// <summary>
        /// True if domain entity has an identity
        /// </summary>
        /// <returns></returns>
        public bool IsTransient()
        {
            return Id.Equals(default(T));
        }
    }
}
