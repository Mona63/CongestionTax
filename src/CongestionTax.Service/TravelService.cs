using CongestionTax.Core;
using CongestionTax.Core.Dtos;
using CongestionTax.Core.Entities;
using CongestionTax.Core.Service;
using System.Diagnostics;

namespace CongestionTax.Service
{
    public class TravelService : ITravelService
    {

        private readonly ITollRepository _tollRepository;
        private readonly IRuleEngine _ruleEngine;

        public TravelService(ITollRepository tollRepository, IRuleEngine ruleEngine)
        {
            _tollRepository = tollRepository;
            _ruleEngine = ruleEngine;
        }

        public async Task<int> RegisterTollAsync(TravelDto travel)
        {
            var tollAmount = _ruleEngine.GetTollAmount(travel);
            var toll = new Toll()
            {
                VehicleId = travel.VehicleId,
                ActionAt = travel.ActionAt,
                Amount = tollAmount
            };
            await _tollRepository.InsertAsync(toll);
            return toll.Id;
        }
        

    }
}