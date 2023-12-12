using Solution.Application.Contracts.Persistence;
using Solution.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Persistence.Repositories {
    public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository {

        private readonly SolutionDbContext _dbContext;

        public LeaveTypeRepository (SolutionDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
