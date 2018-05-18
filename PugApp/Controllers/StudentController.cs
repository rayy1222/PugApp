using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

		public ActionResult Details(int? ID)
		{
			var studentDetail = db.Students.SingleOrDefault(r => r.ID == ID);

			return View(studentDetail);
		}

		public ActionResult Add()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Add(Student student)
		{
			Student dbstudent = new Student();
			dbstudent.FirstMidName = student.FirstMidName;
			dbstudent.LastName = student.LastName;

			dbstudent.EnrollmentDate = DateTime.Now;
			dbstudent.Enrollments = new List<Enrollment>();

			db.Students.Add(dbstudent);
			db.SaveChanges();

			return RedirectToAction("Index");

		}

		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}

			var Student = this.db.Students.SingleOrDefault(s => s.ID == id);
			return View(Student);
		}

		[HttpPost]
		public ActionResult Edit(Student student)
		{
			if (ModelState.IsValid)
			{
				student.EnrollmentDate = DateTime.Now;
				this.db.Entry(student).State = System.Data.Entity.EntityState.Modified;
				this.db.SaveChanges();

			}

			//var Student = this.db.Students.SingleOrDefault(s => s.ID == student.ID);
			//Student.LastName = student.LastName;
			//Student.FirstMidName = student.FirstMidName;
			//this.db.SaveChanges();

			return this.RedirectToAction("Index");
		}


		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}

			var Student = this.db.Students.SingleOrDefault(s => s.ID == id);
			return View(Student);
		}


		[HttpPost]
		[ActionName("Delete")]
		public ActionResult DeletePost(Student student)
		{
			this.db.Entry(student).State = System.Data.Entity.EntityState.Deleted;
			this.db.SaveChanges();


			return RedirectToAction("Index");

		}

	}
}

