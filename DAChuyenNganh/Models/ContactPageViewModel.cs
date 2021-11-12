using DAChuyenNganh.Application.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAChuyenNganh.Models
{
    public class ContactPageViewModel
    {
        public ContactViewModel Contact { get; set; }

        public FeedbackViewModel Feedback { get; set; }        
    }
}
