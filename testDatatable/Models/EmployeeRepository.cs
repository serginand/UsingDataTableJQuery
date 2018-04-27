using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace testDatatable.Models
{
    public class EmployeeRepository : IEmployeeRepository<Employee>, IDisposable
    {
        private EmpContext _db;

        public EmployeeRepository(EmpContext context)
        {
            _db = context;
        }

        public IEnumerable<Employee> GetAll()
        {
            return _db.Employees;
        }

        public Employee Get(int id)
        {
            return _db.Employees.Find(id);
        }

        public void Add(Employee emp)
        {
            _db.Employees.Add(emp);
        }

        public void Update(Employee emp)
        {
            _db.Entry(emp).State = EntityState.Modified;
        }

        public void Remove(int id)
        {
            Employee emp = _db.Employees.Find(id);
            if (emp != null)
                _db.Employees.Remove(emp);
        }
        public void Save()
        {
            _db.SaveChanges();
        }
        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
                disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}