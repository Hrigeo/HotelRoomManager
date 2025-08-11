using HotelRoomManager.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelRoomManager.Controllers
{
    public class RoomsController : Controller
    {

        private readonly IRoomsService roomsService;

        public RoomsController(IRoomsService _roomsService)
        {
            roomsService = _roomsService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var result = await roomsService.GetAllAsync();
            return View(result);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var model = await roomsService.GetDetailsAsync(id);
            if (model == null) return NotFound();
            return View(model);
        }
    }
}
