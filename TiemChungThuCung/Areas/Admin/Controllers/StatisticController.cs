using Models.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TiemChungThuCung.Areas.Admin.Controllers
{
    public class StatisticController : AdminBaseController
    {
        // GET: Admin/Statistic
        public ActionResult Index()
        {
            var statisticDAO = new StatisticDAO();
            var model = statisticDAO.ListAll();
            return View(model);
        }

        // GET: Admin/Statistic/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Statistic/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Statistic/Create
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

        // GET: Admin/Statistic/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Statistic/Edit/5
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

        // GET: Admin/Statistic/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Statistic/Delete/5
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
