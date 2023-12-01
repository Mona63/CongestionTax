using CongestionTax.Core;
using CongestionTax.Core.Dtos;
using CongestionTax.Core.Entities;
using CongestionTax.Core.Service;

namespace CongestionTax.Service
{
    public class TravelService : ITravelService
    {
        private readonly ITravelRepository _travelRepository;


        public TravelService(ITravelRepository travelRepository)
        {
            _travelRepository = travelRepository;

        }

        public async Task<int> RegisterTravelAsync(TraveltoRegisterDto travelDto)
        {
            var travel = new Travel()
            {
                VehicleId = travelDto.VehicleId,
                TravelAt = travelDto.TravelAt,
            };
            await _travelRepository.InsertAsync(travel);

            return travel.Id;
        }


    }
}