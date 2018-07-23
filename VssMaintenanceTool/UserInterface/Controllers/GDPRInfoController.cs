using System.Web.Mvc;
using Volvo.NVS.Core.Unity;
using Microsoft.Practices.Unity;
using Volvo.VSSMaintenance.UserDomain.ServiceLayer;
using Volvo.MaintenanceTool.UserInterface.Auth;
using Common;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using Volvo.MaintenanceTool.UserInterface.Common.Extensions;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using Volvo.MaintenanceTool.UserInterface.Models;
using Volvo.VSSMaintenance.UserDomain.DomainLayer.Entities;
using System;
using System.Data;
using System.Data.SqlClient;
using NHibernate;
using Volvo.VSSMaintenance.UserDomain.DomainLayer;
using CommandType = Kendo.Mvc.UI.CommandType;

namespace Volvo.MaintenanceTool.UserInterface.Controllers
{
    [CustomBaseAuth]
    public class GDPRInfoController : BaseController
    {

        protected IGDPRService GDPRService;

        public GDPRInfoController()
        {
            GDPRService = Container.Resolve<IGDPRService>(new ResolverOverride[] { new ParameterOverride("name", "hibernate-configuration-data") });
        }
        public GDPRInfoController(IGDPRService gdprService) : base()
        {
            GDPRService = gdprService;
        }


        // GET: GDPRInfo
        public ActionResult Index()
        {
            ViewBag.Controller = "User";
            ViewBag.Action = "GDPRInfo";
            return View();
        }

        //public PartialViewResult GetGDPRUserInfo(GDPRInfoSearch searchCriteria)
        //{
        //    var gdprInfo = GDPRService.GetGDPRUserInfoDetail(searchCriteria.SearchString);
        //    //userInfo.SignatureImage = String.Format("data:image/png;base64,{0}", (userInfo.SignatureImage));
        //    return PartialView("GDPRInfo", gdprInfo);
        //}
        public ActionResult GetGDPRInfo1([DataSourceRequest]DataSourceRequest dataSourceRequest, GDPRInfoSearch searchCriteria)
        {
            var page = dataSourceRequest.Page <= 0 ? 1 : dataSourceRequest.Page;
            var pageSize = dataSourceRequest.PageSize <= 0 ? 10 : dataSourceRequest.PageSize;
            var skip = (page - 1) * pageSize;
            var take = pageSize;
            var gdprInfo = GDPRService.GetGDPRInfoDetail(searchCriteria);

            DataSourceResult result = gdprInfo.GDPRInfoList.ToDataSourceResult(dataSourceRequest, p => new GDPRInfo
            {
                PersonType = p.PersonType,
                UserID = p.UserID,
                Salutation = p.Salutation,
                Title = p.Title,
                FirstName = p.FirstName,
                MiddleName = p.MiddleName,
                SurName = p.SurName,
                Gender = p.Gender,
                Profession = p.Profession,
                Email = p.Email,
                Phone = p.Phone,
                Mobile = p.Mobile,
                Note = p.Note,
                Fax = p.Fax,
                Signature = p.Signature,
            });
            result.Data = gdprInfo.GDPRInfoList;
            var jsonResult = Json(result, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        public PartialViewResult GetGDPRInfo(GDPRInfoSearch searchCriteria)
        {
            var gdprInfo = GDPRService.GetGDPRInfo(searchCriteria);
            //userInfo.SignatureImage = String.Format("data:image/png;base64,{0}", (userInfo.SignatureImage));
            return PartialView("GDPRInfo", gdprInfo);
        }
    }
}