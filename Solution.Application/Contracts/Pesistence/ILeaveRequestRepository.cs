using Solution.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Application.Contracts.Persistence {
    public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest> {
        Task<LeaveRequest> GetLeaveRequestWithDetails (int id);
        Task<List<LeaveRequest>> GetLeaveRequestsWithDetails ( );
        Task ChangeApprovalStatus (LeaveRequest leaveRequest, bool? ApprovalStatus);
    }
}
