using HR.LeaveManagement.Domain;
using Solution.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Application.DTOs
{
    public class LeaveRequestListDto : BaseDto
    {
        public LeaveTypeDto? LeaveType { get; set; }
        public DateTime DateRequested { get; set; }
        public bool Approved { get; set; }
    }
}
