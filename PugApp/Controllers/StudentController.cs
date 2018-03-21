using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PugApp.DAL;
using PugApp.Models;

namespace PugApp.Controllers
{
    public class StudentController : Controller
    {
		private SchoolContext db = new SchoolContext();
		public ActionResult Index()
        {
            return View(db.Students.ToList());
		
		}

		public ActionResult Edit(int? id)
		{
			return View("");
		}

		[HttpPost]
		public ActionResult Edit(Student student)
		{
			return RedirectToAction("Index");
		}


		public ActionResult Delete(int? id)
		{
			return View();
		}


		[HttpPost]
		[ActionName("Delete")]
		public ActionResult DeletePost(int? id)
		{
			return RedirectToAction("Index");

		}

	}
}

