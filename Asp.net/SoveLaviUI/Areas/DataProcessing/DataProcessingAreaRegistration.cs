using System.Web.Mvc;

namespace SoveLaviUI.Areas.DataProcessing
{
    public class DataProcessingAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "DataProcessing";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "DataProcessing_default",
                "DataProcessing/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}