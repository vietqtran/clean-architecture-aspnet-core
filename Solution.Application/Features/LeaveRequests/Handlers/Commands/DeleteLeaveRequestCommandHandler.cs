using AutoMapper;
using MediatR;
using Solution.Application.Exceptions;
using Solution.Application.Features.LeaveRequests.Requests.Commands;
using Solution.Application.Persistence.Contracts;
using Solution.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Application.Features.LeaveRequests.Handlers.Commands
{
    public class DeleteLeaveRequestCommandHandler : IRequestHandler<DeleteLeaveRequestCommand>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;

        public DeleteLeaveRequestCommandHandler (ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }


        public async Task<Unit> Handle (DeleteLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var leaveRequest = await _leaveRequestRepository.GetAsync(request.Id);
            if (leaveRequest == null) {
                throw new NotFoundException(nameof(LeaveRequest), request.Id);
            }
            await _leaveRequestRepository.Delete(leaveRequest);
            return Unit.Value;
        }
    }
}
