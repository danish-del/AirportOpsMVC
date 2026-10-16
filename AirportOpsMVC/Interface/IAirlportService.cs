using AirportOpsMVC.Dto.Airport;

namespace AirportOpsMVC.Interface
{
    public interface IAirportService
    {
        Task<IEnumerable<ResponseAirportDto>> GetAllAsync();
        Task<ResponseAirportDto?> GetByIdAsync(int id);
        Task<UpdateAirportDto> GetForEditAsync(int id);
        Task AddAsync(CreateAirportDto dto);
        Task<bool> UpdateAsync(int id, UpdateAirportDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
