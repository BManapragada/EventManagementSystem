using EventManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;

namespace EventManagementSystem.Controllers
{
    public class AdminController : Controller
    {
        public EventContextModel eventDbContext = new EventContextModel();

        /// <summary>
        /// Basic Login form
        /// </summary>
        /// <returns></returns>
        public ActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// To validate the details eneterd by admin
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Admin(IFormCollection form)
        {
            string? username = form["Username"];
            string? password = form["Password"];

            // Simulate authentication logic - replace this with your actual authentication mechanism
            if (username == "admin" && password == "12345") // Replace with actual authentication
            {
                var events = eventDbContext.Events.ToList();
                return View(events);
            }
            else
            {
                // Invalid credentials
                ViewBag.ErrorMessage = "Invalid username or password.";
                return RedirectToAction("Login");
            }
                
        }
        
        /// <summary>
        /// To populate eventdetails of the selected event
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetEventDetails(int id)
        {
            var eventItem = eventDbContext.Events.Find(id);
            if (eventItem == null)
            {
                return NotFound();
            }

            return PartialView("_EventDetails", eventItem); // Load details into a partial view
        }

        /// <summary>
        /// To update the event details in the database
        /// </summary>
        /// <param name="eventItem"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateEvent(Event eventItem)
        {
            if (ModelState.IsValid)
            {
                
                eventDbContext.Entry(eventItem).State = EntityState.Modified;
                eventDbContext.SaveChanges();
                return Json(new { success = true });
            }

            return Json(new { success = false, message = "Invalid data" });
        }

        /// <summary>
        /// To create a new event in the database
        /// </summary>
        /// <param name="event"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateEvent([Bind("EventId,Title,Date,Location,Description")] Event @event)
        {
            if (ModelState.IsValid)
            {
                eventDbContext.Events.Add(@event);
                eventDbContext.SaveChanges();
                return Json(new { success = true });
                
            }
            return View(@event); // If validation fails, return to form
        }
       

        /// <summary>
        /// To delete an existing event from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult DeleteEvent(int id)
        {
            var evnt = eventDbContext.Events.Find(id);
            if (evnt == null)
            {
                return NotFound();
            }
            eventDbContext.Events.Remove(evnt);
            eventDbContext.SaveChanges();
            return Json(new { success = true });
        }

        /// <summary>
        /// To view registered users for a selected event
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns></returns>
        public ActionResult ViewRegistrations(int eventId)
        {
            // Fetch registrations for the selected event using eventId
            var registrations = eventDbContext.Registrations.Where(r => r.EventID == eventId).ToList();

            // Pass the registrations to the view
            return View(registrations);
        }
    }
    
}
