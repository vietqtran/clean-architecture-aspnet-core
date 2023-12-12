using MediatR;
using Microsoft.AspNetCore.Mvc;
using Solution.Application.DTOs.LeaveAllocation;
using Solution.Application.Features.LeaveAllocations.Requests.Commands;
using Solution.Application.Features.LeaveAllocations.Requests.Queries;
using Solution.Domain;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Solution.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveAllocationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveAllocationController (IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<LeaveAllocationDto>>> Get ( )
        {
            var leaveAllocations = await _mediator.Send(new GetLeaveAllocationListRequest());
            return Ok(leaveAllocations);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveAllocation>> Get (int id)
        {
            var leaveAllocation = await _mediator.Send(new GetLeaveAllocationDetailRequest { Id = id });
            return Ok(leaveAllocation);
        }

        [HttpPost]
        public async Task<ActionResult> Post ([FromBody] CreateLeaveAllocationDto createLeaveAllocationDto)
        {
            await _mediator.Send(new CreateLeaveAllocationCommand { CreateLeaveAllocationDto = createLeaveAllocationDto });
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put ([FromBody] UpdateLeaveAllocationDto updateLeaveAllocationDto)
        {
            await _mediator.Send(new UpdateLeaveAllocationCommand { UpdateLeaveAllocationDto = updateLeaveAllocationDto });
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete (int id)
        {
            await _mediator.Send(new DeleteLeaveAllocationCommand { Id = id });
            return NoContent();
        }
    }
}
