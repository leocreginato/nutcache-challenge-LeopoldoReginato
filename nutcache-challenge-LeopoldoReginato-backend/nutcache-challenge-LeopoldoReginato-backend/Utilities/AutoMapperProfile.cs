using AutoMapper;
using nutcache_challenge_LeopoldoReginato_backend.DTOs;
using nutcache_challenge_LeopoldoReginato_backend.Models;
using System.Globalization;

namespace nutcache_challenge_LeopoldoReginato_backend.Utilities
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            #region Gender
            CreateMap<Gender, GenderDTO>().ReverseMap();
            #endregion

            #region Team
            CreateMap<Team, TeamDTO>().ReverseMap();
            #endregion

            #region Employee
            CreateMap<Employee, EmployeeDTO>()
                .ForMember(destiny =>
                    destiny.genderName,
                    opt => opt.MapFrom(origin => origin.IdGenderNavigation.Name))
                .ForMember(destiny =>
                    destiny.teamName,
                    opt => opt.MapFrom(origin => origin.IdTeamNavigation.Name))
                .ForMember(destiny =>
                    destiny.BirthDate,
                    opt => opt.MapFrom(origin => origin.BirthDate.ToString("dd/MM/yyyy")))
                .ForMember(destiny =>
                    destiny.StartDate,
                    opt => opt.MapFrom(origin => origin.StartDate.ToString("dd/MM/yyyy"))
                    );

            CreateMap<EmployeeDTO, Employee>()
                .ForMember(destiny =>
                    destiny.IdGenderNavigation,
                    opt => opt.Ignore()
                )
                .ForMember(destiny =>
                    destiny.IdTeamNavigation,
                    opt => opt.Ignore()
                )
                .ForMember(destiny =>
                    destiny.BirthDate,
                    opt => opt.MapFrom(origin => DateTime.ParseExact(origin.BirthDate, "dd/MM/yyyy", CultureInfo.InvariantCulture))
                )
                .ForMember(destiny =>
                    destiny.StartDate,
                    opt => opt.MapFrom(origin => DateTime.ParseExact(origin.StartDate, "dd/MM/yyyy", CultureInfo.InvariantCulture))
                );
            #endregion
        }
    }
}
