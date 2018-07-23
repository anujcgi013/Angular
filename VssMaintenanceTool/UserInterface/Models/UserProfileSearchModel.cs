using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Volvo.MaintenanceTool.UserInterface.Models
{
    public class UserProfileSearchModel
    {
        [DisplayName("User Profile Id")]
        public Guid? UserProfileId { get; set; }

        [DisplayName("Profile Id")]
        public int? ProfileId { get; set; }

        [DisplayName("Profile")]
        public string Profile{ get; set; }

        [DisplayName("User Id")]
        public Guid? UserId { get; set; }

        [DisplayName("Baldo User Id")]
        public string BaldoUserId { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Sur Name")]
        public string SurName { get; set; }
    }
}