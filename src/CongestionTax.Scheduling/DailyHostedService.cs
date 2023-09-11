using CongestionTax.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongestionTax.Scheduling
{
    public class DailyHostedService : IHostedService, IDisposable
    {
        private int executionCount = 0;
        private readonly ILogger<DailyHostedService> _logger;
        private Timer? _timer = null;
        private readonly HitDailyMaxChargeRule _hitDailyMaxChargeRule;

        public DailyHostedService(ILogger<DailyHostedService> logger)
        {
            _logger = logger;
        }

        public Task StartAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Timed Hosted Service running.");

            _timer = new Timer(DoWork, null, TimeSpan.Zero,
                TimeSpan.FromDays(1));

            return Task.CompletedTask;
        }

        private void DoWork(object? state)
        {
            var count = Interlocked.Increment(ref executionCount);

            _hitDailyMaxChargeRule.UpdateTollsAfterHitDailyMaxAsync(DateTime.Now.AddDays(-1));

            _logger.LogInformation(
                "Timed Hosted Service is working. Count: {Count}", count);
        }

        public Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Timed Hosted Service is stopping.");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
