using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Product.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthCheckController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var name = Dns.GetHostName();
            var ip = Dns.GetHostEntry(name).AddressList
                .FirstOrDefault(x => x.AddressFamily == AddressFamily.InterNetwork);

            return new string[] { "Product Microservice is running", "API Version 1.0.0", "Container ID: " + name + " and " + "IP Address: " + ip.ToString() };
        }

        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
