﻿using CongestionTax.Core.Dtos;
using CongestionTax.Service;

namespace CongestionTax.Core.Service
{
    public interface ITravelService
    {
        Task<int> RegisterTravelAsync(TraveltoRegisterDto travel);
    }
}