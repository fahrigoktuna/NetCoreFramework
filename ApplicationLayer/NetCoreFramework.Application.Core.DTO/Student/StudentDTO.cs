using NetCoreFramework.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreFramework.Application.Core.DTO.Student
{
    public class StudentDTO
    {
        public int ID { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string FullName { get; set; }

        public List<Enrollment> EnrollmentList { get; set; }
    }
}
