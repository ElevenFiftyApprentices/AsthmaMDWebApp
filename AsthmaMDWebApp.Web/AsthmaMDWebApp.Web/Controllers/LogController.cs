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

        public ActionResult Index()
        {
            return View();
        }
    }
}