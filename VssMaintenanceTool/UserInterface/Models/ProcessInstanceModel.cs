using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Volvo.MaintenanceTool.UserInterface.Models
{
    public class ProcessInstanceModel
    {
        public Guid Id { get; set; }
        public short State { get; set; }
        public string Status { get; set; }
        public string InterfaceName { get; set; }
        public string FIFOTag { get; set; }

        private DateTime createdAt;
        [DisplayName("Created At")]
        public DateTime CreatedAt
        {
            get { return this.createdAt; }
            set
            {
                this.createdAt = new DateTime(value.Ticks, DateTimeKind.Utc);
            }
        }

        private DateTime updatedAt;
        [DisplayName("Updated At")]
        public DateTime UpdatedAt
        {
            get { return this.updatedAt; }
            set
            {
                this.updatedAt = new DateTime(value.Ticks, DateTimeKind.Utc);
            }
        }
        public string FIFOTag2 { get; set; }
    }
}
