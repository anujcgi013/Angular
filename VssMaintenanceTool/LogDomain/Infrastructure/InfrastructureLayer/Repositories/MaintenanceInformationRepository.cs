using Common;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using Volvo.NVS.Persistence.NHibernate.Repositories;
using Volvo.NVS.Persistence.NHibernate.SessionHandling;
using Volvo.VSS.LogDomain.DomainLayer.Common;
using Volvo.VSS.LogDomain.DomainLayer.Entities;
using Volvo.VSS.LogDomain.DomainLayer.RepositoryInterfaces;

namespace Volvo.VSS.LogDomain.InfrastructureLayer.Repositories
{
    public class MaintenanceInformationRepository : GenericRepository<MaintenanceInformation, string>, IMaintenanceInformationRepository
    {
        private MaintenanceInformationDTO maintenanceInformationDTO;
        public MaintenanceInformationRepository()
        { }
        public MaintenanceInformationRepository(string name) : base(name)
        { }
        public IList<MaintenanceInformation> GetMaintenanceInformation(DateTime startDate, DateTime enddate, string header, string message)
        {
            //string conditions = "Session.QueryOver<MaintenanceInformation>().Where(";
            //if (startDate != null) { conditions = "p => p.ValidFrom >= startDate"; }
            //if (enddate != null) { conditions += "&& p => p.ValidTo <= startDate"; }
            //if (header != null) { conditions += "&& p.Header.Contains(header)"; }
            //if (message != null) { conditions += "&& p.Message.Contains(message)"; }
            //conditions += ").List<MaintenanceInformation>().ToList();";

            return Session.QueryOver<MaintenanceInformation>().Where(p => p.ValidFrom >= startDate && p.ValidTo <= enddate || (p.Header.Contains(header) || p.Message.Contains(message))).List<MaintenanceInformation>().ToList();
        }

        public IList<MaintenanceInformation> GetMaintenanceInformation(DateTime? startDate, DateTime? enddate)
        {
            using (new NHibernateSessionContext(SessionName))
            {
                return Session.QueryOver<MaintenanceInformation>().Where(p => p.ValidFrom >= startDate && p.ValidTo <= enddate).List<MaintenanceInformation>().ToList();
            }
        }
        public IList<MaintenanceInformation> GetMaintenanceInformation(string header, string message)
        {
            using (new NHibernateSessionContext(SessionName))
            {
                return Session.QueryOver<MaintenanceInformation>().Where(p => p.Header.Contains(header) && p.Message.Contains(message)).List<MaintenanceInformation>().ToList();
            }
        }

        public void SaveMaintenanceMsg(MaintenanceInformation maintenanceInfo)
        {
            using (var transaction = new TransactionScope())
            {
                using (new NHibernateSessionContext(SessionName))
                {
                    Session.SaveOrUpdate(maintenanceInfo);
                }
                transaction.Complete();
            }

        }
        public void UpdateMaintenanceMsg(MaintenanceInformation maintenanceInfo)
        {
            using (var transaction = new TransactionScope())
            {
                using (new NHibernateSessionContext(SessionName))
                {
                    Session.Update(maintenanceInfo);
                }
                transaction.Complete();
            }

        }
        public MaintenanceInformationDTO GetMaintenanceInformation(MaintenanceInformationSearch searchCriteria)
        {
            using (new NHibernateSessionContext(SessionName))
            {
                var Skip = searchCriteria.Skip;
                var Take = searchCriteria.Take;
                maintenanceInformationDTO = new MaintenanceInformationDTO();
                using (new NHibernateSessionContext(SessionName))
                {
                    ICriteria query = this.Session.CreateCriteria(typeof(MaintenanceInformation)).AddOrder(Order.Desc("ValidFrom"));
                    if (!String.IsNullOrWhiteSpace(searchCriteria.Header))
                    {
                        query.Add(Restrictions.Like("Header", "%" + searchCriteria.Header + "%"));
                    }
                    if (!String.IsNullOrWhiteSpace(searchCriteria.Message))
                    {
                        query.Add(Restrictions.Like("Message", "%" + searchCriteria.Message + "%"));
                    }
                    if (searchCriteria.ValidFrom.HasValue)
                    {
                        query.Add(Restrictions.Ge("ValidFrom", (searchCriteria.ValidFrom.Value)));
                    }
                    if (searchCriteria.ValidTo.HasValue)
                    {
                        query.Add(Restrictions.Le("ValidTo", searchCriteria.ValidTo));
                    }
                    if (!String.IsNullOrWhiteSpace(searchCriteria.CreatedBy))
                    {
                        query.Add(Restrictions.Like("CreatedBy", "%" + searchCriteria.CreatedBy + "%"));
                    }
                    if (searchCriteria.Created.HasValue)
                    {
                        query.Add(Restrictions.Eq("Created", searchCriteria.Created));
                    }
                    maintenanceInformationDTO.MaintenanceInformationlist = query.SetFirstResult(Skip).SetMaxResults(Take).List<MaintenanceInformation>();
                }
                using (new NHibernateSessionContext(SessionName))
                {
                    ICriteria query = this.Session.CreateCriteria(typeof(MaintenanceInformation));
                    if (!String.IsNullOrWhiteSpace(searchCriteria.Header))
                    {
                        query.Add(Restrictions.Like("Header", "%" + searchCriteria.Header + "%"));
                    }
                    if (!String.IsNullOrWhiteSpace(searchCriteria.Message))
                    {
                        query.Add(Restrictions.Like("Message", "%" + searchCriteria.Message + "%"));
                    }
                    if (searchCriteria.ValidFrom.HasValue)
                    {
                        query.Add(Restrictions.Ge("ValidFrom", (searchCriteria.ValidFrom.Value)));
                    }
                    if (searchCriteria.ValidTo.HasValue)
                    {
                        query.Add(Restrictions.Le("ValidTo", searchCriteria.ValidTo));
                    }
                    if (!String.IsNullOrWhiteSpace(searchCriteria.CreatedBy))
                    {
                        query.Add(Restrictions.Like("CreatedBy", "%" + searchCriteria.CreatedBy + "%"));
                    }
                    if (searchCriteria.Created.HasValue)
                    {
                        query.Add(Restrictions.Eq("Created", searchCriteria.Created));
                    }
                    maintenanceInformationDTO.Total = query.SetProjection(Projections.Count(Projections.Id())).FutureValue<int>().Value;
                }
                return maintenanceInformationDTO;
            }
        }

        public MaintenanceInformation GetMaintenanceInformationDetail(int MaintenanceInformationId)
        {
            MaintenanceInformation result;
            using (new NHibernateSessionContext(SessionName))
            {
                result = Session.QueryOver<MaintenanceInformation>().Where(m => m.Id == MaintenanceInformationId).SingleOrDefault();
            }
            return result;
        }
    }
}
