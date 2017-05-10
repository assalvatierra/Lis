using System.Web.Mvc;

namespace LIS.v10.Areas.HIS10
{
    public class HIS10AreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "HIS10";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "HIS10_default",
                "HIS10/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}