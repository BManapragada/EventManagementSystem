using System.ComponentModel.DataAnnotations;

namespace EventManagementSystem.Models
{
    public class Registration
    {
        public int RegistrationID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        
        public string Phone { get; set; }
        public int EventID { get; set; }

        public  virtual Event? Event { get; set; }
    }
}
