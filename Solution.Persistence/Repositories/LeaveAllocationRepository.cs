using Microsoft.EntityFrameworkCore;
using Solution.Application.Contracts.Persistence;
using Solution.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Persistence.Repositories {
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository {

        private readonly SolutionDbContext _dbContext;

        public LeaveAllocationRepository (SolutionDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails ( )
        {
            var leaveAllocations = _dbContext.LeaveAllocations
                .Include(q => q.LeaveType)
                .ToListAsync();
            return leaveAllocations;
        }

        public Task<LeaveAllocation> GetLeaveAllocationWithDetails (int id)
        {
            var leaveAllocation = _dbContext.LeaveAllocations
                .Include(q => q.LeaveType)
                .FirstOrDefaultAsync(q => q.Id == id);
            return leaveAllocation;
        }
    }
}
