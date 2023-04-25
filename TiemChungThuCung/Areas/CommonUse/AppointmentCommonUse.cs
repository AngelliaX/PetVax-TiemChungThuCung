using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiemChungThuCung.Areas.CommonUse
{
    public static class AppointmentCommonUse
    {
        public static string getStatus(int state)
        {
            switch (state)
            {
                case 0:
                    return "Đang chờ";
                    break;
                case 1:
                    return "Thất bại";
                    break;
                case 2:
                    return "Thành công";
                    break;
                default:
                    return "Có lỗi";
                    break;
            }
        }
    }
}