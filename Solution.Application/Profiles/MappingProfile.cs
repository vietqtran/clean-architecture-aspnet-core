using AutoMapper;
using Solution.Domain;
using Solution.Application.DTOs;
using Solution.Application.DTOs.LeaveAllocation;
using Solution.Application.DTOs.LeaveRequest;
using Solution.Application.DTOs.LeaveType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile ( )
        {
            CreateMap<LeaveRequest, LeaveRequestDto>().ReverseMap();
            CreateMap<LeaveRequest, LeaveRequestListDto>().ReverseMap();
            CreateMap<LeaveType, LeaveTypeDto>().ReverseMap();
            CreateMap<LeaveAllocation, LeaveAllocationDto>().ReverseMap();
        }
    }
}
