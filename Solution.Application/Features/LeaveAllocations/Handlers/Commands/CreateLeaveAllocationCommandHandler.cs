using AutoMapper;
using MediatR;
using Solution.Application.DTOs.LeaveAllocation.Validators;
using Solution.Application.Features.LeaveAllocations.Requests.Commands;
using Solution.Application.Persistence.Contracts;
using Solution.Application.Responses;
using Solution.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Application.Features.LeaveAllocations.Handlers.Commands
{
    public class CreateLeaveAllocationCommandHandler : IRequestHandler<CreateLeaveAllocationCommand, BaseCommandResponse>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IMapper _mapper;

        public CreateLeaveAllocationCommandHandler (ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle (CreateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var validator = new CreateLeaveAllocationDtoValidator(_leaveAllocationRepository);
            var validationResult = await validator.ValidateAsync(request.LeaveAllocationDto);
            if (validationResult.IsValid == false) {
                response.Success = false;
                response.Message = "Leave Allocation Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }

            var leaveAllocation = _mapper.Map<LeaveAllocation>(request.LeaveAllocationDto);
            var createdLeaveAllocation = await _leaveAllocationRepository.Add(leaveAllocation);

            response.Success = true;
            response.Message = "Leave Allocation Created Successfully";
            response.Id = createdLeaveAllocation.Id;

            return response;
        }
    }
}
