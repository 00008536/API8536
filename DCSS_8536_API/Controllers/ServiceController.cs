using DCSS_8536_API.Models;
using DCSS_8536_API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace DCSS_8536_API.Controllers
{
    [Produces("application/json")]
    [Route("api/Service")]
    public class ServiceController : Controller
    {
        private readonly IServiceRepository _serviceRepository;
        public ServiceController(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }
        // GET: api/Service
        [HttpGet]
        public IActionResult Get()
        {
            var services = _serviceRepository.GetServices();
            return new OkObjectResult(services);
        }
        // GET: api/Service/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var service = _serviceRepository.GetServiceById(id);
            return new OkObjectResult(service);
        }
        // POST: api/Service
        [HttpPost]
        public IActionResult Post([FromBody]Service service)
        {
            using (var scope = new TransactionScope())
            {
                _serviceRepository.InsertService(service);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = service.ID }, service);
            }
        }
        // PUT: api/Service/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Service service)
        {
            if (service != null)
            {
                using (var scope = new TransactionScope())
                {
                    _serviceRepository.UpdateService(service);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _serviceRepository.DeleteService(id);
            return new OkResult();
        }
    }
}
