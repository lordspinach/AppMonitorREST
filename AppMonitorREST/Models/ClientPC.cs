using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppMonitorREST.Models
{
    public class ClientPC
    {
        [Key]
        public int Id { get; set; }
        public string PCName { get; set; }
        public ICollection<Process> Processes { get; set; }
    }
}
