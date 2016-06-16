using AsthmaMDWebApp.Models;
using AsthmaMDWebApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AsthmaMDWebApp.Web.Controllers
{
    [Authorize]
    public class ChildController : Controller
    {

        private readonly Lazy<ChildService> _svc;

        //public ChildController()
        //{
        //    _svc =
        //        new Lazy<ChildService>(
        //            () =>
        //            {
        //                var userId = Guid.Parse(User.Identity.GetUserId());
        //                return new ChildService(userId);
        //            });
        //}

        public ActionResult Index()
        {
            var kids = _svc.Value.GetChildren();
            return View(kids);
        }

        [HttpGet]
        public ActionResult CreateChild(ChildViewModel vm)
        {
            if(!ModelState.IsValid) return View(vm);
            if (!_svc.Value.CreateChild(vm))
            {
                ModelState.AddModelError("", "Unable to  add child");
            }
            return RedirectToAction("Index");
        }
    }
}