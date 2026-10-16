using AirportOpsMVC.Dto.Airline;

namespace AirportOpsMVC.Interface
{
    public interface IAirlineService
    {
        Task<IEnumerable<ResponseAirlineDto>> GetAllAsync();
        Task<ResponseAirlineDto?> GetByIdAsync(int id);
        Task AddAsync(CreateAirlineDto dto);
        Task<bool> UpdateAsync(int id, UpdateAirlineDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
