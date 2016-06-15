using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AsthmaMDWebApp.Data
{
    //UserProfile stores all the values for User Accounts
    public class UserProfile
    {
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