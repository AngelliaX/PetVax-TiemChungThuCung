using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiemChungThuCung.MyRoleProvider
{
    public class CredentialConstant
    {
        public string GetRole(int? role_id)
        {
            switch(role_id)
            {
                case 0:
                    return "Admin";
                    break;
                case 1:
                    return "Client";
                    break;
                case 2:
                    return "Doctor";
                    break;
                case 3:
                    return "Pharmacist";
                    break;
                case 4:
                    return "Cashier";
                    break;
                default:
                    return "Client";
                    break;
            }

        }
    }
}