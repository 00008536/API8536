using DCSS_8536_API.DBContexts;
using DCSS_8536_API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DCSS_8536_API.Repository
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly ServiceContext _dbContext;
        public ServiceRepository(ServiceContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void DeleteService(int serviceID)
        {
            var service = _dbContext.Services.Find(serviceID);
            _dbContext.Services.Remove(service);
            Save();
        }
        public Service GetServiceById(int serviceID)
        {
            var serv = _dbContext.Services.Find(serviceID);
            return serv;
        }
        public IEnumerable<Service> GetServices()
        {
            return _dbContext.Services.ToList();
        }
        public void InsertService(Service service)
        {
            _dbContext.Add(service);
            Save();
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }
        public void UpdateService(Service service)
        {
            _dbContext.Entry(service).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Save();
        }
    }
}
