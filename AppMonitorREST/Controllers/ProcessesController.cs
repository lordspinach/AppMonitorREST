using AppMonitorREST.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AppMonitorREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessesController : ControllerBase
    {
        readonly private ApplicationContext db;

        public ProcessesController(ApplicationContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return db.Processes.Select(p => p.ProcessName).ToArray();
        }
        
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
