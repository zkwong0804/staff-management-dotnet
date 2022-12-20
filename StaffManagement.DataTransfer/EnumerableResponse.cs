using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffManagement.DataTransfer
{
    public class EnumerableResponse<T> where T : BaseResponse
    {
        public IEnumerable<T> Responses { get; set; }
        public int Take { get; set; }
        public int Skip { get; set; }
        public int Total { get; set; }
        public string Query { get; set; }
    }
}
