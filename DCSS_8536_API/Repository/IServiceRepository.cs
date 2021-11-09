using DCSS_8536_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DCSS_8536_API.Repository
{
    public interface IServiceRepository
    {
        void InsertService(Service service);
        void UpdateService(Service service);
        void DeleteService(int serviceID);
        Service GetServiceById(int id);
        IEnumerable<Service> GetServices();
    }
}
