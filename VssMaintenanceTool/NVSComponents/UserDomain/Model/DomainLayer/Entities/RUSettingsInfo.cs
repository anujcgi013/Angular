using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volvo.NVS.Persistence.NHibernate.Entities;

namespace Volvo.VSSMaintenance.UserDomain.DomainLayer.Entities
{
    public class RUSettingsInfo: GenericEntity
    {
        public virtual Guid RUSettingsId { get; set; }
        public virtual Guid OrganisationId { get; set; }
        public virtual int ActivateQuotedFlow { get; set; }
        public virtual float VATFactorPercentage { get; set; }
        public virtual String QuotePrefix { get; set; }
        public virtual String QuoteSuffix { get; set; }
        public virtual int CalculationModel { get; set; }
        public virtual int CalculationModelTradeInFlag { get; set; }
        public virtual int GDSOrderFile { get; set; }
        public virtual int OMOrderFile { get; set; }
        public virtual Guid? AdministratorId { get; set; }
        public virtual int OrderFileTypeId { get; set; }
        public virtual string OrderFileType { get; set; }
        public virtual int DefaultBuyerTypeId { get; set; }
        public virtual string DefaultBuyerType { get; set; }
        public virtual int ObjVersion { get; set; }
        public virtual int UseRUSignerInDoc { get; set; }
        public virtual int UseTitleInDoc { get; set; }
        public virtual float ExtraSalePercentage { get; set; }
        public virtual int PrivateDealer { get; set; }
        public virtual string DefaultLanguage { get; set; }
        public virtual int IMAccess { get; set; }
        public virtual int CMAccess { get; set; }
        public virtual int WISPerfAccess { get; set; }
        public virtual int FCAccess { get; set; }
        public virtual int CQOnlineAccess { get; set; }
        public virtual int SAMAccess { get; set; }
        public virtual float VATFactorTradeIn { get; set; }
        public virtual int UTSAccess { get; set; }
        public virtual int ManualTradeIn { get; set; }
        public virtual string AvailableVehicleContactName { get; set; }
        public virtual string AvailableVehicleContactEMail { get; set; }
        public virtual string AvailableVehicleContactPhone { get; set; }
        public virtual int CoPilotAccess { get; set; }
        public virtual int ShowLocalCostWithoutSalesPrice { get; set; }
        public virtual int UseRUinDocument { get; set; }
        public virtual int IncludeHeader { get; set; }
        public virtual int IncludeFooter { get; set; }
        public virtual int ShowVersion { get; set; }
        public virtual int ShowAlternative { get; set; }
        public virtual int Active { get; set; }
        public virtual int VatIncludedByDefault { get; set; }
        public virtual int IncludeOverAllowanceToSalesPrice { get; set; }
        public virtual int TruckFinderAccess { get; set; }
        public virtual int IncludeCustomerSigner { get; set; }
        public virtual int SplitOrderToGDS { get; set; }
        public virtual int ExternalCounterNumber { get; set; }
        public virtual int ShowDecimals { get; set; }
        public virtual int FooterTypeId { get; set; }
        public virtual string FooterType { get; set; }
        public virtual int PriceCalculationTypeId { get; set; }
        public virtual string PriceCalculationType { get; set; }
        public virtual int DoNotDisplayVatTax { get; set; }
        public virtual int TAOrderFile { get; set; }
        public virtual int OPTAccess { get; set; }
        public virtual int TDIAccess { get; set; }
        public virtual int TQAccess { get; set; }
        public virtual int ShowSoftOfferPreLetter { get; set; }
        public virtual int InvoiceType { get; set; }
        public virtual int DealerRegionId { get; set; }
        public virtual int TIAAccess { get; set; }
        public virtual int ReportOutputFormat { get; set; }
        public virtual int ExcludeExtraInvoice { get; set; }
        public virtual int NTLAccess { get; set; }
        public virtual int NATWisPerf { get; set; }
        public virtual int CustomerView { get; set; }
        public virtual int SecondaryConcessionEnabled { get; set; }
        public virtual int TaxSettings { get; set; }
        public virtual int ActivateCreditControl { get; set; }
        public virtual int NoOrderSystem { get; set; }
        public virtual int IncludeTaxCalculationSettings { get; set; }
        public virtual Guid? InvoiceTo { get; set; }
        public virtual int RTFAccess { get; set; }
        public virtual int MCApprovalCustomer { get; set; }
        public virtual int IsSupportListPrice { get; set; }
        public virtual int CreditPortalAccess { get; set; }
        public virtual int ShowPriceInTechnicalSpecification { get; set; }
        public virtual int ShowWeightInTechnicalSpecification { get; set; }
        public virtual int IncludeCustomerAddress { get; set; }
        public virtual int IncludeSignature3 { get; set; }
        public virtual int IncludeSignature4 { get; set; }
        public virtual int IncludeDealerAddress { get; set; }
        public virtual int ShowSymbolInTechnicalSpecification { get; set; }
        public virtual int ShowFamilyInTechnicalSpecification { get; set; }
        public virtual int ShowStdOptCAIndicatorInTechnicalSpecification { get; set; }
        public virtual string Signature3 { get; set; }
        public virtual string Signature4 { get; set; }
        public virtual int OmitPagebreaks { get; set; }
        public virtual int CalculationScreenLayoutId { get; set; }
        public virtual string CalculationScreenLayout { get; set; }
        public virtual int IncludeDateForQuote { get; set; }
        public virtual int IncludeDateForOrder { get; set; }
        public virtual int VECTOAccess { get; set; }
        public virtual int CMRussiaAccess { get; set; }
    }
}
