using System.Web.Mvc;

namespace TiemChungThuCung.Areas.Pharmacist
{
    public class PharmacistAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Pharmacist";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Pharmacist_default",
                "Pharmacist/{controller}/{action}/{id}",
                new { action = "Index", controller = "Home", id = UrlParameter.Optional }
            );
        }
    }
}