using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Volvo.MaintenanceTool.UserInterface.Models;
using Volvo.NVS.Core.Unity;
using Microsoft.Practices.Unity;
using Volvo.VSS.ProcessDomain.ServiceLayer;
using AutoMapper;
using Volvo.NVS.Persistence.NHibernate.Web.SessionHandling;
using Volvo.VSS.LogDomain.DomainLayer.Entities;
using Volvo.VSS.ProcessDomain.DomainLayer.Entities;
using System.IO;
using Volvo.VSS.LogDomain.ServiceLayer;
using Common;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using Volvo.MaintenanceTool.UserInterface.Auth;
using Volvo.MaintenanceTool.UserInterface.Common.Extensions;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using Volvo.VSS.ProcessDomain.DomainLayer;
using Volvo.MaintenanceTool.UserInterface.Common;
//using Volvo.TSP.ProcessUtilityComponent.ServiceLayer;
//using Volvo.TSP.ProcessUtilityComponent.DomainLayer;

namespace Volvo.MaintenanceTool.UserInterface.Controllers
{
    [CustomBaseAuth]
    public class TechnicalDashBoardController : BaseController
    {
        public TechnicalDashBoardController()
        {
            ProcessService = Container.Resolve<IProcessService>(new ResolverOverride[]
                                   {
                                       new ParameterOverride("name", "hibernate-configuration-process")
                                   });
            LogService = Container.Resolve<ILogService>(new ResolverOverride[]
                                   {
                                       new ParameterOverride("name", "hibernate-configuration-log")
                                   });
        }


        public TechnicalDashBoardController(ILogService logService, IProcessService processService) : base()
        {
            LogService = logService;
            ProcessService = processService;
        }
        protected ILogService LogService { get; set; }
        protected IProcessService ProcessService { get; set; }

        protected JsonResult JsonUtc(object data)
        {
            return new JsonUtcResult
            {
                Data = data
            };
        }

        public JsonResult GetProcessList()
        {
            Mapper.CreateMap<ProcessInstance, ProcessInstanceModel>();
            IList<ProcessInstanceModel> processList = new List<ProcessInstanceModel>();
            //TODO : Paging 
            PageSettings paging = new PageSettings();
            paging.ItemsPerPage = 10;
            paging.PageNumber = 1;
            var process = ProcessService.GetProcessList(paging);

            foreach (var item in process)
            {
                ProcessInstanceModel processDetails = new ProcessInstanceModel();
                Mapper.Map(item, processDetails);
                processList.Add(processDetails);
            }
            // return PartialView("_ProcessSearchResult", processList);
            return Json(processList, JsonRequestBehavior.AllowGet);
        }


