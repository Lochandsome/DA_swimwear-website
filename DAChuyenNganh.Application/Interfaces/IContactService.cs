using DAChuyenNganh.Application.ViewModels.Common;
using DAChuyenNganh.Utilities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAChuyenNganh.Application.Interfaces
{
    public interface IContactService
    {
        void Add(ContactViewModel contactVm);

        void Update(ContactViewModel contactVm);

        void Delete(string id);

        List<ContactViewModel> GetAll();

        PagedResult<ContactViewModel> GetAllPaging(string keyword, int page, int pageSize);

        ContactViewModel GetById(string id);

        void SaveChanges();
    }
}
