using System;
using System.Data.Entity;
using System.Globalization;

namespace testDatatable.Models
{
    public class EmpDBInitializer : DropCreateDatabaseAlways<EmpContext>
    {
        protected override void Seed(EmpContext db)
        {
            for (int i = 0; i < 100; i++)
            {
                db.Employees.Add(new Employee { Name = "Airi Satou", Age = 32, Position = "Accountant", StartDate = Convert.ToDateTime("2008/11/28", new CultureInfo("en-US")) });
                db.Employees.Add(new Employee { Name = "Angelica Ramos", Age = 47, Position = "Chief Executive Officer (CEO)", StartDate = Convert.ToDateTime("2009/10/09", new CultureInfo("en-US")) });
                db.Employees.Add(new Employee { Name = "Bradley Greer", Age = 41, Position = "Software Engineer", StartDate = Convert.ToDateTime("2012/10/13", new CultureInfo("en-US")) });
                db.Employees.Add(new Employee { Name = "Brenden Wagner", Age = 28, Position = "Software Engineer", StartDate = Convert.ToDateTime("2011/06/07", new CultureInfo("en-US")) });
                db.Employees.Add(new Employee { Name = "Brielle Williamson", Age = 61, Position = "Integration Specialist", StartDate = Convert.ToDateTime("2012/12/02", new CultureInfo("en-US")) });
                db.Employees.Add(new Employee { Name = "Bruno Nash", Age = 38, Position = "Software Engineer", StartDate = Convert.ToDateTime("2011/05/03", new CultureInfo("en-US")) });
                db.Employees.Add(new Employee { Name = "Caesar Vance", Age = 21, Position = "Pre-Sales Support", StartDate = Convert.ToDateTime("2011/12/12", new CultureInfo("en-US")) });
                db.Employees.Add(new Employee { Name = "Cara Stevens", Age = 46, Position = "Sales Assistant", StartDate = Convert.ToDateTime("2011/12/06", new CultureInfo("en-US")) });
                db.Employees.Add(new Employee { Name = "Cedric Kelly", Age = 22, Position = "Senior Javascript Developer", StartDate = Convert.ToDateTime("2012/03/29", new CultureInfo("en-US")) });
                db.Employees.Add(new Employee { Name = "Charde Marshall", Age = 36, Position = "Regional Director", StartDate = Convert.ToDateTime("2008/10/16", new CultureInfo("en-US")) });
            }
            base.Seed(db);
        }
    }
}