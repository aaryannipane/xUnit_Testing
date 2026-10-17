using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceContracts.DTO
{
    public class CountryResponse
    {
        public Guid ID { get; set; }
        public string? Name { get; set; }
    }

    public static class CountryExtensions
    {
        public static CountryResponse ToCountryResponse(this Entities.Country country)
        {
            return new CountryResponse()
            {
                ID = country.Id,
                Name = country.Name
            };
        }
    }
}
