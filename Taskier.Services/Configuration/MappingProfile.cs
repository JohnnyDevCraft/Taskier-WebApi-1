using System;
using AutoMapper;
using Taskier.Domain.ServiceModel;
using Taskier.Domain.ViewModel.Request.TaskController;
using Taskier.Domain.ViewModel.Response;

namespace Taskier.Services.Configuration
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateTaskRequest, TaskSm>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => 0))
                .ForMember(dest => dest.AssignedTo, opt => opt.MapFrom(src => src.AssignedTo))
                .ForMember(dest => dest.Completed, opt => opt.MapFrom(src => false))
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Subject, opt => opt.MapFrom(src => src.Subject))
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<TaskSm, TaskierTask>();
        }
    }
}
