using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using Volvo.VSSMaintenance.UserDomain.DomainLayer.Entities;

namespace Volvo.MaintenanceTool.UserInterface.Models
{
    public class GDPRSearchModel
    {
        public virtual string SearchString { get; set; }
    }
}