using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseArchitecture.Domain.Meta
{
    public static class Router
    {
        //public const string Domain = "https://localhost:5001";
        public const string Root = "/api/";
        public static class StudentRouting
        {
            public const string GetAll = Root + "GetStudents";
            public const string GetById = Root + "GetStudentById/{id}";
        }
    }
}
