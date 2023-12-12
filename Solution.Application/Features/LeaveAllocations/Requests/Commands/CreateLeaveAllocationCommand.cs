﻿using MediatR;
using Solution.Application.DTOs.LeaveAllocation;
using Solution.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Application.Features.LeaveAllocations.Requests.Commands
{
    public class CreateLeaveAllocationCommand : IRequest<BaseCommandResponse>
    {
        public CreateLeaveAllocationDto CreateLeaveAllocationDto { get; set; }
    }
}
