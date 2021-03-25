using System;
using System.ComponentModel.DataAnnotations;


namespace AppMonitorREST.Models
{
    public class Process
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Это обязательное поле")]
        public string WindowTitle { get; set; }
        [Required(ErrorMessage = "Это обязательное поле")]
        public string ProcessName { get; set; }
        [Required(ErrorMessage = "Это обязательное поле")]
        public DateTime LaunchTime { get; set; }

        public int ClientId { get; set; }
        public ClientData Client { get; set; }
    }
}
