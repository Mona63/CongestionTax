using CongestionTax.Core;
using CongestionTax.Core.Dtos;
using CongestionTax.Core.Entities;
using CongestionTax.Core.Service;

namespace CongestionTax.Service
{
    public class TravelService : ITravelService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITravelRepository _travelRepository;
       

        public TravelService(IUnitOfWork unitOfWork, ITravelRepository travelRepository)
        {
            _unitOfWork = unitOfWork;
            _travelRepository = travelRepository;
           
        }

        public async Task<int> RegisterTravelAsync(TravelDto travelDto)
        { 
            var travel = new Travel()
            {
                VehicleId = travelDto.VehicleId,
                TravelAt = travelDto.TravelAt,
            };
            await _travelRepository.InsertAsync(travel);
            _unitOfWork.Complete();
            return travel.Id;
        }


    }
}