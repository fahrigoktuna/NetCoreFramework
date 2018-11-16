using NetCoreFramework.Application.Core.DTO.Student;
using NetCoreFramework.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreFramework.Application.Core.DTO.Profile
{
    public class Map : AutoMapper.Profile
    {

        public Map()
        {
            CreateMap<NetCoreFramework.Domain.Models.Student, StudentDTO>()
                .ForMember(s => s.FullName, dto => dto.MapFrom(x => x.FirstMidName + " " + x.LastName))
                .ForMember(s => s.RegistrationDate, dto => dto.MapFrom(x => x.EnrollmentDate))
                .ForMember(s => s.EnrollmentList, dto => dto.MapFrom(x => x.Enrollments));
        }
    }
}
