using CongestionTax.Core.Dtos;
using CongestionTax.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongestionTax.Service
{
    public class HourlyMaxChargeRule
    {
        private readonly ITollRepository _tollRepository;

        public HourlyMaxChargeRule(ITollRepository tollRepository)
        {
            _tollRepository = tollRepository;

        }
        public async void KeepJustMaxChargeInHourAsync(DateTime dt)
        {
            //todo
            //get the max charge for every vehicle in one hour
            //update other tollamount=0 except the max one
        }
    }
}
