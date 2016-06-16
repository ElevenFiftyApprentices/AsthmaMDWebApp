using AsthmaMDWebApp.Data;
using System;
using System.Linq;

namespace AsthmaMDWebApp.Services
{
    public class UserService
    {
        private UserProfile _UserProfile { get; set; }

        public UserService(string id)
        {
            using (var ctx = new AsthmaDbContext())
            {
                var entity =
                    ctx.
                        UserProfiles.
                            Single(e => e.UserProfileId == id);


                _UserProfile = entity;
            }
        }
    }
}