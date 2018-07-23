using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class UserProfileSearch
    {
        public Guid? UserProfileId { get; set; }
        public int? ProfileId { get; set; }
        public string Profile{ get; set; }
        public Guid? UserId { get; set; }
        public string BaldoUserId { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
    }
}
