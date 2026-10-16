using AirportOpsMVC.Dto.TerminalGateDto;

namespace AirportOpsMVC.Interface
{
    public interface ITerminalGateService
    {
        Task<IEnumerable<ResponseTerminalGateDto>> GetAllAsync();
        Task<ResponseTerminalGateDto> GetAllAsync(int id);
        Task AddAsync(CreateTerminalGateDto dto);
        Task<bool> UpdateAsync(int id, UpdateTerminalGateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
