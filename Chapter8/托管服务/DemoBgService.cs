using System;

namespace 托管服务;

public class DemoBgService : BackgroundService
{
    private ILogger<DemoBgService> _logger;
    public DemoBgService(ILogger<DemoBgService> logger)
    {
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await Task.Delay(1000, stoppingToken);
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("DemoBgService is running at: {time}", DateTimeOffset.Now);
            await Task.Delay(5000, stoppingToken); // 每5秒执行一次
        }
    }
}
