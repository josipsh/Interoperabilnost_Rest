using IisRest.Contracts.Dtos.ReportDtos;

namespace IisRest.Contracts.Services
{
    public interface IReportService
    {
        List<ReportReadDto> GetFullReport(int userId);
    }
}
