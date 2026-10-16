using AirportOpsMVC.Dto.Airport;
using AirportOpsMVC.Interface;
using Microsoft.AspNetCore.Mvc;

namespace AirportOpsMVC.Controllers
{
    public class AirportController : Controller
    {
        private readonly IAirportService airportService;
        public AirportController(IAirportService AirportService)
        {
            airportService = AirportService;
        }
        public async Task<IActionResult> Index()
        {
            var res = await airportService.GetAllAsync();
            return View(res);
        }
        public async Task<IActionResult> Detail(int id)
        {
            var res = await airportService.GetByIdAsync(id);
            return View(res);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateAirportDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);
            await airportService.AddAsync(dto);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Edit(int id)
        {
            var res = await airportService.GetForEditAsync(id);
            if (res == null)
                return NotFound();
            return View(res);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,UpdateAirportDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);
            await airportService.UpdateAsync(id, dto);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int id)
        {
            var res = await airportService.GetByIdAsync(id);
            if (res == null)
                return NotFound();
            return View(res);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await airportService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
