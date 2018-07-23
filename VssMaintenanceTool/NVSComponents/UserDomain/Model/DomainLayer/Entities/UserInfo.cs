using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volvo.NVS.Persistence.NHibernate.Entities;

namespace Volvo.VSSMaintenance.UserDomain.DomainLayer.Entities
{
    public class UserInfo : GenericEntity
    {
        public virtual Guid UserId { get; set; }
        public virtual string BaldoUserId { get; set; }
        public virtual string Title { get; set; }
        public virtual string Salutation { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string SurName { get; set; }
        public virtual int EventCounterType { get; set; }
        public virtual int EventCounterNumber { get; set; }
        public virtual string QuotePrefix { get; set; }
        public virtual string QuoteSuffix { get; set; }
        public virtual int NumberOfRowsInList { get; set; }
        public virtual int ShowNetPriceAndGrossProfit { get; set; }
        public virtual int FirstDayOfWeek { get; set; }
        public virtual int ShowWeekNumber { get; set; }
        public virtual int UseSignatureImage { get; set; }
        public virtual string DefaultCurrency { get; set; }
        public virtual Guid Signature { get; set; }
        public virtual int DisplayHomePage { get; set; }
        public virtual string DefaultUILanguage { get; set; }
        public virtual int ObjVersion { get; set; }
        public virtual string DefaultDataLanguage { get; set; }
        public virtual string CultureCode { get; set; }
        public virtual Guid DefaultRU { get; set; }
        public virtual int IsDeleted { get; set; }
        public virtual int ShowListPrice { get; set; }
        public virtual int OpenNextMFamily { get; set; }
        public virtual int ShowVariant { get; set; }
        public virtual int ShowSymbol { get; set; }
        public virtual int Visibility { get; set; }
        public virtual int IncludeOutsideInSearch { get; set; }
        public virtual int PreviousSearchSetting { get; set; }
        public virtual int ViewLatestDeals { get; set; }
        public virtual int ViewQuotations { get; set; }
        public virtual int ViewOrders { get; set; }
        public virtual int Make { get; set; }
        public virtual int BrandingType { get; set; }
        public virtual int BrandingAccess { get; set; }
        public virtual int CustomerNameTypeId { get; set; }
        public virtual string CustomerNameType { get; set; }
        public virtual int CollapseFamily { get; set; }
        public virtual int PaperSize { get; set; }
        public virtual int Weight { get; set; }
        public virtual int NoOfRowsInCalculation { get; set; }
        public virtual int NoOfQuotationOrderRowsList { get; set; }
        public virtual int NoOfQuotationInformationRowList { get; set; }
        public virtual int NoOfOrderInformationRowList { get; set; }
        public virtual DateTime DisclaimerTextViewedAt { get; set; }
        public virtual byte[] SignatureImage { get; set; }
    }
}
