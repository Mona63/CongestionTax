using CongestionTax.Core;
using CongestionTax.Core.Entities;

namespace CongestionTax.Service
{
    public class HourlyMaxChargeRule
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITollRepository _tollRepository;

        public HourlyMaxChargeRule(IUnitOfWork unitOfWork, ITollRepository tollRepository)
        {
            _unitOfWork = unitOfWork;
            _tollRepository = tollRepository;

        }
        public async Task ApplyHourlyMaxChargeRuleAsync(DateTime dt)
        {
            var hourlyMaxChargeRuleVehicles = _tollRepository
                                                            .GetGrouped(e => e.VehicleId
                                                                      , g => new { VehicleId = g.Key, Count = g.Count(), Max = g.Max(t => t.Amount) }
                                                                      , f => f.ActionAt.Hour >= dt.Hour && f.ActionAt.Hour < dt.AddHours(1).Hour)
                                                            .Where(r => r.Count > 1)
                                                            .ToList();

            await _tollRepository.BulkUpdateAsync(v => hourlyMaxChargeRuleVehicles.Select(v => v.VehicleId)
                                                       .Contains(v.VehicleId) && v.ActionAt.Hour >= dt.Hour && v.ActionAt.Hour < dt.AddHours(1).Hour
                                                       , c => c.Amount, c => 0);

            var newChargetolls = hourlyMaxChargeRuleVehicles.Select(t => new Toll()
            {
                ActionAt = dt.Date,
                Amount = t.Max,
                VehicleId = t.VehicleId
            }).ToList();
            newChargetolls.ForEach(n => _tollRepository.InsertAsync(n));

            _unitOfWork.Complete();

        }
    }
}
