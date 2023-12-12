using AutoMapper;
using MediatR;
using Solution.Application.DTOs.LeaveRequest.Validators;
using Solution.Application.Exceptions;
using Solution.Application.Features.LeaveRequests.Requests.Commands;
using Solution.Application.Contracts.Persistence;
using Solution.Application.Responses;
using Solution.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solution.Application.Contracts.Infrastructure;
using Solution.Application.Models;
using System.Threading;
using Solution.Application.Contracts.Pesistence;

namespace Solution.Application.Features.LeaveRequests.Handlers.Commands
{
    public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;
        private readonly IUnitOfWork _unitOfWork;

        public CreateLeaveRequestCommandHandler (IMapper mapper, IEmailSender emailSender, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _emailSender = emailSender;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseCommandResponse> Handle (CreateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var validator = new CreateLeaveRequestDtoValidator(_unitOfWork.LeaveRequestRepository);
            var validationResult = await validator.ValidateAsync(request.CreateLeaveRequestDto);
            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Leave Request Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }

            var leaveRequest = _mapper.Map<LeaveRequest>(request.CreateLeaveRequestDto);
            var createdLeaveRequest = await _unitOfWork.LeaveRequestRepository.Add(leaveRequest);

            response.Success = true;
            response.Message = "Leave Request Created Successfully";
            response.Id = createdLeaveRequest.Id;

            var email = new Email()
            {
                To = "tranquocviet1303@gmail.com",
                Subject = "Leave Request Application",
                Body = $"Your leave request for {createdLeaveRequest.StartDate:D} to {createdLeaveRequest.EndDate:D} has been submitted successfully."
            };

            try
            {
                await _emailSender.SendEmail(email);
            }
            catch (Exception ex)
            {
                response.Success = false;
            }

            return response;
        }
    }
}
