using EventManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementSystem.Controllers
{
    public class EventController : Controller
    {
        private EventContextModel eventDbContext = new EventContextModel();
        /// <summary>
        /// Home page with List of events
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var events = eventDbContext.Events.ToList();
            return View(events);
        }
        /// <summary>
        /// Details page for the selectedevent
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Page for registering for a selected event
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns></returns>
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
