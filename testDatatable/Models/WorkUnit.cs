using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace testDatatable.Models
{
    public class WorkUnit
    {
        private EmpContext _ctx = new EmpContext();
        private EmployeeRepository _empRep;
        public EmployeeRepository Employees
        {
            get
            {
                if (_empRep == null)
                    _empRep = new EmployeeRepository(_ctx);
                return _empRep;
            }
        }
    }
}