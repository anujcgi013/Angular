using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmployeeWebApiService.Controllers
{
    public class EmployeeController : ApiController
    {
        public IEnumerable<Employee> Get()
        {
            using (var employeeEntity = new EmployeeDBEntities())
            {
                return employeeEntity.Employees.ToList();
            }
        }

        public Employee Get(string code)
        {
            using (var employeeEntity = new EmployeeDBEntities())
            {
                return employeeEntity.Employees.FirstOrDefault(x => x.code == code);
            }
        }
    }
}
