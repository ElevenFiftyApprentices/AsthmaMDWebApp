using AsthmaMDWebApp.Data;
using System;
using System.Linq;

namespace AsthmaMDWebApp.Services
{
    public class UserService
    {
        //Temporay UserProfile
        private UserProfile _UserProfile { get; set; }

        public UserService(string id)
        {
            using (var ctx = new AsthmaDbContext())
            {
                //Grabs an UserProfile based on the id that is entered
                var entity =
                    ctx.
                        UserProfiles.
                            Single(e => e.UserProfileId == id);

                //Sets the temporary UserProfile to the profile found in the query
                _UserProfile = entity;
            }
        }

        public UserProfile GetProfile(UserProfile up)
        {
            //Sets the passed in UserProfile to the temporary profile queryed above
            up = _UserProfile;
            return up;
        }



        /*
         * To use the UserProfile settings you have to instantiate the UserService class and pass in an UserId
         * Then make a new UserProfile that will hold the settings that you'll query
         * Set the new UserProfile to UserService.GetProfile and then pass in that new UserProfile
         * That will set your new UserProfile to the temporary one that was queryed and it will allow you to access all the properties
         * 
         * Example found in ChildService
         */
    }
}