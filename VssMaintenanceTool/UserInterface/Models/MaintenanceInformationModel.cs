using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;


namespace Volvo.MaintenanceTool.UserInterface.Models
{
    public class MaintenanceInformationModel
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string Message { get; set; }

        private DateTime created;
        [DisplayName("Created")]
        public DateTime Created {
            get { return this.created; }
            set
            {
                this.created = new DateTime(value.Ticks, DateTimeKind.Utc);
            }
        }
        public string CreatedBy { get; set; }

        private DateTime validFrom;
        [DisplayName("Valid From")]
        public DateTime ValidFrom
        {
            get { return this.validFrom; }
            set
            {
                this.validFrom = new DateTime(value.Ticks, DateTimeKind.Utc);
            }
        }

        private DateTime validTo;
        [DisplayName("Valid To")]
        public DateTime ValidTo
        {
            get { return this.validTo; }
            set
            {
                this.validTo = new DateTime(value.Ticks, DateTimeKind.Utc);
            }
        }
    }
}