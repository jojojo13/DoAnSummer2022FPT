using CapstoneModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ProfileServices
{
    partial class Profile : IProfile
    {
        public Account GetAccount(Account a)
        {
            return null;
        }
        public bool ChangePass(Account a)
        {
            return false;
        }
    }
}
