using ForgeFolio.Core.DTOs.Statistic;
using ForgeFolio.Core.Entities;
using ForgeFolio.Core.Interfaces;
using ForgeFolio.Core.Interfaces.Services;

namespace ForgeFolio.Infrastructure.Services;

public class StatisticService : IStatisticService
{
    private readonly IUnitOfWork _unitOfWork;

    public StatisticService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<StatisticDto> GetStatisticsAsync()
    {
        var skillRepo = _unitOfWork.GetRepository<Skill>();
        var messageRepo = _unitOfWork.GetRepository<Message>();

        var dto = new StatisticDto
        {
            TotalSkills = await skillRepo.CountAsync(),
            TotalMessages = await messageRepo.CountAsync(),
            UnreadMessages = await messageRepo.CountAsync(x => !x.IsRead),
            ReadMessages = await messageRepo.CountAsync(x => x.IsRead),
            
            // Hardcoded values for demo/placeholder data as per original template
            Visitors = 1294,
            TotalSales = 1345,
            TotalSubscribers = 1303,
            TotalOrders = 576,
            AwardsReceived = 150,
            ProjectsCompleted = 110,
            HappyClients = 101
        };

        return dto;
    }
}
