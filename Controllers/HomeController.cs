using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Custommers.Controllers
{
    public class HomeController : Controller
    {
        private readonly CustommerService.ICustommerService custommerServiceClient;
        public HomeController()
        {
            this.custommerServiceClient = new CustommerService.CustommerServiceClient();
        }
        public ActionResult Index()
        {
            CustommerService.Custommer[] custommers = custommerServiceClient.GetCustommers();
            return View(custommers);
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        // GET: Test/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: Test/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                CustommerService.Custommer custommer = new CustommerService.Custommer();
                UpdateModel(custommer);
                CustommerService.Error[] errors = custommerServiceClient.AddCustommer(custommer);
                if (errors.Any())
                {
                    ViewData["Error"] = errors;
                    return View(custommer);
                }
                else
                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        // GET: Test/Details

        public ActionResult Details(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustommerService.Custommer custommer = custommerServiceClient.GetCustommerByID(id); ;
            if (custommer == null)
            {
                return HttpNotFound();
            }
            return View(custommer);

        }


        // GET: Test/Edit

        public ActionResult Edit(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustommerService.Custommer custommer = custommerServiceClient.GetCustommerByID(id); ;
            if (custommer == null)
            {
                return HttpNotFound();
            }
            return View(custommer);

        }

        [HttpPost, ActionName("Edit")]
        public ActionResult EditPost()
        {

            try
            {
                CustommerService.Custommer custommer = new CustommerService.Custommer();
                UpdateModel(custommer);
                CustommerService.Error[] errors = custommerServiceClient.UpdateCustommer(custommer);
                if (errors.Any())
                {
                    ViewData["Error"] = errors;
                    return View(custommer);
                }
                else
                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }

        //HttpGet
        public ActionResult Delete(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustommerService.Custommer custommer = custommerServiceClient.GetCustommerByID(id); ;
            if (custommer == null)
            {
                return HttpNotFound();
            }
            return View(custommer);
        }

        //HTTPPost
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            custommerServiceClient.DeleteCustommer(id); ;
            return RedirectToAction("Index");
        }



    }
}