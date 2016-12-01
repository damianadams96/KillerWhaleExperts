using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ORCAExpertServices.Models
{
    public class User
    {
        public int UserID {get; set;}

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public char MiddleInit { get; set; }

        public bool Deactivated { get; set;}

        public string Email { get; set; }

        public int Phone { get; set; }

        public string Password { get; set; }

        public bool deactivated { get; set; }


    }
}