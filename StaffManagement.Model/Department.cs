using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffManagement.Model
{
    public class Department : BaseModel
    {
        public virtual List<Staff> Staffs { get; set; } = new();
    }
}
