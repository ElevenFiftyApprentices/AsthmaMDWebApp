using AsthmaMDWebApp.Data;
using AsthmaMDWebApp.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AsthmaMDWebApp.Web.Controllers
{
    public class UserController
    {
        private readonly Lazy<UserService> _svc;

        public UserController()
        {
            _svc =
                new Lazy<UserService>(
                    () =>
                    {
                        User.Identity.GetUserId();
                        return new UserService(userId);
                    });
        }
    }
}