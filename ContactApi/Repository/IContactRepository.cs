using ContactApi.Dto;
using ContactApi.Model;

namespace ContactApi.Repository
{
    public interface IContactRepository
    {
        Task<List<MycontactDto>> GetAllMycontactAsync();
        Task<int> AddMycontact(MycontactDto mycontact);
        Task<MycontactDto> GetMycontactAsync(int Id);
        Task<bool> DeleteMycontactAsync(int Id);
        Task<bool> UpdateMycontactAsync(int Id, MycontactDto mycontact);
    }
}
