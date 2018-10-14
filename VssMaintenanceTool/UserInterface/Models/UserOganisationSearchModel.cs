using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Volvo.MaintenanceTool.UserInterface.Models
{
    public class UserOrganisationSearchModel
    {
        public string BaldoUserId { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public Guid? UserId { get; set; }
        public Guid? OrganisationId { get; set; }
        public Guid? RUSettingsId { get; set; }
        public string CDBPartyId { get; set; }
        public string LegalName { get; set; }
        public string CommonName { get; set; }
    }
}