using ContactApi.Dto;

namespace ContactApi.Repository
{
    public interface IContactRepository
    {
        Task<int> AddMycontact(MycontactDto mycontact);
    }
}
