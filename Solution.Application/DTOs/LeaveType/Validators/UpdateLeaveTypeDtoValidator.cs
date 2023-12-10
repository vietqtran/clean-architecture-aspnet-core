using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Application.DTOs.LeaveType.Validators
{
    public class UpdateLeaveTypeDtoValidator : AbstractValidator<LeaveTypeDto>
    {
        public UpdateLeaveTypeDtoValidator ( )
        {
            Include(new ILeaveTypeDtoValidator());

            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id is required.")
                .NotNull();
        }
    }
}
