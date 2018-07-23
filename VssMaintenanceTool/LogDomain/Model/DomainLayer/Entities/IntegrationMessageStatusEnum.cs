﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volvo.NVS.Persistence.NHibernate.Entities;

namespace Volvo.VSS.LogDomain.DomainLayer.Entities
{
   public  class IntegrationMessageStatusEnum: GenericEntity
    {
        public virtual int Value { get; set; }
        public virtual string Name { get; set; }
    }
}
