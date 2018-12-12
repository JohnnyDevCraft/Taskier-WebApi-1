using System;
using AutoMapper;
using Taskier.Data.Entities;
using Taskier.Domain.ServiceModel;

namespace Taskier.Data.Configure
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<TaskSm, TaskItem>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom((src) => src.Id))
                .ForMember(dest => dest.AssignedTo, opt => opt.MapFrom((src) => src.AssignedTo))
                .ForMember(dest => dest.Description, opt => opt.MapFrom((src) => src.Description))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom((src) => src.EndDate))
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom((src) => src.StartDate))
                .ForMember(dest => dest.Subject, opt => opt.MapFrom((src) => src.Subject))
                .ForMember(dest => dest.Completed, opt => opt.MapFrom((src)=> src.Completed))
                .ForAllOtherMembers((obj) => obj.Ignore());

            CreateMap<TaskItem, TaskSm>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom((src) => src.Id))
                .ForMember(dest => dest.AssignedTo, opt => opt.MapFrom((src) => src.AssignedTo))
                .ForMember(dest => dest.Description, opt => opt.MapFrom((src) => src.Description))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom((src) => src.EndDate))
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom((src) => src.StartDate))
                .ForMember(dest => dest.Subject, opt => opt.MapFrom((src) => src.Subject))
                .ForMember(dest => dest.Completed, opt => opt.MapFrom((src) => src.Completed))
                .ForAllOtherMembers((obj) => obj.Ignore());

            CreateMap<SubTaskSm, SubTaskItem>()
                .ForMember(dest => dest.TaskItem, opt => opt.Ignore())
                .ForMember(dest => dest.TaskItemId, opt => opt.Ignore());

            CreateMap<SubTaskItem, SubTaskSm>();
        }
    }
}
