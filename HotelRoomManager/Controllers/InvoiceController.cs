using HotelRoomManager.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelRoomManager.Controllers
{
    [Authorize(Roles = "Admin")]
    public class InvoiceController : Controller
    {
        private readonly IInvoiceService invoices;

        public InvoiceController(IInvoiceService _invoices)
        {
            invoices = _invoices;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = await invoices.GetAllAsync();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Issue(int bookingId)
        {
            try
            {
                var invoiceId = await invoices.IssueForBookingAsync(bookingId);
                TempData["Success"] = $"Invoice #{invoiceId} issued for booking #{bookingId}.";
            }
            catch (InvalidOperationException ex)
            {
                TempData["Error"] = ex.Message;
            }
            catch
            {
                TempData["Error"] = "Failed to issue invoice.";
            }

            return RedirectToAction("Index", "Invoice");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var inv = await invoices.GetByIdAsync(id);
            if (inv == null) return NotFound();
            return View(inv);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await invoices.DeleteAsync(id);
            TempData["Success"] = $"Invoice #{id} deleted.";
            return RedirectToAction(nameof(Index));
        }
    }
}
