using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Solution.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Persistence.Configurations.Entities
{
    public class LeaveTypeConfiguration : IEntityTypeConfiguration<LeaveType>
    {
        public void Configure (EntityTypeBuilder<LeaveType> builder)
        {
            builder.HasData
            (
                new LeaveType
                {
                    Id = 1,
                    Name = "Vacation",
                    DefaultDays = 10
                },
                new LeaveType
                {
                    Id = 2,
                    Name = "Sick",
                    DefaultDays = 10
                },
                new LeaveType
                {
                    Id = 3,
                    Name = "Maternity",
                    DefaultDays = 12
                },
                new LeaveType
                {
                    Id = 4,
                    Name = "Paternity",
                    DefaultDays = 17
                },
                new LeaveType
                {
                    Id = 5,
                    Name = "Bereavement",
                    DefaultDays = 3
                }
            );
        }
    }
}
