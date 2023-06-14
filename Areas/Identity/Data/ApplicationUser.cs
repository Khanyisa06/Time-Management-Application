using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Time_Management.Areas.Identity.Data;

// Add profile data for application users by adding properties to the ApplicationUser class
// (Troelsen and Japikse, 2017)
public class ApplicationUser : IdentityUser
{

    public String Firstname { get; set; }
    public String Lastname { get; set; }

}

