using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HotelRoomManager.Contracts;

namespace HotelRoomManager.Controllers
{
    public class RoomsController : Controller
    {

        private readonly IRoomsService roomsService;

        public RoomsController(IRoomsService _roomsService)
        {
            roomsService = _roomsService;
        }


        public async Task<IActionResult> Index()
        {
            var model = await roomsService.GetAllAsync();
            return View(model);
        }
    }
}
