using DAChuyenNganh.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAChuyenNganh.Data.Interfaces
{
    public interface ISwitchable
    {
        Status Status { set; get; }
    }
}
