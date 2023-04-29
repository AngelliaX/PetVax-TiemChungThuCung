using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiemChungThuCung.Areas.CommonUse
{
    public static class AppointmentCommonUse
    {
        public static string getStatus(int? state)
        {
            switch (state)
            {
                case 0:
                    return "Chờ bác sĩ";
                    break;
                case 1:
                    return "Chờ tới hẹn";
                    break;
                case 2:
                    return "Thành công";
                    break;
                case 3:
                    return "Thất bại";
                    break;
                default:
                    return "Có lỗi";
                    break;
            }
        }
    }
}