using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using SignalR.Models;
using System.Web.Http.OData;
using SignalR.Hubs;

namespace SignalR.Controllers
{
    public class EmployeesController : EntitySetControllerWithHub<EmployeeHub> 
    {
        private SignalRContext db = new SignalRContext();

        // GET: api/Employees


            public override IQueryable<Employee> Get()
        {

            return db.Employees;
        }

        protected override Employee GetEntityByKey(int key)
        {
            return db.Employees.Find(key);
        }

        protected override Employee PatchEntity(int key, Delta<Employee> patch) {

            var employeeToPatch = GetEntityByKey(key);
            patch.Patch(employeeToPatch);
            db.Entry(employeeToPatch).State = EntityState.Modified;
            db.SaveChanges();
            var changedProperty = patch.GetChangedPropertyNames().ToList()[0];
            object changedPropertyValue;
            patch.TryGetPropertyValue(changedProperty, out changedPropertyValue);
            Hub.Clients.All.updateEmployee(employeeToPatch.Id,changedProperty, changedPropertyValue);
            return employeeToPatch;
        }

        public override void Delete(int key)
        {
            var employeeToDelete = db.Employees.Find(key);
            db.Employees.Remove(employeeToDelete);
            db.SaveChanges();

            Hub.Clients.All.removeEmployee(key);
        }


        protected override Employee CreateEntity(Employee entity)
        {
            var newEmployee = db.Employees.Add(entity);
            db.SaveChanges();

            Hub.Clients.All.addEmployee(newEmployee);
            return newEmployee;
        }
        //public IEnumerable<Employee> GetEmployees()
        //{
        //    return db.Employees.AsEnumerable();
        //}


        //// GET: api/Employees/5
        //[ResponseType(typeof(Employee))]
        //public IHttpActionResult GetEmployee(int id)
        //{
        //    Employee employee = db.Employees.Find(id);
        //    if (employee == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(employee);
        //}

        // PUT: api/Employees/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmployee(int id, Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employee.Id)
            {
                return BadRequest();
            }

            db.Entry(employee).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Employees
        [ResponseType(typeof(Employee))]
        public IHttpActionResult PostEmployee(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Employees.Add(employee);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = employee.Id }, employee);
        }

        //// DELETE: api/Employees/5
        //[ResponseType(typeof(Employee))]
        //public IHttpActionResult DeleteEmployee(int id)
        //{
        //    Employee employee = db.Employees.Find(id);
        //    if (employee == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Employees.Remove(employee);
        //    db.SaveChanges();

        //    return Ok(employee);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmployeeExists(int id)
        {
            return db.Employees.Count(e => e.Id == id) > 0;
        }
    }
}