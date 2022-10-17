using CRUDUsingAdoNet.DAL;
using CRUDUsingAdoNet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDUsingAdoNet.Controllers
{
    public class Student1Controller : Controller
    {
        private readonly IConfiguration configuration;
        Student1DAL studentdal;

        public Student1Controller(IConfiguration configuration)
        {
            this.configuration = configuration;
            studentdal = new Student1DAL(configuration);
        }
        // GET: StudenController

        // GET:StudenController/Details/5
        public ActionResult List()
        {
            var model = studentdal.GetAllStudent1();
            return View(model);
        }
        public ActionResult Details(int id)
        {
            var product = studentdal.GetStudent1ById(id);
            return View(product);
        }



        // GET: StudenController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudenController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student1 stud)
        {
            try
            {
                int res = studentdal.AddStudent1(stud);
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

        // GET: StudenController/Edit/5
        public ActionResult Edit(int id)
        {
            var product = studentdal.GetStudent1ById(id);
            return View(product);
        }

        // POST:StudenController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student1 stud)
        {
            try
            {
                int res = studentdal.UpdateStudent1(stud);
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

        // GET: StudenController/Delete/5
        public ActionResult Delete(int id)
        {
            var product = studentdal.GetStudent1ById(id);
            return View(product);

        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            try
            {
                int res = studentdal.DeleteStudent1(id);
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

