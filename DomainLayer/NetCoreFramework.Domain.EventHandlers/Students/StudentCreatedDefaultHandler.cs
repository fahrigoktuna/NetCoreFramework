using NetCoreFramework.Domain.EventHandlers.Interface;
using NetCoreFramework.Domain.Events.Students;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreFramework.Domain.EventHandlers.Students
{
    public class StudentCreatedDefaultHandler : IDomainHandler<StudentCreated>
    {
        public void Handle(StudentCreated @event)
        {
            Console.WriteLine("Student default created {0} - {1}", @event._student.ID, @event._student.FirstMidName+ " " + @event._student.LastName);
        }
    }
}
