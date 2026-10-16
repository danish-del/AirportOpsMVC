using AirportOpsMVC.Dto.Terminal;

namespace AirportOpsMVC.Interface
{
    public interface ITerminalService
    {
        Task<IEnumerable<ResponseTerminalDto>> GetAllAsync();
        Task<ResponseTerminalDto?> GetByIdAsync(int id);
        Task AddAsync(CreateTerminalDto dto);
        Task<UpdateTerminalDto?> GetForEditAsync(int id);
        Task<bool> UpdateAsync(int id, UpdateTerminalDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
