using Microsoft.AspNetCore.Mvc;

namespace HotelRoomManager.Controllers
{
    public class InvoiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
