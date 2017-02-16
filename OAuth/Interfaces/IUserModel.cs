using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAuth.Interfaces
{
    public interface IUserModel:IUser
    { 
        string Password { get; set; }
        string ConfirmPassword { get; set; }
    }
}
