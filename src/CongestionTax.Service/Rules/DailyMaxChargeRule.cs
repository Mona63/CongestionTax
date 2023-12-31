﻿using CongestionTax.Core;
using CongestionTax.Core.Entities;
using CongestionTax.Core.RuleEngine;
using Microsoft.Extensions.Options;

namespace CongestionTax.Service
{
    public class DailyMaxChargeRule : ICongestionTaxRule
    {
        private readonly ITollRepository _tollRepository;
        private readonly IOptions<RuleAppSettingsModel> _appSettings;
        public DailyMaxChargeRule(ITollRepository tollRepository, IOptions<RuleAppSettingsModel> app)
        {
            _tollRepository = tollRepository;
            _appSettings = app;
        }
        int Priority => 5;
        public async Task<EvalutionResult> Evaluate(Travel travel, EvalutionResult lastEvalutionResult)
        {
            var countinueEvaluation = true;
            var amount = lastEvalutionResult.Amount;
            var dailyMaxChargeAmount = _appSettings.Value.DailyMaxChargeAmount;
            var totalDailyAmount = await _tollRepository.GetTotalAmount(c => c.Travel.VehicleId == travel.VehicleId &&
                                                                           c.Travel.TravelAt.Date == travel.TravelAt.Date);

            if (totalDailyAmount + lastEvalutionResult.Amount > dailyMaxChargeAmount)
            {
                countinueEvaluation = false;
                amount = 0;

            }
            return new EvalutionResult(countinueEvaluation, amount);

        }
    }
}
