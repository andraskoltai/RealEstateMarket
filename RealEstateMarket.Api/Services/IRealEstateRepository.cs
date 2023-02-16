using RealEstateMarket.Api.Models;

namespace RealEstateMarket.Api.Services
{
    public interface IRealEstateRepository
    {
        Task<IEnumerable<RealEstate>> GetAllAsync();
        void InsertAsync(RealEstate realEstate);
        Task<RealEstate> GetByIdAsync(Guid id);
        void UpdateAsync(RealEstate realEstate);
        void DeleteAsync(Guid id);
    }
}
