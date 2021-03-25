using AppMonitorREST.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AppMonitorREST.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessesController : ControllerBase
    {
        readonly private ApplicationContext db;

        public ProcessesController(ApplicationContext db)
        {
            this.db = db;
        }

        /// <summary>
        /// Shows all processes in DB
        /// </summary>
        /// <returns> IEnumerable/<string/> </returns>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return db.Processes.Select(p => p.ProcessName).ToArray();
        }

        /// <summary>
        /// Add 
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /api/Processes/new
        ///     {
        ///      "pcName": "MyPC",
        ///      "processes": [
        ///         {
        ///           "WindowTitle": "GOOGLE CHROME",
        ///           "ProcessName": "chrome",
        ///           "launchTime": "2021-03-12T21:43:21"
        ///         },
        ///         {
        ///           "WindowTitle": "AppMonitorREST",
        ///           "ProcessName": "vs_studio",
        ///           "launchTime": "2021-03-12T18:12:03"
        ///         }
        ///       ]
        ///     }
        ///     
        /// </remarks>
        /// <param name="model"></param>
        /// <response code="200">Processes added succesefully</response>
        /// [ProducesResponseType(StatusCodes.Status200Created)]
        [HttpPost]
        [Route("new")]
        public void New([FromBody] ClientData model)
        {
            var pc = db.PCs.Where(p => p.PCName == model.PCName);
            if (pc.Any())
            {
                foreach (var proc in model.Processes)
                {
                    db.Processes.Add(new Process()
                    {
                        WindowTitle = proc.WindowTitle,
                        ProcessName = proc.ProcessName,
                        LaunchTime = proc.LaunchTime,
                        Client = pc.First()
                    });
                }
            }
            else
            {
                var client = new ClientData()
                {
                    PCName = model.PCName
                };

                db.PCs.Add(client);

                foreach (var proc in model.Processes)
                {
                    db.Processes.Add(new Process()
                    {
                        WindowTitle = proc.WindowTitle,
                        ProcessName = proc.ProcessName,
                        LaunchTime = proc.LaunchTime,
                        Client = client
                    });
                }
            }
            db.SaveChanges();
        }
    }
}
