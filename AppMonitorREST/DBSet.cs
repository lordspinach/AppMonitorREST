using AppMonitorREST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppMonitorREST
{
    public static class DBSet
    {
        public static void Initialize(ApplicationContext context)
        {
            if (!context.Processes.Any())
            {
                context.Processes.AddRange(
                    new Process
                    {
                        WindowTitle = "INIT tbl",
                        ProcessName = "INIT tbl",
                        LaunchTime = DateTime.Now
                    });
                context.SaveChanges();
            }
        }
    }
}
