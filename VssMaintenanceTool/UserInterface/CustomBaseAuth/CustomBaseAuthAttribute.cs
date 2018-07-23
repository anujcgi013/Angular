using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using Volvo.VSSMaintenance.UserDomain.ServiceLayer;
using Volvo.VSSMaintenance.UserDomain.DomainLayer;
using System.Web.Routing;
using Volvo.VSSMaintenance.UserDomain.InfrastructureLayer.Repositories;
using Microsoft.Practices.Unity;
using Volvo.NVS.Core.Unity;

namespace Volvo.MaintenanceTool.UserInterface.Auth
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class CustomBaseAuthAttribute : FilterAttribute, IAuthorizationFilter
    {
        protected IUserService UserService;
        protected IUser_ProfileService UserProfileService;
        private readonly IEnumerable<string> roles;
        public CustomBaseAuthAttribute(params object[] roles)
        {
            this.roles = roles.Cast<string>().ToArray();
            UserService = Container.Resolve<IUserService>(new ResolverOverride[]
                                   {
                                       new ParameterOverride("name", "hibernate-configuration-data")
                                   });
            UserProfileService = Container.Resolve<IUser_ProfileService>(new ResolverOverride[]
                                  {
                                       new ParameterOverride("name", "hibernate-configuration-data")
                                  });
        }
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            //    var user1 = filterContext.Controller.ControllerContext.HttpContext.User.Identity.Name;
            //    var user2 = System.Web.HttpContext.Current.User.Identity.Name;
            //    var user3 = HttpContext.Current.User.Identity.Name;

            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                filterContext.Result = new RedirectToRouteResult(
                                           new RouteValueDictionary {
                                                { "action", "Index" },
                                                { "controller", "Unauthorised" } });
                return;
            }

            var BaldoUserId = filterContext.RequestContext.HttpContext.User.Identity.Name;
            if (!String.IsNullOrWhiteSpace(BaldoUserId))
            {
                BaldoUserId = BaldoUserId.Split(new[] { '\\' }, StringSplitOptions.RemoveEmptyEntries)[1];
            }
            
            var user = UserService.GetUser(BaldoUserId);
            bool profile =false;
            if (user == null)
            {
                filterContext.Result = new RedirectToRouteResult(
                                   new RouteValueDictionary {
                                                { "action", "Index" },
                                                { "controller", "Unauthorised" } });
                return;
            }
            var UserFirstName = user.FirstName;
            filterContext.HttpContext.Session["BaldoUserId"] = BaldoUserId;
            filterContext.HttpContext.Session["BaldoUserName"] = UserFirstName;
            profile = UserProfileService.IsUserAdmin(user.Id);
            if (!profile)
            {
                filterContext.Result = new RedirectToRouteResult(
                                           new RouteValueDictionary {
                                                { "action", "AccessDenied" },
                                                { "controller", "Unauthorised" } });
            }
           
        }
    }
}