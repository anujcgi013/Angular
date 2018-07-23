using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volvo.NVS.Persistence.NHibernate.Entities;
using Volvo.VSSMaintenance.UserDomain.DomainLayer.Entities;

namespace Volvo.VSSMaintenance.UserDomain.InfrastructureLayer.Mappings
{
    public class UserInfoMap : ClassMapping<UserInfo>
    {
        public UserInfoMap()
        {
            Table("[VuUserDetail]");
            Schema("[dbo]");
            Lazy(true);
            Id(x => x.UserId);
            Property(x => x.BaldoUserId);
            Property(x => x.Salutation);
            Property(x => x.Title);
            Property(x => x.FirstName);
            Property(x => x.SurName);
            Property(x => x.EventCounterType);
            Property(x => x.EventCounterNumber);
            Property(x => x.QuotePrefix);
            Property(x => x.QuoteSuffix);
            Property(x => x.NumberOfRowsInList);
            Property(x => x.ShowNetPriceAndGrossProfit);
            Property(x => x.FirstDayOfWeek);
            Property(x => x.ShowWeekNumber);
            Property(x => x.UseSignatureImage);
            Property(x => x.DefaultCurrency);
            Property(x => x.Signature);
            Property(x => x.DisplayHomePage);
            Property(x => x.DefaultUILanguage);
            Property(x => x.DefaultDataLanguage);
            Property(x => x.CultureCode);
            Property(x => x.DefaultRU);
            Property(x => x.IsDeleted);
            Property(x => x.ShowListPrice);
            Property(x => x.OpenNextMFamily);
            Property(x => x.ShowVariant);
            Property(x => x.ShowSymbol);
            Property(x => x.Visibility);
            Property(x => x.IncludeOutsideInSearch);
            Property(x => x.PreviousSearchSetting);
            Property(x => x.ViewLatestDeals);
            Property(x => x.ViewQuotations);
            Property(x => x.ViewOrders);
            Property(x => x.Make);
            Property(x => x.BrandingType);
            Property(x => x.BrandingAccess);
            Property(x => x.CustomerNameTypeId);
            Property(x => x.CustomerNameType);
            Property(x => x.CollapseFamily);
            Property(x => x.PaperSize);
            Property(x => x.Weight);
            Property(x => x.NoOfRowsInCalculation);
            Property(x => x.NoOfQuotationOrderRowsList);
            Property(x => x.NoOfQuotationInformationRowList);
            Property(x => x.NoOfOrderInformationRowList);
            Property(x => x.DisclaimerTextViewedAt);
            Property(x => x.SignatureImage);
        }
    }
}
