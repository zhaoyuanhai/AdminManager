using AdminTemplate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdminTemplate;

namespace AdminTemplate.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index(Student student)
        {
            var dd = ModelMetadataProviders.Current.GetMetadataForType(new Func<object>(() =>
              {
                  return null;
              }), typeof(Student));

            var models = new List<Student>()
            {
                new Student("王五",17,false,"www.person.com"),
                new Student("李四",43,false,"www.person.com"),
                new Student("张三",32,false,"www.person.com")
            };
            return View(models);
        }

        public ActionResult Point()
        {
            return View(new Triangle()
            {
                A = new Point() { X = 1, Y = 4 },
                B = new Point() { X = 3, Y = 2 },
                C = new Point() { X = 4, Y = 4 },
            });
        }

        public ActionResult Employee()
        {
            this.User.CurrentUser();
            return View(new Employee
            {
                Name = "张三",
                Gender = "M",
                Education = "M",
                Departments = new string[] { "DEV01", "DEV02" },
                Skills = new string[] { "CSharp", "AdoNet" }
            });
        }
    }
}