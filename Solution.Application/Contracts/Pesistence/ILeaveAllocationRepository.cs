﻿using Solution.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Application.Contracts.Persistence {
    public interface ILeaveAllocationRepository : IGenericRepository<LeaveAllocation> {
        Task<LeaveAllocation> GetLeaveAllocationWithDetails (int id);
        Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails ( );
    }
}
