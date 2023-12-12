using Abp.Domain.Uow;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Solution.Application.DTOs.LeaveType;
using Solution.Application.Features.LeaveTypes.Requests.Queries;
using Solution.Application.Features.LeaveTypes.Requests.Commands;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Solution.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveTypesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveTypesController (IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<LeaveTypeDto>>> Get ( )
        {
            var leaveTypes = await _mediator.Send(new GetLeaveTypeListRequest());
            return Ok(leaveTypes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveTypeDto>> Get (int id)
        {
            var leaveType = await _mediator.Send(new GetLeaveTypeDetailRequest { Id = id });
            return Ok(leaveType);
        }

        [HttpPost]
        public async Task<ActionResult> Post ([FromBody] CreateLeaveTypeDto createLeaveTypeDto)
        {
            await _mediator.Send(new CreateLeaveTypeCommand { CreateLeaveTypeDto = createLeaveTypeDto });
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put ([FromBody] LeaveTypeDto leaveTypeDto)
        {
            await _mediator.Send(new UpdateLeaveTypeCommand { LeaveTypeDto = leaveTypeDto });
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete (int id)
        {
            await _mediator.Send(new DeleteLeaveTypeCommand { Id = id });
            return NoContent();
        }
    }
}
