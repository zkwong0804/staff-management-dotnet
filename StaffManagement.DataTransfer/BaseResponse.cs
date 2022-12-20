using StaffManagement.DataTransfer.Contraints;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffManagement.DataTransfer
{
    public abstract class BaseResponse
    {
        public virtual int Id { get; set; }

        [Required]
        [StringLength(BaseContraint.NameMaxLength,
            MinimumLength = BaseContraint.NameMinLength)]
        public virtual string Name { get; set; } = String.Empty;
    }
}
