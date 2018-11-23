using NetCoreFramework.Application.Core.Students;
using NetCoreFramework.Infrastructure.Data.DBContext;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;
using NetCoreFramework.Infrastructure.Data.DBInitializer;
using NetCoreFramework.Domain.Models;
using NetCoreFramework.Application.Core.DTO.TestPurpose;
using System.Collections.Generic;

namespace NetCoreFramework.Presentation.Console
{
    class Program
    {
        public static IStudentService _studentService { get; set; }
        public static FrameworkContext _context;
        static void Main(string[] args)
        {
            App_Start();
            try
            {
                var studentNew = new Student()
                {
                    FirstMidName = "first",
                    LastName = "lastName",
                    EnrollmentDate = DateTime.Now,
                    Enrollments = new List<Enrollment>() { new Enrollment() { CourseID = 1045 } }
                };

                _studentService.CreateStudent(studentNew);

               var listStudent = _studentService.GetStudentList();

                var listStudentWithEnrollments = _studentService.GetStudentListWithEnrollments();

                //var studentKaan = _studentService.GetStudentById(10);

                // studentKaan.FirstMidName = "KaanNew";

                //var studentKaan = new Student() { ID = -1 };

                //_studentService.UpdateStudent(studentKaan);


                //var studentList = _studentService.GetStudentList();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("EXCEPTION!!! " + ex.Message);
            }
            //DbInitializer.Initialize(context);

            


            System.Console.Read();

        }

        private static void App_Start()
        {
            ProfileRegistration.RegisterMapping();
            _context = new DesignTimeDbContextFactory().CreateDbContext(null);
            //_studentService = new StudentService(_context);
        }
    }
}
