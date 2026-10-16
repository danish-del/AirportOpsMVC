using AirportOpsMVC.Dto.TerminalGateDto;
using AirportOpsMVC.Interface;
using Microsoft.AspNetCore.Mvc;

namespace AirportOpsMVC.Controllers
{
    public class TerminalGateController : Controller
    {
        private readonly ITerminalGateService _terminalGateService;
        public TerminalGateController(ITerminalGateService TerminalGate)
        {
            _terminalGateService = TerminalGate;
        }
        public async Task<IActionResult> Index()
        {
            var entity = await _terminalGateService.GetAllAsync();
            return View(entity);
        }
        public async Task<IActionResult> Detail(int id)
        {
            var entity = await _terminalGateService.GetAllAsync(id);
            return View(entity);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateTerminalGateDto dto)
        {
            if (!ModelState.IsValid)
                return View();
            await _terminalGateService.AddAsync(dto);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Edit(int id)
        {
            var entity = await _terminalGateService.GetAllAsync(id);
            if (entity == null)
                throw new KeyNotFoundException($"TerminalGate with ID {id} not found!");
            return View(entity);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UpdateTerminalGateDto dto)
        {
            if (!ModelState.IsValid)
                return View();
            await _terminalGateService.UpdateAsync(id, dto);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int id)
        {
            var res = await _terminalGateService.GetAllAsync(id);
            if (res == null)
                return NotFound();
            return View(res);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (!ModelState.IsValid)
                return View();
            await _terminalGateService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
