using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AsthmaMDWebApp.Data
{
    //UserProfile stores all the values for User Accounts
    public class UserProfile
    {
        /*
         * To use the UserProfile settings you have to instantiate the UserService class and pass in an UserId
         * Then make a new UserProfile that will hold the settings that you'll query
         * Set the new UserProfile to UserService.GetProfile and then pass in that new UserProfile
         * That will set your new UserProfile to the temporary one that was queryed and it will allow you to access all the properties
         * 
         * Example found in ChildService
         */

        public string UserProfileId { get; set; }

        public string FirstName { get; set; }

        public string MiddleInitial { get; set; }

        public string LastName { get; set; }

        public int PhoneNumber { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public uint ZipCode { get; set; }

        public Dictionary<string, int> ChildIds { get; set; }
    }
}