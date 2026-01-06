using ForgeFolio.Core.DTOs.Statistic;

namespace ForgeFolio.Core.Interfaces.Services;

public interface IStatisticService
{
    Task<StatisticDto> GetStatisticsAsync();
}
