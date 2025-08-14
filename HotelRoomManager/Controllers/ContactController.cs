using HotelRoomManager.Contracts;
using HotelRoomManager.Models.ViewModels.ContactViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelRoomManager.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService contact;
        public ContactController(IContactService _contact)
        {
            contact = _contact;
        }



        [HttpGet]
        [AllowAnonymous]
        public IActionResult Create() => View(new ContactCreateViewModel());

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ContactCreateViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            await contact.CreateAsync(model);
            TempData["Success"] = "Thank you! We will get back to you shortly.";
            return RedirectToAction(nameof(Create));
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index(bool? open = null)
        {
            var model = await contact.GetAllAsync(open);
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SetHandled(int id, bool handled)
        {
            await contact.SetHandledAsync(id, handled);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await contact.DeleteAsync(id);
            TempData["Success"] = "Message deleted.";
            return RedirectToAction(nameof(Index));
        }
    }
}
