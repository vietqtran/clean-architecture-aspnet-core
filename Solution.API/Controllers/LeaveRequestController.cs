using MediatR;
using Microsoft.AspNetCore.Mvc;
using Solution.Application.DTOs.LeaveRequest;
using Solution.Application.Features.LeaveRequests.Requests.Commands;
using Solution.Application.Features.LeaveRequests.Requests.Queries;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Solution.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveRequestController : ControllerBase
    {
        public readonly IMediator _mediator;

        public LeaveRequestController (IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<LeaveRequestDto>>> Get ( )
        {
            var leaveRequests = await _mediator.Send(new GetLeaveRequestListRequest());
            return Ok(leaveRequests);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveRequestDto>> Get (int id)
        {
            var leaveRequest = await _mediator.Send(new GetLeaveRequestDetailRequest { Id = id });
            return Ok(leaveRequest);
        }

        [HttpPost]
        public async Task<ActionResult> Post ([FromBody] CreateLeaveRequestDto createLeaveRequestDto)
        {
            await _mediator.Send(new CreateLeaveRequestCommand { CreateLeaveRequestDto = createLeaveRequestDto });
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put (int id, [FromBody] string value)
        {
            await _mediator.Send(new UpdateLeaveRequestCommand { Id = id });
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete (int id)
        {
            await _mediator.Send(new DeleteLeaveRequestCommand { Id = id });
            return NoContent();
        }
    }
}
