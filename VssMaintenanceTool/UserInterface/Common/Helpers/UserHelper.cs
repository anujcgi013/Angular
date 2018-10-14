using System.Web;
using System.Web.Mvc;

namespace Volvo.MaintenanceTool.UserInterface.Common.Helpers
{
    public static class UserHelper
    {
        /// <summary>
        /// Gets the current logged user.
        /// </summary>
        /// <param name="instance">The instance.</param>
        public static string GetCurrentUser(this HtmlHelper instance)
        {
            return HttpContext.Current.User.Identity.Name;
        }
    }
}