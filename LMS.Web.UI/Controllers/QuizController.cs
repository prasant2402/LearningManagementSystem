using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LMS.Web.UI.Controllers
{
    public class QuizController : Controller
    {
        //
        // GET: /Quiz/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Quiz/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Quiz/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Quiz/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Quiz/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Quiz/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Quiz/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Quiz/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
