using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Application.DTOs.LeaveType.Validators
{
    public class ILeaveTypeDtoValidator : AbstractValidator<ILeaveTypeDto>
    {
        public ILeaveTypeDtoValidator ( )
        {
            RuleFor(x => x.Name).NotEmpty().NotNull()
                .WithMessage("Name is required.")
                .MaximumLength(50);

            RuleFor(x => x.DefaultDays)
                .NotEmpty().WithMessage("Default days is required.")
                .NotNull().WithMessage("Default days is required.")
                .GreaterThan(0).WithMessage("Default days must be at least 1.")
                .LessThan(100);
        }
    }
}
