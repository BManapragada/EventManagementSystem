using System.Data.Entity;

namespace EventManagementSystem.Models
{
    public class EventContextModel:DbContext
    {
        /// <summary>
        /// defeining database params for connecting
        /// </summary>
        public EventContextModel() : base(
            "Data Source=LAPTOP-AQMF6F59;" +
            "Initial Catalog=EventManagementSystemDb;" +
            "Integrated Security=True")
        {
            Database.SetInitializer<EventContextModel>(new CreateDatabaseIfNotExists<EventContextModel>());
        }
                
        public DbSet<Event> Events { get; set; }
        public DbSet<Registration> Registrations { get; set; }
    }
}
