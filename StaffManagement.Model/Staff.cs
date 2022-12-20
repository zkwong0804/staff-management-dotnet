using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffManagement.Model
{
    public class Staff : BaseModel
    {
        public int DepartmentID { get; set; }
        public virtual Department Department { get; set; }
    }
}
