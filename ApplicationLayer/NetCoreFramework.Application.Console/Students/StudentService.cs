using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using NetCoreFramework.Domain.Models;
using NetCoreFramework.Infrastructure.Data.UnitOfWork;
using NetCoreFramework.Infrastructure.Data.DBContext;
using NetCoreFramework.Infrastructure.Helpers.Events;
using NetCoreFramework.Domain.Events.Students;
using NetCoreFramework.Domain.Specifications.Students;
using NetCoreFramework.Application.Core.DTO.Student;
using Microsoft.EntityFrameworkCore;

namespace NetCoreFramework.Application.Core.Students
{
    public class StudentService : IStudentService
    {
        private FrameworkContext _context;
        private EFUnitOfWork _uow;
        public StudentService(FrameworkContext context)
        {
            _context = context;
            _uow = new EFUnitOfWork(context);
        }
        public Student GetStudentById(int id)
        {
            return _uow.GetRepository<Student>().Get(e => e.ID == id);
        }

        public List<StudentDTO> GetStudentList()
        {
            return AutoMapper.Mapper.Map<List<Student>,List<StudentDTO>>(_uow.GetRepository<Student>().GetFullList().ToList());
        }
        public List<StudentDTO> GetStudentListWithEnrollments()
        {
            return AutoMapper.Mapper.Map<List<Student>, List<StudentDTO>>(_uow.GetRepository<Student>().GetFullList().Include("Enrollments").ToList());
        }

        public void CreateStudent(Student s)
        {
            if (_uow.GetRepository<Student>().Get(new StudentNameAlreadyExists(s.FirstMidName, s.LastName).SpecExpression) == null)
            {
                _uow.GetRepository<Student>().Add(s);
                _uow.Commit();
                DomainEvents.Raise<StudentCreated>(new StudentCreated(s));
            }
            else
                throw new Exception(string.Format("Studen FName: {0} - LName: {1} already exists in database", s.FirstMidName, s.LastName));
        }

        public void UpdateStudent(Student s)
        {
            if (_uow.GetRepository<Student>().Get(new StudentIsExistsSpecification(s.ID).SpecExpression) != null)
            {
                _uow.GetRepository<Student>().Update(s);
                _uow.Commit();
            }
            else
                throw new Exception(string.Format("Studen ID: {0} - doest not exists in database", s.ID));
         

        }

    }
}
