using ContactApi.Dto;

namespace ContactApi.Repository
{
    public interface IContactRepository
    {
        Task<int> AddMycontact(MycontactDto mycontact);
        Task<MycontactDto> GetMycontactAsync(int Id);
        Task<bool> DeleteMycontactAsync(int Id);
        Task<bool> UpdateMycontactAsync(int Id, MycontactDto mycontact);
    }
}
