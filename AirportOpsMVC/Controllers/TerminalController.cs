using AirportOpsMVC.Dto.Terminal;
using AirportOpsMVC.Interface;
using Microsoft.AspNetCore.Mvc;

namespace AirportOpsMVC.Controllers
{
    public class TerminalController : Controller
    {
        private readonly ITerminalService _terminalService;
        public TerminalController(ITerminalService terminalService)
        {
            _terminalService = terminalService;
        }
        public async Task<IActionResult> Index()
        {
            var res = await _terminalService.GetAllAsync();
            return View(res);
        }
        public async Task<IActionResult> Detail(int id)
        {
            var res = await _terminalService.GetByIdAsync(id);
            return View(res);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateTerminalDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);
             await _terminalService.AddAsync(dto);
            return RedirectToAction(nameof(Index));
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UpdateTerminalDto dto)
        {
            if (!ModelState.IsValid)
                return View();
            await _terminalService.UpdateAsync(id, dto);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Edit(int id)
        {
            var res = await _terminalService.GetForEditAsync(id);
            if (res == null)
                return NotFound();
            return View(res);
        }
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var res = await _terminalService.GetByIdAsync(id);
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
            await _terminalService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
