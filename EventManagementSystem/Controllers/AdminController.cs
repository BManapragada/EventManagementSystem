using EventManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;

namespace EventManagementSystem.Controllers
{
    public class AdminController : Controller
    {
        public EventContextModel eventDbContext = new EventContextModel();

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Admin(IFormCollection form)
        {
            string? username = form["Username"];
            string? password = form["Password"];

            // Simulate authentication logic - replace this with your actual authentication mechanism
            if (username == "admin" && password == "password") // Replace with actual authentication
            {
                // If login is successful, redirect to admin dashboard
                //return RedirectToAction("AdminDashboard", "Admin");
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateEvent([Bind("EventId,Title,Date,Location,Description")] Event @event)
        {
            if (ModelState.IsValid)
            {
                eventDbContext.Events.Add(@event);
                eventDbContext.SaveChanges();
                return RedirectToAction("Index"); // After adding, redirect to admin event list
            }
            return View(@event); // If validation fails, return to form
        }
       

        
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
        public ActionResult ViewRegistrations(int eventId)
        {
            // Fetch registrations for the selected event using eventId
            var registrations = eventDbContext.Registrations.Where(r => r.EventID == eventId).ToList();

            // Pass the registrations to the view
            return View(registrations);
        }
    }
    
}
