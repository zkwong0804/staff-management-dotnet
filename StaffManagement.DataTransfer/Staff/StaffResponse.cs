using StaffManagement.DataTransfer.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffManagement.DataTransfer.Staff
{
    public class StaffResponse : BaseResponse
    {
        public DepartmentResponse Department { get; set; }
    }
}
