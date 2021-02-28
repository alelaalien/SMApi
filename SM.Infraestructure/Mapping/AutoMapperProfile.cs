using AutoMapper;
using SM.Core.DTOs;
using SM.Core.Entities;

namespace SM.Infraestructure.Mapping
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<EventDto, Event>();
            CreateMap<Event, EventDto>();

            CreateMap<UserDto, User>();
            CreateMap<User, UserDto>();

            CreateMap<TeacherDto, Teacher>();
            CreateMap<Teacher, TeacherDto>();

            CreateMap<SubjetDto, Subjet>();
            CreateMap<Subjet, SubjetDto>();

            CreateMap<TypeOfDto, TypeOf>();
            CreateMap<TypeOf, TypeOfDto>();

            CreateMap<SecurityDto, Security>();
            CreateMap<Security, SecurityDto>();//reversemap
        }
    }
}
