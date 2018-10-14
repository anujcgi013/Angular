using Volvo.NVS.Core.Unity;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Volvo.VSS.LogDomain.ServiceLayer;
using Volvo.VSS.ProcessDomain.ServiceLayer;
using Volvo.MaintenanceTool.UserInterface.Models;
using Volvo.VSS.LogDomain.DomainLayer.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Data;
using System.Data.OleDb;
using System.Web;
using System.Linq;
using Volvo.VSSMaintenance.UserDomain.ServiceLayer;
using Volvo.VSSMaintenance.UserDomain.DomainLayer.Entities;
using Common;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using Volvo.MaintenanceTool.UserInterface.Auth;
using System.Web.Configuration;

namespace Volvo.MaintenanceTool.UserInterface.Controllers
{
    [CustomBaseAuth]
    public class AdministrationController : BaseController
    {

        protected ILogService LogService { get; set; }
        protected IProcessService ProcessService { get; set; }
        protected IMarketService MarketService { get; set; }


        public AdministrationController(ILogService logService, IMarketService marketService) : base()
        {
            LogService = logService;
            MarketService = marketService;
        }

        public AdministrationController()

        {
            //hibernate - configuration
            LogService = Container.Resolve<ILogService>(new ResolverOverride[]
                                   {
                                       new ParameterOverride("name", "hibernate-configuration-log")
                                   });

            MarketService = Container.Resolve<IMarketService>(new ResolverOverride[]
                                  {
                                       new ParameterOverride("name", "hibernate-configuration-data")
                                   });          

        }





        #region: Message Board
        // GET: Administration
        [OutputCache(NoStore = true, Duration = 0)]
        public ActionResult MessageBoard()
        {
            ViewBag.Controller = "Admin Tools";
            ViewBag.Action = "Message Board";
            return View();
        }

        
        public void MessageBoard_saveMessage(MaintenanceInformation model)
        {
            LogService.SaveMaintenanceMsg(model);
            var searchModel = new MaintenanceInformationSearchModel();
        }

        public ActionResult MessageBoard_updateMessage(MaintenanceInformation model)
        {
            LogService.UpdateMaintenanceMsg(model);
            return RedirectToAction("MessageBoard");
        }

        public ActionResult MessageBoard_displayMessage(int MaintenanceInformationId)
        {
            MaintenanceInformationModel model = new MaintenanceInformationModel();
            var result = LogService.GetMaintenanceInformationDetail(MaintenanceInformationId);
            model.Id = Convert.ToInt32(result.Id);
            model.ValidFrom = result.ValidFrom;
            model.ValidTo = result.ValidTo;
            model.Header = result.Header;
            model.Message = result.Message;
            model.Created = result.Created;
            model.CreatedBy = result.CreatedBy;
            return PartialView("_MessageBoard", model);
        }


