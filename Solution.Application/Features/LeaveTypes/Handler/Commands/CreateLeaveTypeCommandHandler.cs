using AutoMapper;
using Solution.Domain;
using MediatR;
using Solution.Application.Features.LeaveTypes.Requests.Commands;
using Solution.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solution.Application.DTOs.LeaveType.Validators;
using Solution.Application.Exceptions;

namespace Solution.Application.Features.LeaveTypes.Handler.Commands
{
    public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, int>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public CreateLeaveTypeCommandHandler (ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle (CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateLeaveTypeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CreateLeaveTypeDto);
            if (validationResult.IsValid == false) {
                throw new ValidationException(validationResult);
            }
            var leaveType = _mapper.Map<LeaveType>(request.CreateLeaveTypeDto);
            var createdLeaveType = await _leaveTypeRepository.Add(leaveType);
            return createdLeaveType.Id;
        }
    }
}
