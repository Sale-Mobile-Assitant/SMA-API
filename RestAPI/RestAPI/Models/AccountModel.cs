using System.Collections.Generic;

namespace RestAPI.Models
{
    public class AccountModel
    {
        public string CompID { get; set; }
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool? Type { get; set; }
        public string EmplID { get; set; }
        public string Note { get; set; }
        
    }
}