        public JsonResult MessageBoard_getAllMessage([DataSourceRequest]DataSourceRequest dataSourceRequest, MaintenanceInformationSearch searchCriteria)
        {
            var page = dataSourceRequest.Page <= 0 ? 1 : dataSourceRequest.Page;
            var pageSize = dataSourceRequest.PageSize <= 0 ? 10 : dataSourceRequest.PageSize;
            var skip = (page - 1) * pageSize;
            var take = pageSize;
            searchCriteria.Skip = skip;
            searchCriteria.Take = take;
            var maintenanceInformation = LogService.GetMaintenanceInformation(searchCriteria);
            DataSourceResult result = maintenanceInformation.MaintenanceInformationlist.ToDataSourceResult(dataSourceRequest, p => new MaintenanceInformationModel
            {
                Id = (int)p.Id,
                Header = p.Header,
                Message = p.Message,
                ValidFrom = p.ValidFrom,
                ValidTo = p.ValidTo,
                CreatedBy = p.CreatedBy,
                Created = p.Created
            });
            result.Data = maintenanceInformation.MaintenanceInformationlist;
            result.Total = maintenanceInformation.Total;
            var jsonResult = Json(result, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;

            //IList<MaintenanceInformationModel> messageList = new List<MaintenanceInformationModel>();
            //var tempMsgList = LogService.GetMaintenanceInformation(model.ValidFrom, model.ValidTo);

            //foreach (var item in tempMsgList)
            //{
            //    MaintenanceInformationModel message = new MaintenanceInformationModel();
            //    message.ValidTo = Convert.ToString(item.ValidTo);
            //    message.ValidFrom = Convert.ToString(item.ValidFrom);
            //    message.Created = item.Created.ToString();
            //    message.CreatedBy = item.CreatedBy;
            //    message.Header = item.Header;
            //    message.Message = item.Message;
            //   // Mapper.Map(item, message);
            //    messageList.Add(message);
            //}
            //var JsonResult = Json(messageList, JsonRequestBehavior.AllowGet);
            //return JsonResult;
        }

        #endregion



        #region: Calender Upload

        public ActionResult CalendarUpload()
        {
            ViewBag.Controller = "Admin Tools";
            ViewBag.Action = "Calender Upload";
            return View();

        }

        public JsonResult Calendar_GetAllMarkets()
        {

            IList<MarketModel> marketList = new List<MarketModel>();
            var tempmarketList = MarketService.GetMarketIdAndDescription();

            foreach (var item in tempmarketList)
            {
                MarketModel Market = new MarketModel();
                Market.Description = item.Description;
                Market.MarketId = Convert.ToString(item.Id);
                // Mapper.Map(item, message);
                marketList.Add(Market);
            }



            return Json(marketList, JsonRequestBehavior.AllowGet);
        }




        [HttpPost]
        public ActionResult Calendar_uploadCalendar(HttpPostedFileBase file, string selectedMId)
        {
            DataSet CalenderDs;
            DataTable dt;
            string connString;
            Guid marketId;
            Guid.TryParse(selectedMId, out marketId);
            string vStr_FilePath = WebConfigurationManager.AppSettings["myExcelFilePath"];
            var supportedTypes = new[] { "xls", "xlsx" };


            string sql = "SELECT '" + marketId + "' AS [MarketId], Date,isWeekday,isHoliday,HolidayDescription,MonthName,DayName FROM [Calendar$]";

            if (file != null)
            {
                var fileExt = (System.IO.Path.GetExtension(file.FileName).Substring(1));

                if (file.ContentLength > 0 && supportedTypes.Contains(fileExt))
                {
                    var fileName = Path.GetFileName(file.FileName);
                    if (fileExt.Trim() == ".xls")
                    {
                        connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Path.Combine(vStr_FilePath, fileName) + ";Extended Properties=\"Excel 8.0;";
                    }
                    else
                    {
                        connString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = "+ Path.Combine(vStr_FilePath, fileName) + "; Extended Properties = Excel 12.0; ";
                    }


                    CalenderDs = GetDataSetForCalender(fileName, sql, connString);
                    dt = CalenderDs.Tables[0];

                    Market m = MarketService.CheckCalenderExistsForMarket(marketId);

                    getMarketModel(dt, m);
                    try
                    {
                        MarketService.SavecalenderforMarket(m);
                    }
                    catch (Exception e)
                    {

                        return Json(new { success = false, responseText = "Some error occured while insertion to the database" }, JsonRequestBehavior.AllowGet);
                    }

                    return Json(new { success = true, responseText = "Your Calendar inserted successfuly !" }, JsonRequestBehavior.AllowGet);

                }
                else
                {
                    return Json(new { success = false, responseText = "The attached file is not supported or Empty." }, JsonRequestBehavior.AllowGet);

                }

            }
            else
            {

                return Json(new { success = false, responseText = "Please Upload a File !" }, JsonRequestBehavior.AllowGet);

            }

            // return RedirectToAction("CalendarUpload");

        }

        private void getMarketModel(DataTable dt, Market m)
        {

            // Market m= new Market();
            if (m.Calendars.Count < 1)
            {
                m.Calendars = new List<Volvo.VSSMaintenance.UserDomain.DomainLayer.Entities.Calendar>();
            }
            else
            {
                var CalendarsToRemove = m.Calendars.Where(c => c.MarketId == m.Id).ToList();
                foreach (var content in CalendarsToRemove)
                {
                    m.Calendars.Remove(content);
                }

            }
            foreach (DataRow row in dt.Rows)
            {
                m.Calendars.Add(new Volvo.VSSMaintenance.UserDomain.DomainLayer.Entities.Calendar
                {
                    //Id = Guid.Parse(row[0].ToString()),
                    MarketId = Guid.Parse(row[1].ToString()),
                    Date = (DateTime)row[2],
                    isWeekday = (bool)row[3],
                    isHoliday = (bool)row[4],
                    HolidayDescription = row[5].ToString(),
                    MonthName = row[6].ToString(),
                    DayName = row[7].ToString()

                });
            }
            //m.cal.Add(calList);

            // return m;
        }


        private DataSet GetDataSetForCalender(string fileName, string Query, string excelConnectionString)
        {
            DataSet ds = new DataSet();
            OleDbCommand excelCommand = null;
            OleDbDataAdapter excelDataAdapter = null;

            OleDbConnection excelConn = new OleDbConnection(excelConnectionString);


            try
            {
                if (excelConn.State == ConnectionState.Closed)
                    excelConn.Open();

                excelCommand = new OleDbCommand(Query, excelConn);
                excelDataAdapter = new OleDbDataAdapter(excelCommand);
                DataTable TableData = new DataTable();

                //Create a Command using Query
                excelCommand = new OleDbCommand(Query, excelConn);

                excelDataAdapter.SelectCommand = excelCommand;
                excelDataAdapter.Fill(TableData);
                TableData.TableName = "Calendar";

                DataTable GetCalendarTable = GetDataTable(TableData);
                ds.Tables.Add(GetCalendarTable);
            }
            catch (Exception e)
            {
                excelConn.Close();
            }
            finally
            {
                if (excelDataAdapter != null) { excelDataAdapter.Dispose(); }
                if (excelCommand != null) { excelCommand.Dispose(); }
            }

            return ds;
        }


        /// <summary>
        /// Get DataTable
        /// </summary>
        /// <param name="SourceTable"></param>
        /// <returns></returns>
        private DataTable GetDataTable(DataTable SourceTable)
        {
            DataTable TargetTable = new DataTable();
            DataColumn DC = null;
            DataRow DR = null;
            string[] ColumnNames = new string[] { "id", "MarketId", "Date", "isWeekday", "isHoliday", "HolidayDescription", "MonthName", "DayName" };
            string[] ColumnTypes = new string[] { "System.Guid", "System.Guid", "System.DateTime", "System.Boolean", "System.Boolean", "System.String", "System.String", "System.String" };

            for (int column = 0; column <= 7; column++)
            {
                DC = new DataColumn();
                DC.ColumnName = ColumnNames[column];
                DC.DataType = System.Type.GetType(ColumnTypes[column]);
                TargetTable.Columns.Add(DC);
            }

            foreach (DataRow SourceRow in SourceTable.Rows)
            {
                DR = TargetTable.NewRow();
                DR[TargetTable.Columns[0]] = Guid.NewGuid();
                DR[TargetTable.Columns[1]] = new Guid(SourceRow[0].ToString());


                //******************Expecting All the data in Excel is in correct Data Type and Format******************
                //Null(DBNull.Value) condition checking added. If not, there is 
                //no value was there in the Excel column, it was trying to convert particular Data Type and throwing error
                if (SourceRow[1] != DBNull.Value)
                {

                    DR[TargetTable.Columns[2]] = (DateTime)SourceRow[1];
                    DR[TargetTable.Columns[3]] = Convert.ToBoolean(SourceRow[2]);
                    DR[TargetTable.Columns[4]] = Convert.ToBoolean(SourceRow[3]);
                    DR[TargetTable.Columns[5]] = Convert.ToString(SourceRow[4]);
                    DR[TargetTable.Columns[6]] = Convert.ToString(SourceRow[5]);
                    DR[TargetTable.Columns[7]] = Convert.ToString(SourceRow[6]);
                    TargetTable.Rows.Add(DR);

                }
                else
                {
                    break; // If no Value is there in Date column(Consider date column as starting column in excel), then break.
                }

            }

            return TargetTable;
        }
    }


    #endregion
}
