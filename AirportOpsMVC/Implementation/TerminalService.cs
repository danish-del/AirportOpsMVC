using AirportOpsMVC.Dto.Terminal;
using AirportOpsMVC.Interface;
using AirportOpsMVC.Models;
using Microsoft.Identity.Client;

namespace AirportOpsMVC.Implementation
{
    public class TerminalService : ITerminalService
    {
        private readonly IGenericRepository<Terminal> _genericRepo;
        public TerminalService(IGenericRepository<Terminal> GenericRepo)
        {
            _genericRepo = GenericRepo;
        }
        public async Task<IEnumerable<ResponseTerminalDto>> GetAllAsync()
        {
            var entity = await _genericRepo.GetAllAsync();
            return entity.Select(x => new ResponseTerminalDto
            {
                Id = x.Id,
                AirportId = x.AirportId,
                Name = x.Name,
                IsActive = x.IsActive
            });
        }
        public async Task<ResponseTerminalDto?> GetByIdAsync(int id)
        {
            var entity = await _genericRepo.GetByIdAsync(id);
            if (entity == null)
                throw new KeyNotFoundException($"Terminal ID {id} not found!");
            return new ResponseTerminalDto
            {
                Id = entity.Id,
                AirportId = entity.AirportId,
                Name = entity.Name,
                IsActive = entity.IsActive
            };
        }
        public async Task AddAsync(CreateTerminalDto dto)
        {
            var entity = new Terminal
            {
                AirportId = dto.AirportId,
                Name = dto.Name,
                IsActive = dto.IsActive
            };
            await _genericRepo.AddAsync(entity);
            await _genericRepo.SaveChangesAsync();
        }
        public async Task<UpdateTerminalDto?> GetForEditAsync(int id)
        {
            var terminal = await _genericRepo.GetByIdAsync(id);
            if (terminal == null)
                return null;
            return new UpdateTerminalDto
            {
                Id = terminal.Id,
                Name = terminal.Name,
                IsActive = terminal.IsActive
            };
        }
        public async Task<bool> UpdateAsync(int id, UpdateTerminalDto dto)
        {
            var entity = await _genericRepo.GetByIdAsync(id);
            if (entity == null)
                throw new KeyNotFoundException($"Terminal with ID {id} not found!");
            entity.AirportId = dto.AirportId;
            entity.Name = dto.Name;
            entity.IsActive = dto.IsActive;
            await _genericRepo.UpdateAsync(entity);
            await _genericRepo.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _genericRepo.GetByIdAsync(id);
            if (entity == null)
                throw new KeyNotFoundException($"Terminal with Id {id} not found!");
            await _genericRepo.DeleteAsync(entity);
            await _genericRepo.SaveChangesAsync();
            return true;
        }
    }
}
