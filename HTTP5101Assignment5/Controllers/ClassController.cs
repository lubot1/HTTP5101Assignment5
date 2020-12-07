﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HTTP5101Assignment5.Models;

namespace HTTP5101Assignment5.Controllers
{
    public class ClassController : Controller
    {
        // GET: Class
        public ActionResult Index()
        {
            return View();
        }
        
        // GET: Class/List
        public ActionResult List()
        {
            ClassDataController controller = new ClassDataController();
            IEnumerable<Class> Classes = controller.ListClasses();
            return View(Classes);
        }

        // GET: Class/Show/{int id}
        public ActionResult Show(int id)
        {
            ClassDataController controller = new ClassDataController();
            Class NewClass = controller.FindClass(id);
            ViewBag.Class = NewClass;
            TeacherDataController teachercontroller = new TeacherDataController();
            ViewBag.Teacher = teachercontroller.FindTeacher((int)NewClass.TeacherId);
            return View();
        }
    }
}