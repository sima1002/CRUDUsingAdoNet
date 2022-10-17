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
    public class DepartmentController : Controller
    {
        private readonly IConfiguration configuration;
        DepartmentDAL departmentdal;

        public DepartmentController(IConfiguration configuration)
        {
            this.configuration = configuration;
            departmentdal = new DepartmentDAL(configuration);
        }
        // GET:DepartmentController

        // GET: DepartmentController/Details/5
        public ActionResult List()
        {
            var model = departmentdal.GetAllDepartment();
            return View(model);
        }
        public ActionResult Details(int id)
        {
            var department = departmentdal.GetDepartmentById(id);
            return View(department);
        }



        // GET:DepartmentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Department dept)
        {
            try
            {
                int res = departmentdal.AddDepartment(dept);
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

        // GET: DepartmentController/Edit/5
        public ActionResult Edit(int id)
        {
            var department = departmentdal.GetDepartmentById(id);
            return View(department);
        }

        // POST: DepartmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Department dept)
        {
            try
            {
                int res = departmentdal.UpdateDepartment(dept);
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

        // GET: DepartmentController/Delete/5
        public ActionResult Delete(int id)
        {
            var department = departmentdal.GetDepartmentById(id);
            return View(department);
           
        }

        // POST:DepartmentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
       [ ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            try
            {
                int res = departmentdal.DeleteDepartment(id);
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
