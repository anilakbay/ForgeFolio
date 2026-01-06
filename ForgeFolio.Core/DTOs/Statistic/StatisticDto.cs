namespace ForgeFolio.Core.DTOs.Statistic;

public class StatisticDto
{
    // Existing statistics from View
    public int TotalSkills { get; set; }
    public int TotalMessages { get; set; }
    public int UnreadMessages { get; set; }
    public int ReadMessages { get; set; }
    
    // Additional placeholders from Html template (can be dynamic later if we have those entities)
    public int Visitors { get; set; } 
    public decimal TotalSales { get; set; }
    public int TotalSubscribers { get; set; }
    public int TotalOrders { get; set; }
    public int AwardsReceived { get; set; }
    public int ProjectsCompleted { get; set; }
    public int HappyClients { get; set; }
}
