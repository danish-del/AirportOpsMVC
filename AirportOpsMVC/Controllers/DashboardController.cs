using AirportOpsMVC.Interface;
using AirportOpsMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AirportOpsMVC.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly IGenericRepository<Airline> _airlineRepo;
        private readonly IGenericRepository<Airport> _airportRepo;
        private readonly IGenericRepository<Terminal> _terminalRepo;
        private readonly IGenericRepository<TerminalGate> _terminalGate;
        public DashboardController(IGenericRepository<Airline> AirlineRepo, IGenericRepository
            <Airport> AirportRepo, IGenericRepository<Terminal> TerminalRepo, 
            IGenericRepository<TerminalGate> TerminalGate)
        {
            _airlineRepo = AirlineRepo;
            _airportRepo = AirportRepo;
            _terminalRepo = TerminalRepo;
            _terminalGate = TerminalGate;
        }
        public async Task<IActionResult> Index()
        {
            var airline = await _airlineRepo.GetAllAsync();
            var airport = await _airportRepo.GetAllAsync();
            var terminal = await _terminalRepo.GetAllAsync();
            var terminalGate = await _terminalGate.GetAllAsync();

            ViewBag.AirlineCount = airline.Count();
            ViewBag.AirportCount = airport.Count();
            ViewBag.TerminalCount = terminal.Count();
            ViewBag.TerminalGate = terminalGate.Count();
            return View();
        }
    }
}
