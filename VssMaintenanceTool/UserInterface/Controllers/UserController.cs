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

namespace Volvo.MaintenanceTool.UserInterface.Controllers
{
    [CustomBaseAuth]
    public class UserController : BaseController
    {
        protected IUserInfoService UserInfoService;
        public UserController()
        {
            UserInfoService = Container.Resolve<IUserInfoService>(new ResolverOverride[] { new ParameterOverride("name", "hibernate-configuration-data") });
        }
        public UserController(IUserInfoService userInfoService) : base()
        {
            UserInfoService = userInfoService;
        }

        // GET: User
        //[HttpGet]
        public ActionResult Index()
        {
            ViewBag.Controller = "User";
            ViewBag.Action = "User";
            return View();
        }

        public ActionResult GetUserOrganisationInfo([DataSourceRequest]DataSourceRequest dataSourceRequest, UserOrganisationSearch searchCriteria)
        {
            var page = dataSourceRequest.Page <= 0 ? 1 : dataSourceRequest.Page;
            var pageSize = dataSourceRequest.PageSize <= 0 ? 10 : dataSourceRequest.PageSize;
            var skip = (page - 1) * pageSize;
            var take = pageSize;
            var userOrganisationInfo = UserInfoService.GetUserOrganisationInfo(searchCriteria);
            DataSourceResult result = userOrganisationInfo.UserOrganisationInfoList.ToDataSourceResult(dataSourceRequest, p => new UserOrganisationInfo
            {
                BaldoUserId = p.BaldoUserId,
                FirstName = p.FirstName,
                SurName = p.SurName,
                UserId = p.UserId,
                OrganisationId = p.OrganisationId,
                CommonName = p.CommonName,
                LegalName = p.LegalName,
                CDBPartyId = p.CDBPartyId
            });
            result.Data = userOrganisationInfo.UserOrganisationInfoList;
            result.Total = userOrganisationInfo.Total;
            var jsonResult = Json(result, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
        public PartialViewResult GetUserDetail(string BaldoUserId)
        {
            var userInfo = UserInfoService.GetUserDetail(BaldoUserId);
            //userInfo.SignatureImage = String.Format("data:image/png;base64,{0}", (userInfo.SignatureImage));
            return PartialView("_UserInfo", userInfo);
        }
        public PartialViewResult GetOrganisationDetail(Guid OrganisationId)
        {
            var organisationInfo = UserInfoService.GetOrganisationDetail(OrganisationId);
            return PartialView("_OrganisationInfo", organisationInfo);
        }
        public PartialViewResult GetRUSettingsDetail(Guid RUSettingsId)
        {
            var ruSettingsInfo = UserInfoService.GetRUSettingsDetail(RUSettingsId);
            return PartialView("_RUSettingsInfo", ruSettingsInfo);
        }
        public ActionResult UserProfile()
        {
            ViewBag.Controller = "User";
            ViewBag.Action = "User Profile";
            return View();
        }
        public ActionResult GetUserProfileInfo([DataSourceRequest]DataSourceRequest dataSourceRequest, UserProfileSearch searchCriteria)
        {
            var page = dataSourceRequest.Page <= 0 ? 1 : dataSourceRequest.Page;
            var pageSize = dataSourceRequest.PageSize <= 0 ? 10 : dataSourceRequest.PageSize;
            var skip = (page - 1) * pageSize;
            var take = pageSize;
            var userProfileInfo = UserInfoService.GetUserProfileInfo(searchCriteria);
            DataSourceResult result = userProfileInfo.UserProfileInfoList.ToDataSourceResult(dataSourceRequest, p => new UserProfileInfoModel
            {
                UserProfileId = p.UserProfileId,
                ProfileId = p.ProfileId,
                Profile = p.Profile,
                UserId = p.UserId,
                BaldoUserId = p.BaldoUserId,
                FirstName = p.FirstName,
                SurName = p.SurName
            });
            result.Data = userProfileInfo.UserProfileInfoList;
            result.Total = userProfileInfo.Total;
            var jsonResult = Json(result, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
    }
}