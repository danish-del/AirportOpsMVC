using AirportOpsMVC.Dto.Airline;
using AirportOpsMVC.Implementation;
using AirportOpsMVC.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace AirportOpsMVC.Controllers
{
    
    public class AirlineController : Controller
    {
        private readonly IAirlineService _airlineService;
        public AirlineController(IAirlineService Airline)
        {
            _airlineService = Airline;

        }
        public async Task<IActionResult> Index()
        {
            var res = await _airlineService.GetAllAsync();
            return View(res);
        }
        public async Task<IActionResult> Detail(int id)
        {
            var res = await _airlineService.GetByIdAsync(id);
            return View(res);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateAirlineDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);
            await _airlineService.AddAsync(dto);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Edit(int id)
        {
            var res = await _airlineService.GetByIdAsync(id);
            if (res == null)
                return NotFound();
            var dto = new UpdateAirlineDto
            {
                Id = res.Id,
                Name = res.Name,
                Code = res.Code,
                IsActive = res.IsActive
            };
            return View(dto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UpdateAirlineDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);
            await _airlineService.UpdateAsync(id, dto);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int id)
        {
            var res = await _airlineService.GetByIdAsync(id);
            if (res == null)
                return NotFound();
            return View(res);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _airlineService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
