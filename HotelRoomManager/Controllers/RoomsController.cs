using Microsoft.AspNetCore.Mvc;

namespace HotelRoomManager.Controllers
{
    public class RoomsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