        public JsonResult SearchProcessDeatils([DataSourceRequest]DataSourceRequest dataSourceRequest, ProcessInstanceSearchModel searchCriteria)
        {
            //TODO : Use MapperConfiguration 
            Mapper.CreateMap<ProcessInstanceSearchModel, ProcessInstanceSearch>();
            ProcessInstanceSearch search = new ProcessInstanceSearch();
            Mapper.Map(searchCriteria, search);
            Mapper.CreateMap<ProcessInstance, ProcessInstanceModel>();
            IList<ProcessInstanceModel> processList = new List<ProcessInstanceModel>();

            var process = ProcessService.GetProcessDeatils(search);

            foreach (var item in process)
            {
                ProcessInstanceModel processDetails = new ProcessInstanceModel();
                Mapper.Map(item, processDetails);
                processList.Add(processDetails);
            }
            //return Json(processList, JsonRequestBehavior.AllowGet);
            //return Json(new
            //{
            //    PartialView = ConvertViewToString("_ProcessSearchResult", processList)
            //});
            //DataSourceResult result = processList.ToDataSourceResult(dataSourceRequest, p => new Models.ProcessInstanceSearchModel
            //{
            //    ProcessId = p.ProcessId,
            //    State = p.State,
            //    Status = p.Status,
            //    InterfaceName = p.InterfaceName,
            //    FIFOTag = p.FIFOTag,
            //    StartDate = p.CreatedAt,
            //    EndDate = p.UpdatedAt,
            //    FIFOTag2 = p.FIFOTag2
            //});

            return Json(processList, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ProcessDetails(string processId)
        {
            //var eventLog = LogService.GetEventLog(25171134);
            return View();
        }

        /* //------------- START - Method to support Kendo UI - DataSource Read ----------------------
        public JsonResult BindGrid([DataSourceRequest]DataSourceRequest dataSourceRequest)
        {
            try
            {
                decimal companyId = 0;
                List<ProcessInstanceModel> lst = new List<ProcessInstanceModel>();
                PageSettings page = new PageSettings();
                page.PageNumber = 1;
                //TODO : PageSize is not coming in Request
                page.ItemsPerPage = 5;

                lst = GetProcessListData().ToList();
                DataSourceResult result = lst.ToDataSourceResult(request, p => new Models.ProcessInstanceModel
                {
                    ProcessId = p.ProcessId,
                    State = p.State,
                    Status = p.Status,
                    InterfaceName = p.InterfaceName,
                    FIFOTag = p.FIFOTag,
                    CreatedAt = p.CreatedAt,
                    UpdatedAt = p.UpdatedAt,
                    FIFOTag2 = p.FIFOTag2
                });
                return Json(lst, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                var errorMsg = ex.Message.ToString();
                return Json(errorMsg, JsonRequestBehavior.AllowGet);
            }
        }

        [NonAction]
        public JsonResult GetProcessListData()
        {
            Mapper.CreateMap<ProcessInstance, ProcessInstanceModel>();
            IList<ProcessInstanceModel> processList = new List<ProcessInstanceModel>();

            var process = ProcessService.GetProcessList();

            foreach (var item in process)
            {
                ProcessInstanceModel processDetails = new ProcessInstanceModel();
                Mapper.Map(item, processDetails);
                processList.Add(processDetails);
            }
            return Json(processList, JsonRequestBehavior.AllowGet);
            //return processList.ToList().AsEnumerable();
        }
        //--------------------- END - Method to support Kendo UI - DataSource -------------*/

        public ActionResult GetLogIndex(string id)
        {
            //EventLogSearchModel eventLog = new EventLogSearchModel();
            TempData["Id"] = id;
            return RedirectToAction("EventLog");
        }
        public ActionResult LogIndex(string id)
        {
            EventLogSearchModel eventLog = new EventLogSearchModel();
            eventLog.SeverityList = LogService.GetSeverityTypeEnumList().Select(n => new SelectListItem { Value = n.Value.ToString(), Text = n.Name }).ToList();
            eventLog.BusinessTypeIdList = LogService.GetBusinessIdTypeEnumList().Select(n => new SelectListItem { Value = n.Value.ToString(), Text = n.Name }).ToList();
            var select = new SelectListItem() { Value = null, Text = "----- select -----" };
            eventLog.SeverityList.Insert(0, select);
            eventLog.BusinessTypeIdList.Insert(0, select);
            ViewBag.Id = TempData.Peek("Id");
            eventLog.Message = ViewBag.Id;
            return View("LogIndex", eventLog);
        }

        public ActionResult GetEventLogsOnLoad([DataSourceRequest]DataSourceRequest dataSourceRequest)
        {
            //TODO : Use MapperConfiguration 
            Mapper.CreateMap<EventLog, EventLogModel>();
            IList<EventLogModel> eventLogList = new List<EventLogModel>();
            PageSettings pageSetting = new PageSettings();
            pageSetting.ItemsPerPage = 10;
            pageSetting.PageNumber = 1;
            ///*25171130, 25171131, 25171132, 25171133,25171134*/
            var eventLog = LogService.GetEventLogList(pageSetting);
            foreach (var item in eventLog)
            {
                EventLogModel eventLogDetails = new EventLogModel();
                Mapper.Map(item, eventLogDetails);
                eventLogList.Add(eventLogDetails);
            }

            DataSourceResult result = eventLog.ToDataSourceResult(dataSourceRequest, p => new EventLog
            {
                //Id = p.ev,
                Id = p.Id,
                Severity = p.Severity,
                RequestId = p.RequestId,
                BusinessId = p.BusinessId,
                Message = p.Message,
                MachineName = p.MachineName,
                UserId = p.UserId,
                Timestamp = p.Timestamp,
                IntegrationMessageId = p.IntegrationMessageId
            });
            return JsonUtc(result);

            // return PartialView("_EventLogResult", eventLogList);
            //return Json(new
            //{
            //    PartialView = ConvertViewToString("_EventLogResult", eventLogList)
            //});
        }

        public JsonResult GetEventLogss(EventLogModel searchCriteria)
        {
            //TODO : Use MapperConfiguration 
            Mapper.CreateMap<EventLog, EventLogModel>();
            IList<EventLogModel> eventLogList = new List<EventLogModel>();
            PageSettings pageSetting = new PageSettings();
            pageSetting.ItemsPerPage = 10;
            pageSetting.PageNumber = 1;
            ///*25171130, 25171131, 25171132, 25171133,25171134*/
            var eventLog = LogService.GetEventLogList(pageSetting);
            foreach (var item in eventLog)
            {
                EventLogModel eventLogDetails = new EventLogModel();
                Mapper.Map(item, eventLogDetails);
                eventLogList.Add(eventLogDetails);
            }
            return Json(new
            {
                PartialView = ConvertViewToString("_EventLogResult", eventLogList)
            });
        }
        [HttpPost]
        public JsonResult SearchEventLogByProcessId(EventLogSearch model)
        {
            //TODO : Use MapperConfiguration 
            Mapper.CreateMap<EventLog, EventLogModel>();
            IList<EventLogModel> eventLogList = new List<EventLogModel>();
            EventLogSearchModel searchModel = new EventLogSearchModel();
            EventLogSearch search = new EventLogSearch();
            if (!(model.Id.HasValue || model.Severity.HasValue || model.RequestId.HasValue || !string.IsNullOrWhiteSpace(model.BusinessId) || !string.IsNullOrWhiteSpace(model.Message) ||
                !string.IsNullOrWhiteSpace(model.MachineName) || !string.IsNullOrWhiteSpace(model.UserId) || model.StartDate.HasValue || model.EndDate.HasValue || model.IntegrationMessageId.HasValue))
            {
                model.StartDate = DateTime.Now.AddHours(-6);
                model.EndDate = DateTime.Now;
            }

            PageSettings paging = new PageSettings();
            paging.ItemsPerPage = 10;
            paging.PageNumber = 1;

            var eventLog = LogService.GetEventLog(model, paging);
            foreach (var item in eventLog)
            {
                EventLogModel eventLogDetails = new EventLogModel();
                Mapper.Map(item, eventLogDetails);
                eventLogList.Add(eventLogDetails);
            }

            return Json(eventLogList, JsonRequestBehavior.AllowGet);

        }

        public JsonResult SearchEventLogByRequestId(string requestId, string time)
        {
            Mapper.CreateMap<EventLog, EventLogModel>();
            IList<EventLogModel> eventLogList = new List<EventLogModel>();
            PageSettings pageSetting = new PageSettings();
            pageSetting.ItemsPerPage = 10;
            pageSetting.PageNumber = 1;

            var eventLog = LogService.GetEventLogList(pageSetting);
            foreach (var item in eventLog)
            {
                EventLogModel eventLogDetails = new EventLogModel();
                Mapper.Map(item, eventLogDetails);
                eventLogList.Add(eventLogDetails);
            }
            return Json(new
            {
                PartialView = ConvertViewToString("_EventLogResult", eventLogList)
            });
        }

        public ActionResult IntegrationMessageIndex()
        {
            IntegrationMessageModel messageLog = new IntegrationMessageModel();
            return View(messageLog);
        }

        [NHibernateMvcSessionContext()]
        //public JsonResult GetIntegrationMessages(EventLogModel searchCriteria)
        //{
        //    //TODO : Use MapperConfiguration 
        //    Mapper.CreateMap<IntegrationMessage, IntegrationMessageModel>();
        //    IList<IntegrationMessageModel> messageLogList = new List<IntegrationMessageModel>();
        //    int id = 2014278;
        //    if (searchCriteria.Id != 0)
        //    {
        //        id = searchCriteria.Id;
        //    }
        //    /*
        //     * 2013958, 2013959, 2014277, 2014278
        //     */
        //    //var eventLog = LogService.GetIntegrationMessage(searchCriteria);
        //    foreach (var item in eventLog)
        //    {
        //        IntegrationMessageModel messageLog = new IntegrationMessageModel();
        //        Mapper.Map(item, messageLog);
        //        messageLogList.Add(messageLog);
        //    }
        //    return Json(new
        //    {
        //        PartialView = ConvertViewToString("_IntegrationMessageResult", messageLogList)
        //    });
        //}

        private string ConvertViewToString(string viewName, object model)
        {
            ViewData.Model = model;
            using (StringWriter writer = new StringWriter())
            {
                ViewEngineResult vResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                ViewContext vContext = new ViewContext(this.ControllerContext, vResult.View, ViewData, new TempDataDictionary(), writer);
                vResult.View.Render(vContext, writer);
                return writer.ToString();
            }
        }

        public int ReProcess(Guid processId, string reprocessReason)
        {
            string uId = Session["BaldoUserId"].ToString();
            int res = ProcessService.ReProcess(processId);
            EventLogEntity eventloginfo = new EventLogEntity();
            eventloginfo.RequestId = processId;
            eventloginfo.Message = "ProcessId: " + processId + "UserId: " + uId + "Reason: " + reprocessReason;
            eventloginfo.Severity = 8;
            eventloginfo.UserId = uId;
            eventloginfo.MachineName = Environment.MachineName;
            eventloginfo.Timestamp = DateTime.UtcNow;
            LogService.SaveEventLog(eventloginfo);
            return res;
        }

        //---------------- START ------ INTEGRATION MESSAGES ------- 27-Feb-2018 -------------------
        public ActionResult IntegrationMessages()
        {
            //Bind View Model to Integration Message View and Populate Dropdowns.
            var IntegrationMessageSearchModel = new IntegrationMessageSearchModel();
            var GetIntegrationMessageTypeEnumList = LogService.GetIntegrationMessageTypeEnumList();
            IntegrationMessageSearchModel.MessageTypeEnumList = LogService.GetIntegrationMessageTypeEnumList().Select(n => new SelectListItem { Value = n.Value.ToString(), Text = n.Name }).ToList();
            IntegrationMessageSearchModel.StatusEnumList = LogService.GetIntegrationMessageStatusEnumList().Select(n => new SelectListItem { Value = n.Value.ToString(), Text = n.Name }).ToList();
            IntegrationMessageSearchModel.SystemEnumList = LogService.GetSystemEnumList().Select(n => new SelectListItem { Value = n.Value.ToString(), Text = n.Name }).ToList();
            var select = new SelectListItem() { Value = null, Text = "----- select -----" };
            IntegrationMessageSearchModel.MessageTypeEnumList.Insert(0, select);
            IntegrationMessageSearchModel.StatusEnumList.Insert(0, select);
            IntegrationMessageSearchModel.SystemEnumList.Insert(0, select);
            ViewBag.Controller = "Technical Dashboard";
            ViewBag.Action = "Integration Message";
            return View("IntegrationMessages", IntegrationMessageSearchModel);
        }

        //[HttpGet]
        [OutputCache(NoStore = true, Duration = 0)]
        public ActionResult GetIntegrationMessage([DataSourceRequest]DataSourceRequest dataSourceRequest, IntegrationMessageSearch searchCriteria)
        {
            //Fetch Data from DB "Integration Messages and return Json result to ajax method for Binding to Grid" 
            var page = dataSourceRequest.Page <= 0 ? 1 : dataSourceRequest.Page;
            var pageSize = dataSourceRequest.PageSize <= 0 ? 10 : dataSourceRequest.PageSize;
            var skip = (page - 1) * pageSize;
            var take = pageSize;
            var intergrationMessage = LogService.GetIntegrationMessage(searchCriteria);
            DataSourceResult result = intergrationMessage.integrationMessagelist.ToDataSourceResult(dataSourceRequest, p => new IntegrationMessage
            {
                IntegrationMessageId = p.IntegrationMessageId,
                Status = p.Status,
                MessageType = p.MessageType,
                System = p.System,
                Message = p.Message,
                TimeStamp = p.TimeStamp
            });
            result.Data = intergrationMessage.integrationMessagelist;
            result.Total = intergrationMessage.Total;
            var jsonResult = Json(result, JsonRequestBehavior.AllowGet);
            //jsonResult = JsonUtc(result);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
        public PartialViewResult GetIntegrationMessageDetail(int IntegrationMessageId)
        {
            var integrationMessageDetail = LogService.GetIntegrationMessageDetail(IntegrationMessageId);
            IntegrationMessageModel model = new IntegrationMessageModel();
            model.Id = integrationMessageDetail.IntegrationMessageId;
            model.Status = integrationMessageDetail.Status;
            model.System = integrationMessageDetail.System;
            model.Message = integrationMessageDetail.Message;
            model.MessageType = integrationMessageDetail.MessageType;
            model.TimeStamp = integrationMessageDetail.TimeStamp;
            return PartialView("_IntegrationMessage", model);
        }
        //--------------- Start ----------- PROCESS INSTANCE -------------- 02-Feb-2017 --------------------------------
        [OutputCache(NoStore = true, Duration = 0)]
        public ActionResult Index()
        {
            ProcessInstanceSearchModel processSearchModel = new ProcessInstanceSearchModel();
            processSearchModel.InterfaceNameList = ProcessService.GetProcessDefinitionList().Select(n => new SelectListItem { Value = n.InterfaceName.ToString(), Text = n.Name }).ToList();
            processSearchModel.StatusList = ProcessService.GetProcessRunStatusEnumList().Select(n => new SelectListItem { Value = n.Value.ToString(), Text = n.Name }).ToList();
            var select = new SelectListItem() { Value = null, Text = "----- select -----" };
            processSearchModel.InterfaceNameList.Insert(0, select);
            processSearchModel.StatusList.Insert(0, select);
            ViewBag.Controller = "Technical DashBoard";
            ViewBag.Action = "Process Search";
            return View("Index", processSearchModel);
        }
        [OutputCache(NoStore = true, Duration = 0)]
        public JsonResult GetProcessInstances([DataSourceRequest]DataSourceRequest dataSourceRequest, ProcessInstanceSearch searchCriteria)
        {
            var page = dataSourceRequest.Page <= 0 ? 1 : dataSourceRequest.Page;
            var pageSize = dataSourceRequest.PageSize <= 0 ? 10 : dataSourceRequest.PageSize;
            var skip = (page - 1) * pageSize;
            var take = pageSize;
            searchCriteria.Skip = skip;
            searchCriteria.Take = take;
            var processInstances = ProcessService.GetProcessInstances(searchCriteria);
            DataSourceResult result = processInstances.ProcessInstanceList.ToDataSourceResult(dataSourceRequest, p => new ProcessInstance
            {
                ProcessId = p.ProcessId,
                State = p.State,
                Status = p.Status,
                InterfaceName = p.InterfaceName,
                FIFOTag = p.FIFOTag,
                CreatedAt = p.CreatedAt,
                UpdatedAt = p.UpdatedAt,
                FIFOTag2 = p.FIFOTag2
            });

            result.Data = processInstances.ProcessInstanceList;
            result.Total = processInstances.Total;
            var jsonResult = Json(result, JsonRequestBehavior.AllowGet);
            //jsonResult = JsonUtc(result);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }



        //--------------- Start ----------- LOG EVENTS -------------- 02-Feb-2017 ----------------------------
        public ActionResult EventLog()
        {
            EventLogSearchModel eventLog = new EventLogSearchModel();
            eventLog.SeverityList = LogService.GetSeverityTypeEnumList().Select(n => new SelectListItem { Value = n.Value.ToString(), Text = n.Name }).ToList();
            eventLog.BusinessTypeIdList = LogService.GetBusinessIdTypeEnumList().Select(n => new SelectListItem { Value = n.Value.ToString(), Text = n.Name }).ToList();
            var select = new SelectListItem() { Value = null, Text = "----- select -----" };
            eventLog.SeverityList.Insert(0, select);
            eventLog.BusinessTypeIdList.Insert(0, select);
            ViewBag.Id = TempData.Peek("Id");
            eventLog.Message = ViewBag.Id;
            ViewBag.Controller = "Technical DashBoard";
            ViewBag.Action = "Event Log";
            return View("LogIndex", eventLog);
        }
        public JsonResult GetEventLogs([DataSourceRequest]DataSourceRequest dataSourceRequest, EventLogSearch searchCriteria)
        {
            var page = dataSourceRequest.Page <= 0 ? 1 : dataSourceRequest.Page;
            var pageSize = dataSourceRequest.PageSize <= 0 ? 10 : dataSourceRequest.PageSize;
            var skip = (page - 1) * pageSize;
            var take = pageSize;
            searchCriteria.Skip = skip;
            searchCriteria.Take = take;
            if (TempData.Peek("Id") != null)
            {
                string Id = Convert.ToString(TempData.Peek("Id"));
                var ProcessId = new Guid(Id);
                var processDetail = ProcessService.GetProcessDetail(ProcessId);
                searchCriteria.Message = processDetail.ProcessId.ToString();
                searchCriteria.StartDate = processDetail.CreatedAt;
                searchCriteria.EndDate = processDetail.CreatedAt.AddMinutes(30);
            }
            TempData = null;
            var eventLogs = LogService.GetEventLogs(searchCriteria);
            DataSourceResult result = eventLogs.EventLogList.ToDataSourceResult(dataSourceRequest, p => new EventLog
            {
                EventLogId = p.EventLogId,
                Severity = p.Severity,
                Message = p.Message,
                RequestId = p.RequestId,
                BusinessId = p.BusinessId,
                BusinessIdType = p.BusinessIdType,
                MachineName = p.MachineName,
                UserId = p.UserId,
                Timestamp = p.Timestamp,
                IntegrationMessageId = p.IntegrationMessageId
            });
            result.Data = eventLogs.EventLogList;
            result.Total = eventLogs.Total;
            var jsonResult = Json(result, JsonRequestBehavior.AllowGet);
            //jsonResult = JsonUtc(result);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        public PartialViewResult GetEventLogDetail(int EventLogId)
        {
            var eventLogDetail = LogService.GetEventLogDetail(EventLogId);
            EventLogModel model = new EventLogModel();
            model.Id = eventLogDetail.EventLogId;
            model.Severity = eventLogDetail.Severity;
            model.RequestId = eventLogDetail.RequestId;
            model.BusinessId = eventLogDetail.BusinessId;
            model.BusinessIdType = eventLogDetail.BusinessIdType;
            model.MachineName = eventLogDetail.MachineName;
            model.UserId = eventLogDetail.UserId;
            model.IntegrationMessageId = (eventLogDetail.IntegrationMessageId == 0 ? (int?)null : eventLogDetail.IntegrationMessageId);
            model.Timestamp = eventLogDetail.Timestamp;
            model.Message = eventLogDetail.Message;
            return PartialView("_EventLog", model);
        }
    }
}