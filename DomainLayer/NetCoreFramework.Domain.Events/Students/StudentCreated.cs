using NetCoreFramework.Domain.Events.Interface;
using NetCoreFramework.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreFramework.Domain.Events.Students
{
    public class StudentCreated : IDomainEvent
    {
        
        public StudentCreated(Student student)
        {
           _student = student;
        }
        public readonly Student _student;
    }
}
