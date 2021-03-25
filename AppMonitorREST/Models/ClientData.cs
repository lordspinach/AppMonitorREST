using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppMonitorREST.Models
{
    public class ClientData
    {
        [Key]
        public int Id { get; set; }
        public string PCName { get; set; }
        public List<Process> Processes { get; set; }

        public ClientData()
        {
            Processes = new List<Process>();
        }
    }
}
