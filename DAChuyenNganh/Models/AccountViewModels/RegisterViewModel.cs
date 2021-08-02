using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DAChuyenNganh.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Chưa nhập tên đăng nhập", AllowEmptyStrings = false)]
        [Display(Name = "Full name")]
        public string FullName { set; get; }

        [Display(Name = "DOB")]
        public DateTime? BirthDay { set; get; }

        [Required(ErrorMessage = "Chưa nhập địa chỉ Email", AllowEmptyStrings = false)]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Chưa nhập mật khẩu", AllowEmptyStrings = false)]
        [StringLength(100, ErrorMessage = "Mật khẩu phải >6 và có 1 kí tự đặc biệt.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Mật khẩu nhập lại không đúng.")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Chưa nhập số điện thoại", AllowEmptyStrings = false)]
        [Display(Name = "Phone number")]
        public string PhoneNumber { set; get; }

        [Display(Name = "Avatar")]
        public string Avatar { get; set; }
    }
}
