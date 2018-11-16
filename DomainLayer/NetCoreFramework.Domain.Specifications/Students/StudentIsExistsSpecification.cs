using NetCoreFramework.Domain.Models;
using NetCoreFramework.Domain.Specifications.Interface;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace NetCoreFramework.Domain.Specifications.Students
{
    public class StudentIsExistsSpecification : ISpecification<Student>
    {
        private int _studentId;
        
        public StudentIsExistsSpecification(int id)
        {
            _studentId = id;
        }
        public Expression<Func<Student, bool>> SpecExpression
        {
            get { return c => c.ID == _studentId; }
        }
    }
}
