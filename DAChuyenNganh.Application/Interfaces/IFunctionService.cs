using DAChuyenNganh.Application.ViewModels.System;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAChuyenNganh.Application.Interfaces
{
    public interface IFunctionService : IDisposable
    {   //get all lấy ra toàn bộ danh sách
        Task<List<FunctionViewModel>> GetAll();
        // cái này thì dùng trong phân quyền, lấy theo cái permission
        List<FunctionViewModel> GetAllByPermission(Guid userId);
    }
}
