using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace datavizapp.Controllers
{
    [Route("api/[controller]")]
    public class AirBnbController : Controller
    {
        [HttpGet]
        public WireData Get()
        {
            var dataAccessor = AirBnbDataAccessors.GetInstance();

            return new WireData()
                {
                    DevicesToClientsCount = dataAccessor.DevicesData.DevicesToClients.Select(e => new KeyValuePair<string, int>(e.Key, e.Value.Count)).ToDictionary(p => p.Key, p => p.Value),
                    UserAgentsToClientsCount = dataAccessor.UserAgentsData.UserAgentsToClients.Select(e => new KeyValuePair<string, int>(e.Key, e.Value.Count)).ToDictionary(p => p.Key, p => p.Value),
                    UserToAverageSessionDurationInSeconds = dataAccessor.SessionsData.UsersToSessions.Select(e => new KeyValuePair<string, double>(e.Key, Math.Ceiling(e.Value.Average()))).ToDictionary(p => p.Key, p => p.Value),
                };
        }
    }
}
