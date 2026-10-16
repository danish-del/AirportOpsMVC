using AirportOpsMVC.Dto.TerminalGateDto;
using AirportOpsMVC.Interface;
using AirportOpsMVC.Models;

namespace AirportOpsMVC.Implementation
{
    public class TerminalGateService : ITerminalGateService
    {
        private readonly IGenericRepository<TerminalGate> _terminalGate;
        public TerminalGateService(IGenericRepository<TerminalGate> TerminalGate)
        {
            _terminalGate = TerminalGate;
        }
        public async Task<IEnumerable<ResponseTerminalGateDto>> GetAllAsync()
        {
            var res = await _terminalGate.GetAllAsync();
            return res.Select(x => new ResponseTerminalGateDto
            {
                Id = x.Id,
                TerminalId = x.TerminalId,
                GateNumber = x.GateNumber,
                IsActive = x.IsActive
            });
        }
        public async Task<ResponseTerminalGateDto> GetAllAsync(int id)
        {
            var res = await _terminalGate.GetByIdAsync(id);
            if (res == null)
                 throw new KeyNotFoundException($"TerminalGate with ID {id} not found!");
            return new ResponseTerminalGateDto
            {
                Id = res.Id,
                TerminalId = res.TerminalId,
                GateNumber = res.GateNumber,
                IsActive = res.IsActive
            };
        }
        public async Task AddAsync(CreateTerminalGateDto dto)
        {
            var terminalGate = new TerminalGate
            {
                TerminalId = dto.TerminalId,
                GateNumber = dto.GateNumber,
                IsActive = dto.IsActive
            };
            await _terminalGate.AddAsync(terminalGate);
            await _terminalGate.SaveChangesAsync();
        }
        public async Task<bool> UpdateAsync(int id, UpdateTerminalGateDto dto)
        {
            var res = await _terminalGate.GetByIdAsync(id);
            if (res == null)
                throw new KeyNotFoundException($"ID {id} not found!");
            res.TerminalId = dto.TerminalId;
            res.GateNumber = dto.GateNumber;
            res.IsActive = dto.IsActive;
            await _terminalGate.UpdateAsync(res);
            await _terminalGate.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var res = await _terminalGate.GetByIdAsync(id);
            if (res == null)
                throw new KeyNotFoundException($"TerminalGate with ID {id} not found!");
            await _terminalGate.DeleteAsync(res);
            await _terminalGate.SaveChangesAsync();
            return true;
        }
    }
}
