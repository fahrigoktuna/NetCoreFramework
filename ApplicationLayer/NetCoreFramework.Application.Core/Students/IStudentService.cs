using NetCoreFramework.Application.Core.DTO.Student;
using NetCoreFramework.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreFramework.Application.Core.Students
{
    public interface IStudentService
    {

        List<StudentDTO> GetStudentList();

        List<StudentDTO> GetStudentListWithEnrollments();

        Student GetStudentById(int id);

        void CreateStudent(Student s);

        void UpdateStudent(Student s);
    }
}
