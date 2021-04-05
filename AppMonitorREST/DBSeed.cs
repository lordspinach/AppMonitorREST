using AppMonitorREST.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppMonitorREST
{
    public class DBSeed
    {
        public static async Task SeedDataBaseAsync(ApplicationDbContext context, UserManager<User> userManager)
        {
            if (!userManager.Users.Any())
            {
                var users = new List<User>
                            {
                                new User
                                    {
                                        UserName = "Admin"
                                    }
                              };

                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "Admin*123");
                }
            }
            if (!context.PCs.Any())
            {
                var pc = new PcData()
                {
                    PCName = "MyPC"
                };

                context.PCs.Add(pc);
                context.Processes.Add(new Process()
                {
                    WindowTitle = "First row",
                    ProcessName = "First row",
                    LaunchTime = DateTime.Now,
                    PC = pc
                });
                context.SaveChanges();
            }
        }
    }
}
