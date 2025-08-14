using Microsoft.AspNetCore.Mvc;

namespace HotelRoomManager.Controllers
{
    public class RoomReviewController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
