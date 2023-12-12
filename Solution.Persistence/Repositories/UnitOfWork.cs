using Solution.Application.Contracts.Persistence;
using Solution.Application.Contracts.Pesistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SolutionDbContext _dbContext;

        private ILeaveAllocationRepository _leaveAllocationRepository;
        private ILeaveRequestRepository _leaveRequestRepository;
        private ILeaveTypeRepository _leaveTypeRepository;

        public UnitOfWork (SolutionDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ILeaveAllocationRepository LeaveAllocationRepository => _leaveAllocationRepository ??= new LeaveAllocationRepository(_dbContext);

        public ILeaveRequestRepository LeaveRequestRepository => _leaveRequestRepository ??= new LeaveRequestRepository(_dbContext);

        public ILeaveTypeRepository LeaveTypeRepository => _leaveTypeRepository ??= new LeaveTypeRepository(_dbContext);

        public void Dispose ( )
        {
            _dbContext.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save ( )
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
