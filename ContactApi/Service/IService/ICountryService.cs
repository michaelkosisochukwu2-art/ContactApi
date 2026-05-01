using ContactApi.Dto;

namespace ContactApi.Service.IService
{
    public interface ICountryService
    {
        Task<List<CountryDto>> GetAllCountriesAsync();
        Task<CountryDto?> GetCountryByNameAsync(string name);
    }
}
