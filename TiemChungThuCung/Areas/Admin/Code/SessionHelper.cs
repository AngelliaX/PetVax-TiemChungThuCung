using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiemChungThuCung.Areas.Admin.Code
{
    public class SessionHelper
    {
        public static void SetSesson(UserSession session)
        {
            HttpContext.Current.Session["loginSession"] = session;
        }
        public static UserSession GetSession()
        {
            var session = HttpContext.Current.Session["loginSession"];
            if(session == null)
            {
                return null;
            }
            else
            {
                return session as UserSession;
            }
        }
    }
}