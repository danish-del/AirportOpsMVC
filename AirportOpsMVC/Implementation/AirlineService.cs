using AirportOpsMVC.Data;
using AirportOpsMVC.Dto.Airline;
using AirportOpsMVC.Interface;
using AirportOpsMVC.Models;
using Microsoft.Identity.Client;

namespace AirportOpsMVC.Implementation
{   
    public class AirlineService : IAirlineService
    {
        private readonly IGenericRepository<Airline> _context;
        public AirlineService(IGenericRepository<Airline> Context)
        {
            _context = Context;
        }
        public async Task<IEnumerable<ResponseAirlineDto>> GetAllAsync()
        {
            var airline = await _context.GetAllAsync();
            return airline.Select(x => new ResponseAirlineDto
            {
                Id = x.Id,
                Name = x.Name,
                Code = x.Code,
                IsActive = x.IsActive
            });
        }
        public async Task<ResponseAirlineDto?> GetByIdAsync(int id)
        {
            var entity = await _context.GetByIdAsync(id);
            if (entity == null)
                throw new KeyNotFoundException($"Airline with ID {id} not found!");
            return new ResponseAirlineDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Code = entity.Code,
                IsActive = entity.IsActive
            };
        }
        public async Task AddAsync(CreateAirlineDto dto)
        {
            var entity = new Airline
            {
                Name = dto.Name,
                Code = dto.Code,
                IsActive = dto.IsActive
            };
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> UpdateAsync(int id, UpdateAirlineDto dto)
        {
            var entity = await _context.GetByIdAsync(id);
            if(entity == null)
                throw new KeyNotFoundException($"Airline with ID {id} not found!");
            entity.Id = dto.Id;
            entity.Name = dto.Name;
            entity.Code = dto.Code;
            entity.IsActive = dto.IsActive;
            await _context.UpdateAsync(entity);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.GetByIdAsync(id);
            if(entity == null)
                throw new KeyNotFoundException($"Airline with Id {id} not found!");
            await _context.DeleteAsync(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
