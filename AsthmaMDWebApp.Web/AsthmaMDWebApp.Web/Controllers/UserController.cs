using AsthmaMDWebApp.Services;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System;
using AsthmaMDWebApp.Data;

namespace AsthmaMDWebApp.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly Lazy<UserService> _svc;
        public UserProfile _UserProfile;

        public UserController()
        {
            User.Identity.GetUserId();

            _svc =
                new Lazy<UserService>(
                    () =>
                    {
                        var userId = User.Identity.GetUserId();
                        return new UserService(userId);
                    });

            _UserProfile = _svc.Value.GetProfile(_UserProfile);
        }
    }
}