using AsthmaMDWebApp.Models;
using AsthmaMDWebApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AsthmaMDWebApp.Web.Controllers
{
    public class LogController : Controller
    {
        private readonly Lazy<LogService> _svc;

        public ActionResult Index(int childId)
        {
            var logs = _svc.Value.GetLogs(childId);
            return View(logs);
        }

        [HttpGet]
        public ActionResult Create()
        {
            try
            {
                var vm = new LogViewModel();

                return View(vm);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Argument Exception. Redirecting to child select.");
                return RedirectToAction("Index", "Child", null);
            }
        }

        [HttpPost]
        public ActionResult Create(LogViewModel vm, int logId)
        {
            if (ModelState.IsValid) return View(vm);
            if (!_svc.Value.CreateLog(vm, logId))
            {
                ModelState.AddModelError("", "Unable to add log.");
                return View(vm);
            }
            return RedirectToAction("Index", new { id = Url.RequestContext.RouteData.Values["id"]});
        }
        
    }
}