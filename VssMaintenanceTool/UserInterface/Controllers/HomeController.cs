using System;
using System.Web.Mvc;
using System.Linq;
using Volvo.NVS.Core.Unity;
using Volvo.NVS.Logging;
using Volvo.NVS.Persistence.NHibernate.Repositories;
using Volvo.NVS.Utilities.Web.Localization;
using Microsoft.Practices.Unity;
using Volvo.VSSMaintenance.UserDomain.ServiceLayer;
using Volvo.NVS.Persistence.NHibernate.Web.SessionHandling;
using Volvo.MaintenanceTool.UserInterface.Models;
using System.Collections.Generic;
using Volvo.MaintenanceTool.UserInterface.Auth;

namespace Volvo.MaintenanceTool.UserInterface.Controllers
{
    [CustomBaseAuth]
    public class HomeController : BaseController
    {
        [InjectionConstructor]
        public HomeController()
        {
            ChartService = Container.Resolve<IChartDataService>(new ResolverOverride[]
                                  {
                                       new ParameterOverride("name", "hibernate-configuration-data")
                                   });
        }
        //TODO FOR : IUserService userService,IUser_ProfileService userProfileServices
        public HomeController(IChartDataService chartService) : base()
        {

            ChartService = chartService;

        }
        protected IChartDataService ChartService { get; set; }
        protected IUser_ProfileService UsesrProfileService { get; set; }
        public ActionResult Index()
        {
            var chartData = ChartService.GetChartData();
            List<ChartDataModel> datamodel = new List<ChartDataModel>();
            if (chartData != null)
            {
                foreach (var data in chartData)
                {
                    datamodel.Add(new ChartDataModel()
                    {
                        Created = Convert.ToDateTime(data.Created).ToShortDateString(),
                        QuoteCount = data.NumOfQuotes,
                        OrderCount=data.NumOfOrders
                    });
                }
            }
            ViewBag.Controller = "Home";
            ViewBag.Action = "Index";
            return View(datamodel);
        }

        public ActionResult About()
        {
            ViewBag.Controller = "Home";
            ViewBag.Action = "About";
            return View();
        }
    }
}
