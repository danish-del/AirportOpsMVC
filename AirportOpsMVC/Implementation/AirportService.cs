using AirportOpsMVC.Dto.Airport;
using AirportOpsMVC.Interface;
using AirportOpsMVC.Models;

namespace AirportOpsMVC.Implementation
{
    public class AirportService :IAirportService
    {
        private readonly IGenericRepository<Airport> _airportrepo;
        public AirportService(IGenericRepository<Airport> AirportRepo)
        {
            _airportrepo = AirportRepo;
        }
        public async Task<IEnumerable<ResponseAirportDto>> GetAllAsync()
        {
            var entity = await _airportrepo.GetAllAsync();
            return entity.Select(x => new ResponseAirportDto
            {
                Id = x.Id,
                Name = x.Name,
                Code = x.Code,
                City = x.City,
                Country = x.Country,
                IsActive = x.IsActive
            });
        }
        public async Task<ResponseAirportDto?> GetByIdAsync(int id)
        {
            var entity = await _airportrepo.GetByIdAsync(id);
            if (entity == null)
                throw new KeyNotFoundException($"Airport with ID {id} not found.");
            return new ResponseAirportDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Code = entity.Code,
                City = entity.City,
                Country = entity.Country,
                IsActive = entity.IsActive
            };
        }
        public async Task AddAsync(CreateAirportDto dto)
        {
            var entity = new Airport
            {
                Name = dto.Name,
                Code = dto.Code,
                City = dto.City,
                Country = dto.Country,
                IsActive = dto.IsActive
            };
            await _airportrepo.AddAsync(entity);
            await _airportrepo.SaveChangesAsync();
        }
        public async Task<UpdateAirportDto> GetForEditAsync(int id)
        {
            var entity = await _airportrepo.GetByIdAsync(id);
            if (entity == null)
                throw new KeyNotFoundException($"Airport with ID {id} not found.");
            return new UpdateAirportDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Code = entity.Code,
                City = entity.City,
                Country = entity.Country,
                IsActive = entity.IsActive
            };
        }
        public async Task<bool> UpdateAsync(int id, UpdateAirportDto dto)
        {
            var entity = await _airportrepo.GetByIdAsync(id);
            if (entity == null)
                throw new KeyNotFoundException($"Airport with ID {id} not found.");
            entity.Name = dto.Name;
            entity.Code = dto.Code;
            entity.City = dto.City;
            entity.Country = dto.Country;
            entity.IsActive = dto.IsActive;
            await _airportrepo.UpdateAsync(entity);
            await _airportrepo.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _airportrepo.GetByIdAsync(id);
            if (entity == null)
                throw new KeyNotFoundException($"Airport with ID {id} not found!");
             await _airportrepo.DeleteAsync(entity);
            await _airportrepo.SaveChangesAsync();
            return true;
        }
    }
}
