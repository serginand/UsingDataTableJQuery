using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using testDatatable.Models;
using System.Globalization;
using testDatatable.Models.DataTables;

namespace testDatatable.API
{
    public class EmployeesController : ApiController
    {
        WorkUnit wu = new WorkUnit();

        [HttpGet]
        public DataTableResponse GetEmployees(DataTableRequest request)
        {
            var employees = wu.Employees.GetAll();

            // Searching
            IEnumerable<Employee> filteredEmps;
            if (request.Search.Value != "")
            {
                var searchText = request.Search.Value.Trim().ToLower();

                filteredEmps = employees.Where(emp =>
                        emp.Name.ToLower().Contains(searchText) ||
                        emp.Position.ToLower().Contains(searchText) ||
                        emp.Age.ToString().Contains(searchText) ||
                        emp.StartDate.ToShortDateString().Contains(searchText));
            }
            else
            {
                filteredEmps = employees;
            }
            //Sorting
            if (request.Order.Any())
            {
                int sortColumnIndex = request.Order[0].Column;
                string sortDirection = request.Order[0].Dir;

                Func<Employee, string> orderingFunctionString = null; 
                Func<Employee, int> orderingFunctionInt = null;
                Func<Employee, DateTime> orderingFunctionDate = null;

                switch (sortColumnIndex)
                {
                    case 0:     // ID
                        {
                            orderingFunctionInt = (c => c.Id);
                            filteredEmps =
                                sortDirection == "asc"
                                    ? filteredEmps.OrderBy(orderingFunctionInt)
                                    : filteredEmps.OrderByDescending(orderingFunctionInt);
                            break;
                        }
                    case 1:     // Name
                        {
                            orderingFunctionString = (c => c.Name);
                            filteredEmps =
                                sortDirection == "asc"
                                    ? filteredEmps.OrderBy(orderingFunctionString)
                                    : filteredEmps.OrderByDescending(orderingFunctionString);
                            break;
                        }
                    case 2:     // Position
                        {
                            orderingFunctionString = (c => c.Position);
                            filteredEmps =
                                sortDirection == "asc"
                                    ? filteredEmps.OrderBy(orderingFunctionString)
                                    : filteredEmps.OrderByDescending(orderingFunctionString);
                            break;
                        }
                    case 3:     // Age
                        {
                            orderingFunctionInt = (c => c.Age);
                            filteredEmps =
                                sortDirection == "asc"
                                    ? filteredEmps.OrderBy(orderingFunctionInt)
                                    : filteredEmps.OrderByDescending(orderingFunctionInt);
                            break;
                        }
                    case 4:     // StartDate
                        {
                            orderingFunctionDate = (c => c.StartDate);
                            filteredEmps =
                                sortDirection == "asc"
                                    ? filteredEmps.OrderBy(orderingFunctionDate)
                                    : filteredEmps.OrderByDescending(orderingFunctionDate);
                            break;
                        }
                }
            }
            
            var femps = filteredEmps.Select(e=> new {
                e.Id,
                e.Name,
                e.Age,
                e.Position,
                StartDate = e.StartDate.ToShortDateString() 
            });
            // Paging Data
            var pagedEmps = femps.Skip(request.Start).Take(request.Length);
            return new DataTableResponse
            {
                draw = request.Draw,
                recordsTotal = employees.Count(),
                recordsFiltered = filteredEmps.Count(),
                data = pagedEmps.ToArray(),
                error = ""
            };
        }

        // POST: api/Default
        public HttpResponseMessage Post([FromBody]Employee emp)
        {
            HttpResponseMessage result;
            try
            {
                using (wu.Employees)
                {
                    wu.Employees.Add(emp);
                    wu.Employees.Save();
                }
                result = Request.CreateResponse(HttpStatusCode.Created, emp);
            }
            catch (Exception)
            {
                result = Request.CreateResponse(HttpStatusCode.BadRequest, "Server failed to save data");
            }

            return result;
        }

        // PUT: api/Default/5
        public HttpResponseMessage Put([FromBody]Employee emp)
        {
            HttpResponseMessage result;
            try
            {
                using (wu.Employees)
                {
                    wu.Employees.Update(emp);
                    wu.Employees.Save();
                }
                result = Request.CreateResponse(HttpStatusCode.OK, emp);
            }
            catch (Exception)
            {
                result = Request.CreateResponse(HttpStatusCode.BadRequest, "Server failed to save data");
            }
            return result;
        }

        // DELETE: api/Default/5
        public HttpResponseMessage Delete(int id)
        {
            HttpResponseMessage result;
            try
            {
                using (wu.Employees)
                {
                    wu.Employees.Remove(id);
                    wu.Employees.Save();
                }
                result = Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception)
            {
                result = Request.CreateResponse(HttpStatusCode.BadRequest, "Server failed to save data");
            }
            return result;
           
        }
        protected override void Dispose(bool disposing)
        {
            wu.Employees.Dispose();
            base.Dispose(disposing);
        }
    }
}
