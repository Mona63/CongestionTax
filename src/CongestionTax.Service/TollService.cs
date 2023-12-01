using CongestionTax.Core.Dtos;
using CongestionTax.Core.Entities;
using CongestionTax.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongestionTax.Service
{
    public class TollService
    {
        private readonly IRuleEngine _ruleEngine;
        private readonly ITravelRepository _travelRepository;
        private readonly ITollRepository _tollRepository;

        public TollService(IRuleEngine ruleEngine, ITravelRepository travelRepository, ITollRepository tollRepository)
        {
            _ruleEngine = ruleEngine;
            _travelRepository = travelRepository;
            _tollRepository = tollRepository;
        }

        public async Task EvaluateTollsAsync(DateTime fromDateTime, DateTime toDateTime)
        {
         var travels= await  _travelRepository.GetAllAsync(t => t.TravelAt > fromDateTime && t.TravelAt<toDateTime);
            foreach (var travel in travels)
            {
               var amount= await _ruleEngine.Run(travel);
                if (amount !=0)
                {
                    var toll = new Toll()
                    {
                        EvaluateAt = DateTime.Now,
                        Amount = amount,
                        TravelId = travel.Id
                    };
                    await _tollRepository.InsertAsync(toll);
                }
                
            }
        }
    }
}
