using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffManagement.DataTransfer.Staff
{
    public class StaffCreateRequest : BaseRequest
    {
        public int departmentId { get; set; }
    }
}
