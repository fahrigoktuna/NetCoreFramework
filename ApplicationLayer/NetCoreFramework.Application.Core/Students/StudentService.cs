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
using RabbitMQ.Client;
using Newtonsoft.Json;
using NetCoreFramework.Infrastructure.Helpers.RabbitMQ;

namespace NetCoreFramework.Application.Core.Students
{
    public class StudentService : IStudentService
    {
        private EFUnitOfWork _uow;
        IConnection _busClient;
        public StudentService(FrameworkContext context,IConnection busClient)
        {
            _uow = new EFUnitOfWork(context);
            _busClient = busClient;
        }
        public Student GetStudentById(int id)
        {
            return _uow.GetRepository<Student>().Get(e => e.ID == id);
        }

        public List<StudentDTO> GetStudentList()
        {
            return AutoMapper.Mapper.Map<List<Student>, List<StudentDTO>>(_uow.GetRepository<Student>().GetFullList().ToList());
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

                _busClient.PublishEvent<StudentCreated>(new StudentCreated(s), $"{ typeof(StudentCreated).Assembly.GetName().Name}/{nameof(StudentCreated)}");

                //DomainEvents.Raise<StudentCreated>(new StudentCreated(s)); REPLACED BY RABBIT MQ BUS
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
