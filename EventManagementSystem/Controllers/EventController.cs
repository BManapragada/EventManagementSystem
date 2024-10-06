using EventManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementSystem.Controllers
{
    public class EventController : Controller
    {
        private EventContextModel eventDbContext = new EventContextModel();

        public ActionResult Index()
        {
            var events = eventDbContext.Events.ToList();
            return View(events);
        }
        public ActionResult EventDetails(int eventId)
        {
            //eventId = 1;
            var curEvent = eventDbContext.Events.Find(eventId);

            if (curEvent == null)
            {
                return NotFound();
            }
            return View(curEvent);
        }
        public ActionResult Registration(int eventId)
        {
            var curEvent = eventDbContext.Events.Find(eventId);

            if (curEvent == null)
            {
                return NotFound();
            }
            return View(new Registration { EventID = curEvent.EventId });
        }
    }
}
