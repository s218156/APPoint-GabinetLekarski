using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APPoint.App.Exceptions;
using APPoint.App.Models.Data;
using Microsoft.AspNetCore.Mvc.Filters;

namespace APPoint.App.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class RequireRoleAttribute : Attribute, IAuthorizationFilter
    {
        private readonly string _role;

        public RequireRoleAttribute(string role)
        {
            _role = role;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.Items["User"] is not User user)
            {
                throw new AuthorizationException();
            }

            if (user.UserType.Type != _role)
            {
                throw new AuthorizationException();
            }
        }
    }
}
