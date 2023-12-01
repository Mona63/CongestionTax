using CongestionTax.Service.Rules;

namespace CongestionTax.Scheduling
{
    public class HourlyHostedService : IHostedService, IDisposable
    {
        private int executionCount = 0;
        private readonly ILogger<HourlyHostedService> _logger;
        private Timer? _timer = null;
        private readonly HourlyMaxChargeRule _hourlyMaxChargeRule;

        public HourlyHostedService(ILogger<HourlyHostedService> logger)
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
            try
            {
            var count = Interlocked.Increment(ref executionCount);
            //_hourlyMaxChargeRule.ApplyHourlyMaxChargeRuleAsync(DateTime.Now.AddHours(-1));

            _logger.LogInformation(
                "Timed Hosted Service is working. Count: {Count}", count);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
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
