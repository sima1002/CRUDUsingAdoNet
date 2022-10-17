using CRUDUsingAdoNet.DAL;
using CRUDUsingAdoNet.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDUsingAdoNet.Controllers
{
    public class EmployeController : Controller
    {

        private readonly IConfiguration configuration;
        EmployeDAL employedal;

        public EmployeController(IConfiguration configuration)
        {
            this.configuration = configuration;
            employedal = new EmployeDAL(configuration);
        }
        public ActionResult List()
        {
            var model = employedal.GetAllEmploye();
            return View(model);
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int id)
        {
            var employe = employedal.GetEmployeById(id);
            return View(employe);
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Models.Employe emp)
        {
            try
            {
                int res = employedal.AddEmploye(emp);
                if (res == 1)
                    return RedirectToAction(nameof(List));
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            var employee = employedal.GetEmployeById(id);
            return View(employee);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Models.Employe emp)
        {
            try
            {
                int res = employedal.UpdateEmploye(emp);
                if (res == 1)
                    return RedirectToAction(nameof(List));
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            var employee = employedal.GetEmployeById(id);
            return View(employee);
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                int res = employedal.DeleteEmploye(id);
                if (res == 1)
                    return RedirectToAction(nameof(List));
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }
    }
}