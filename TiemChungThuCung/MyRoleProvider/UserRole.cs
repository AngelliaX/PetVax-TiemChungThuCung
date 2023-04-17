using Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace TiemChungThuCung.MyRoleProvider
{
    public class UserRole : RoleProvider
    {
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            TiemChungThuCungDbContext context = new TiemChungThuCungDbContext();
            //check lỗi kho
            
            if (context.accounts.Where(x => x.username == username).FirstOrDefault() == null)
            {
                HttpContextBase httpContextBase = new HttpContextWrapper(HttpContext.Current);
                ClearAuthenticationCookie(httpContextBase);
                return new string[] { new CredentialConstant().GetRole(1) };
            }
            var role_id = context.accounts.Where(x => x.username == username).FirstOrDefault().account_type;
            
            string[] result = { new CredentialConstant().GetRole(role_id)};
            return result;
        }
        private void ClearAuthenticationCookie(HttpContextBase context)
        {
            HttpCookie authCookie = context.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                authCookie.Expires = DateTime.Now.AddDays(-1);
                context.Response.Cookies.Add(authCookie);
            }
        }
        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}