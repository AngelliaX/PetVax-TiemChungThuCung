using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EntityFramework;
namespace Models.DataAccessLayer
{
    public class AccountDAO
    {
        private TiemChungThuCungDbContext context = null;
        public AccountDAO()
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
        public bool isUsernameExisted(string username)
        {
            var res = false;
            var count = context.accounts.Count(p => p.username == username);

            if (count > 0)
            {
                res = true;
            }
            return res;
        }

        public void insertNewAccount(string username, string password, int account_type = 1)
        {
            var account = new account();
            account.username = username;
            account.password = password;
            account.account_type = account_type;
            account.birthday = DateTime.Now;
            account.account_init_day = DateTime.Now;
            context.accounts.Add(account);
            context.SaveChanges();
        }

        public void updateAccountProfile(string username, string name, string email, string phone, string address, DateTime? birthday)
        {
            account accountToUpdate = context.accounts.FirstOrDefault(a => a.username == username);

            if (accountToUpdate != null)
            {
                // Update the account properties
                accountToUpdate.name = name;
                accountToUpdate.email = email;
                accountToUpdate.phone = phone;
                accountToUpdate.address = address;
                accountToUpdate.birthday = birthday;

                // Save the changes to the database
                context.SaveChanges();
            }
            context.SaveChanges();
        }

        public bool updatePassword(string username, string oldpassword, string newpassword)
        {
            account accountToUpdate = context.accounts.FirstOrDefault(a => a.username == username);
            if (accountToUpdate != null)
            {
                if (oldpassword == accountToUpdate.password)
                {
                    accountToUpdate.password = newpassword;
                    context.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public account getAccountbyUsername(string username)
        {
            account acc = context.accounts.FirstOrDefault(p => p.username == username);
            return acc;
        }

    }
}
