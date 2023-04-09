using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Framework;

namespace Models
{
    public class AccountModel
    {
        private TiemChungThuCungDbContext context = null;
        public AccountModel()
        {
            context = new TiemChungThuCungDbContext();
        }

        public bool Login(string username, string password)
        {
            if (username == null || password == null)
            {
                return false;
            }
            /*
            object[] sqlParams =
            {
                new SqlParameter("@username", username),
                new SqlParameter("@password", password),
            };
            var res = context.Database.SqlQuery<bool>("Sp_Account_Login @username,@password",sqlParams).SingleOrDefault();
            */
            var res = false;
            var count = context.accounts.Count(p => p.username == username && p.password == password);
            
            if (count > 0)
            {
                res = true;
            }
            return res;
        }
    }
}
