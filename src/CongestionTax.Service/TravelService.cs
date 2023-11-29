using CongestionTax.Core;
using CongestionTax.Core.Dtos;
using CongestionTax.Core.Entities;
using CongestionTax.Core.Service;

namespace CongestionTax.Service
{
    public class TravelService : ITravelService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITollRepository _tollRepository;
        private readonly IRuleEngine _ruleEngine;

        public TravelService(IUnitOfWork unitOfWork, ITollRepository tollRepository, IRuleEngine ruleEngine)
        {
            _unitOfWork = unitOfWork;
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
            _unitOfWork.Complete();
            return toll.Id;
        }


    }
}