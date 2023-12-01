using CongestionTax.Core;
using CongestionTax.Core.Entities;
using Microsoft.Extensions.Options;

namespace CongestionTax.Service
{
    public class DailyMaxChargeRule
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITollRepository _tollRepository;
        private readonly IOptions<RuleAppSettingsModel> _appSettings;
        public DailyMaxChargeRule(IUnitOfWork unitOfWork, ITollRepository tollRepository, IOptions<RuleAppSettingsModel> app)
        {
            _unitOfWork = unitOfWork;
            _tollRepository = tollRepository;
            _appSettings = app;
        }
        public async Task ApplyDailyMaxChargeRuleAsync(DateTime dt)
        {
            //var dailyMaxyChargeAmount = _appSettings.Value.DailyMaxChargeAmount;

            //var dailyMaxChargeRuleVehicleIds = _tollRepository
            //                                                .GetGrouped(e => e.VehicleId
            //                                                          , g => new { VehicleId = g.Key, Sum = g.Sum(t => t.Amount) }
            //                                                          , f => f.ActionAt.Day == dt.Day)
            //                                                .Where(r => r.Sum > dailyMaxyChargeAmount)
            //                                                .Select(c => c.VehicleId)
            //                                                .ToList();

            //await _tollRepository.BulkUpdateAsync(v => dailyMaxChargeRuleVehicleIds.Contains(v.VehicleId) && v.ActionAt.Day == dt.Day
            //                                    , c => c.Amount, c => 0);

            //var newChargetolls = dailyMaxChargeRuleVehicleIds.Select(t => new Toll()
            //                                                            {
            //                                                                ActionAt = dt.Date,
            //                                                                Amount = dailyMaxyChargeAmount,
            //                                                                VehicleId = t
            //                                                            }).ToList();
            //newChargetolls.ForEach(n => _tollRepository.InsertAsync(n));

            //_unitOfWork.Complete();

        }
    }
}
