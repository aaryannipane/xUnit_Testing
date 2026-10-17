using ServiceContracts;
using ServiceContracts.DTO;
using Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUDTests
{
    public class CountriesServiceTest
    {
        private readonly ICountriesService _countriesService;

        public CountriesServiceTest()
        {
            _countriesService = new CountriesService();
        }

        // When CountryAddRequest is null, AddCountry should throw ArgumentNullException
        [Fact]
        public void AddCountry_NullRequest_ThrowsArgumentNullException()
        {
            // Arrange
            CountryAddRequest? countryAddRequest = null;
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => _countriesService.AddCountry(countryAddRequest));
        }

        // When CountryName is null or empty, AddCountry should throw ArgumentException
        [Fact]
        public void AddCountry_NullOrEmptyName_ThrowsArgumentException()
        {
            // Arrange
            var countryAddRequest = new CountryAddRequest { Name = "" };
            // Act & Assert
            Assert.Throws<ArgumentException>(() => _countriesService.AddCountry(countryAddRequest));
        }

        // When CountryName is duplicate, AddCountry should throw ArgumentException
        [Fact]
        public void AddCountry_DuplicateName_ThrowsArgumentException()
        {
            // Arrange
            var countryAddRequest = new CountryAddRequest { Name = "USA" };
            _countriesService.AddCountry(countryAddRequest); // First time insert
            // Act & Assert
            Assert.Throws<ArgumentException>(() => _countriesService.AddCountry(countryAddRequest)); // Second time insert should throw exception
        }

        // When you supply proper CountryName then it should insert the record and return CountryResponse with proper values
        [Fact]
        public void AddCountry_ValidRequest_ReturnsCountryResponse()
        {
            // Arrange
            var countryAddRequest = new CountryAddRequest { Name = "Canada" };
            // Act
            var result = _countriesService.AddCountry(countryAddRequest);
            // Assert
            Assert.NotNull(result);
            Assert.True(result.ID != Guid.Empty);
            Assert.Equal("Canada", result.Name);
        }
    }
}
