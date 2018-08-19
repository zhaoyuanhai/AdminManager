using AdminTemplate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace AdminTemplate
{
    public static class WebValidateUserExtend
    {
        public static UserModel CurrentUser(this IPrincipal principal)
        {
            if (principal.Identity.IsAuthenticated)
            {

            }
            return new UserModel();
        }
    }
}
