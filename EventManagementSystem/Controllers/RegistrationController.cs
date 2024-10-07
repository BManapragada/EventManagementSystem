using EventManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;

namespace EventManagementSystem.Controllers
{
    public class RegistrationController : Controller
    {
        public EventContextModel eventDbContext = new EventContextModel();

        /// <summary>
        /// To register the user for the selected event
        /// </summary>
        /// <param name="registration"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Registration registration)
        {
            if (ModelState.IsValid)
            {
                //eventDbContext.Registrations.Add(registration);
                eventDbContext.Entry(registration).State = EntityState.Added;
                eventDbContext.SaveChanges();
                return RedirectToAction("Index", "Event");
            }
            return View(registration);
            
        }
    }
}
