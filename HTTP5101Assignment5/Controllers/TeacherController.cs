﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HTTP5101Assignment5.Models;

namespace HTTP5101Assignment5.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        public ActionResult Index()
        {
            return View();
        }

        // GET : /Teacher/List
        public ActionResult List()
        {
            TeacherDataController controller = new TeacherDataController();
            IEnumerable<Teacher> Teachers = controller.ListTeachers();
            return View(Teachers);
        }
        // GET : /Teacher/Show
        public ActionResult Show(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            ViewBag.Teacher = controller.FindTeacher(id);
            ClassDataController ClassController = new ClassDataController();
            ViewBag.Class = ClassController.FindTeacherClass(id);
            return View();
        }
        // POST : /Teacher/Delete/{id}
        public ActionResult Delete(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            controller.DeleteTeacher(id);
            return RedirectToAction("List");
        }

        public ActionResult Add()
        {
            return View();
        }
        // POST : /Teacher/Create
        public ActionResult Create(String TeacherFname, String TeacherLname, String EmployeeNumber, decimal Salary)
        {
            Teacher NewTeacher = new Teacher();
            NewTeacher.TeacherFname = TeacherFname;
            NewTeacher.TeacherLname = TeacherLname;
            NewTeacher.EmployeeNumber = EmployeeNumber;
            NewTeacher.Salary = Salary;

            TeacherDataController controller = new TeacherDataController();
            controller.AddTeacher(NewTeacher);

            return RedirectToAction("List");
        }
        // GET : /Teacher/Update/{id}
        public ActionResult Update(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            ViewBag.Teacher = controller.FindTeacher(id);
            //Might be used in the future to allow for editing classes associated with teachers
            //ClassDataController ClassController = new ClassDataController(); 
            //ViewBag.Class = ClassController.FindTeacherClass(id);
            return View();
        }
        // POST : /Teacher/Edit
        public ActionResult Edit(int id, String TeacherFname, String TeacherLname, String EmployeeNumber, decimal Salary)
        {
            Teacher EditTeacher = new Teacher();
            EditTeacher.Teacherid = id;
            EditTeacher.TeacherFname = TeacherFname;
            EditTeacher.TeacherLname = TeacherLname;
            EditTeacher.EmployeeNumber = EmployeeNumber;
            EditTeacher.Salary = Salary;

            TeacherDataController controller = new TeacherDataController();
            controller.EditTeacher(EditTeacher);

            return RedirectToAction("Show/"+id);
        }
    }
}