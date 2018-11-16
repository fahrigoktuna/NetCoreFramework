using NetCoreFramework.Domain.Models;
using NetCoreFramework.Domain.Specifications.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;

namespace NetCoreFramework.Domain.Specifications.Students
{
    public class StudentNameAlreadyExists : ISpecification<Student>
    {
        private string _midFirstName;
            private string _lastName;
        public StudentNameAlreadyExists(string fName, string lName)
        {
            _midFirstName = fName;
            _lastName = lName;
        }
        public Expression<Func<Student, bool>> SpecExpression
        {
            get { return c => c.FirstMidName == _midFirstName && c.LastName == _lastName; }
        }
    }
}
