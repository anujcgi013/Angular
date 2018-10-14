using AutoMapper;
using DatatDomainEntities = Volvo.VSSMaintenance.UserDomain.DomainLayer.Entities;

namespace Volvo.MaintenanceTool.UserInterface.Models.Translators
{
    public class DataDomainMvcProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DataDomainMvcProfile"; }
        }

        protected override void Configure()
        { 
            Mapper.CreateMap<DatatDomainEntities.Market, MarketModel>();
            Mapper.CreateMap<DatatDomainEntities.Calendar, CalendarModel>();
        }
    }
}