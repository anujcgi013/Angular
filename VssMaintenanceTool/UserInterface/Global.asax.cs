using System;
using System.Collections.Generic;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

using Volvo.NVS.Core.Unity;
using Volvo.NVS.Logging;
using Volvo.NVS.Utilities.Web.Localization;
using Volvo.MaintenanceTool.UserInterface.App_LocalResources;
using Volvo.MaintenanceTool.UserInterface.Automapper;
using Volvo.MaintenanceTool.UserInterface.Bundling;
using Volvo.MaintenanceTool.UserInterface.Controllers;
using Volvo.MaintenanceTool.UserInterface.EntLib;
using Volvo.MaintenanceTool.UserInterface.Routes;
using Volvo.MaintenanceTool.UserInterface.Unity;
using System.Web.Optimization;

namespace Volvo.MaintenanceTool.UserInterface
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : HttpApplication
    {
        /// <summary>
        /// Auxiliary property which returns the current Http Context wrapped in a new HttpContextWrapper object.
        /// </summary>
        private HttpContextBase HttpContextBase { get { return new HttpContextWrapper(Context); } }

        /// <summary>
        /// Auxiliary property which returns an instance of a ILocalizationHelper resolved by Unity container.
        /// </summary>
      //  private ILocalizationHelper LocalizationHelper { get { return Container.Resolve<ILocalizationHelper>(); } }

        protected void Application_Start()
        {
            // Configure the unity container
            ContainerConfig.Configure();

            // Configure Enterprise Library
            EntLibConfig.Configure();

            // Register all the areas in the MVC application
            AreaRegistration.RegisterAllAreas();

            // Configure the bundling and minification
            BundleConfig.Configure();

            // Configure AutoMapper registring all the Profiles
            AutomapperConfig.Configure();

            // Register all the routes
            RoutesConfig.RegisterRoutes(RouteTable.Routes);
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());
        }

        /// <summary>
        /// Initialize the session for the current user.
        /// </summary>
        protected void Session_Start(object sender, EventArgs e)
        {
            // Configure your session helper
        }

        /// <summary>
        /// Acquires the current state (for example, session state) that is associated with the current request.
        /// </summary>
        protected void Application_AcquireRequestState(object sender, EventArgs e)
        {
            // We set the culture in the AcquireRequestState so the MVC binders will also execute under
            // the set and correct culture. This method is called before the MVC binders run.
            // The culture itself is stored in cookies so earlier events would also not function as 
            // there would be no possibility to set the cookies. There would also be no session yet.
           // LocalizationHelper.SetCulture(HttpContextBase);
        }

        /// <summary>
        /// Write the error view into the <see cref="HttpResponse"/>.
        /// </summary>
        /// <param name="application">The current http application object.</param>
        /// <param name="exception">The exception object with the current application error.</param>
        /// <param name="actionName">The Error controller action to be executed.</param>
        private void WriteErrorView(HttpApplication application, Exception exception, string actionName)
        {
            const string controllerName = "Error";

            var controller = new ErrorController
            {
                ViewData = { Model = new HandleErrorInfo(exception, controllerName, actionName) }
            };

            var routeData = new RouteData();
            routeData.Values["controller"] = controllerName;
            routeData.Values["action"] = actionName;
            ((IController)controller).Execute(new RequestContext(new HttpContextWrapper(application.Context), routeData));
        }

        /// <summary>
        /// Write the not authorized view into the response.
        /// </summary>
        /// <param name="application">The current http application object.</param>
        /// <param name="exception">The current authorization related exception.</param>
        private void WriteNotAuthorized(HttpApplication application, Exception exception)
        {
            Log.Error("Access is denied", exception);
            WriteErrorView(application, exception, "NotAuthorized");
        }

        /// <summary>
        /// Retrieves the http error code if an exception is the http exception.
        /// </summary>
        /// <param name="exception">The exception to be examined and from which the error code should be returned.</param>
        /// <returns>The http error code is exception is the http exception or the internal server error code.</returns>
        private static HttpStatusCode GetHttpErrorCode(Exception exception)
        {
            HttpException httpException = exception as HttpException;
            if (httpException != null)
            {
                return (HttpStatusCode)httpException.GetHttpCode();
            }
            return HttpStatusCode.InternalServerError;
        }

        /// <summary>
        /// Replace an original exception into the one which can be passed into the error view.
        /// </summary>
        /// <param name="exception">The original exception object.</param>
        /// <returns>The replaced exception object.</returns>
        private static Exception ReplaceException(Exception exception)
        {
            Exception exceptionToThrow;

            switch (GetHttpErrorCode(exception))
            {
                case HttpStatusCode.NotFound:
                    exceptionToThrow = new Exception(CommonResource.Error_404Message);
                    break;

                default:
                    ExceptionPolicy.HandleException(exception, "LogAndWrap", out exceptionToThrow);
                    break;
            }
            return exceptionToThrow;
        }

        /// <summary>
        /// Write the generic error view into the response.
        /// </summary>
        /// <param name="application">The current http application object.</param>
        /// <param name="exception">The current authorization related exception.</param>
        private void WriteGenericError(HttpApplication application, Exception exception)
        {
            WriteErrorView(application, exception, "Index");
        }

        /// <summary>
        /// Handle the application error redirecting into the error page.
        /// </summary>
        protected void Application_Error(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;

            // Get information about the exception detected for the current request
            // At this stage we know it is not authorization related exception
            var exception = Server.GetLastError();

            // Clear all the errors collected so far
            application.Context.ClearError();

            // Clear the current response and write a new one. For any other error handling
            // (other than authorization) the status code is alway 500 (InternalServerError)
            HttpResponse response = application.Response;
            response.Clear();
            response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var friendlyException = ReplaceException(exception);

            // For Ajax request we are only retuning the error code and the friendly message into the client
            // and so the Ajax on error event handler can be called on the client side
            // For non Ajax requests we are writing the view error into the response
            if (!IsAjaxRequest(application.Request))
            {
                WriteGenericError(application, friendlyException);
            }
            else
            {
                response.Write(friendlyException.Message);
            }
        }

        /// <summary>
        /// Determines if the current request is the AjaxRequest.
        /// </summary>
        /// <param name="request">The request object to be examined.</param>
        /// <returns>True if request is recognized as Ajax request.</returns>
        public bool IsAjaxRequest(HttpRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }
            return (request["X-Requested-With"] == "XMLHttpRequest") || ((request.Headers != null) && (request.Headers["X-Requested-With"] == "XMLHttpRequest"));
        }
    }
}