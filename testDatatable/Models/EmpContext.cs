using System.Data.Entity;

namespace testDatatable.Models
{
    public class EmpContext : DbContext
    {
        public EmpContext() : base("SqlDbConnection")
        {
            
        }
        public DbSet<Employee> Employees { get; set; }
    }
}