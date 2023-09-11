using CongestionTax.Core;
using CongestionTax.Core.Dtos;

namespace CongestionTax.Service
{
    public class HitDailyMaxChargeRule
    {
        private readonly ITollRepository _tollRepository;
       
        public HitDailyMaxChargeRule(ITollRepository tollRepository)
        {
            _tollRepository = tollRepository;
            
        }
        public async void UpdateTollsAfterHitDailyMaxAsync(DateTime dt)
        {
            //todo
            //group by vehichleId where amount>60 in a day
            //update all tollamount=0 after the row hti the max
        }
    }
}
