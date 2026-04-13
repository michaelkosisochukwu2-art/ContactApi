using ContactApi.Data;
using ContactApi.Dto;
using ContactApi.Model;

namespace ContactApi.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly IContactRepository _contactRepository;
        private readonly ContactDbContext _context;
        public ContactRepository(ContactDbContext context)
        { 
            _context = context;

        }

        public async Task<int> AddMycontact(MycontactDto mycontact)
        {
            if (mycontact == null)throw new ArgumentNullException(nameof(mycontact));
            var newMycontact = new Mycontact()
            {
                FullName=mycontact.FullName,
                PhoneNumber=mycontact.PhoneNumber,
                EmailAddress=mycontact.EmailAddress,
                City=mycontact.City,
                Id=mycontact.Id,
                Address=mycontact.Address,
            };
            await _context.Mycontacts.AddAsync(newMycontact);
            await _context.SaveChangesAsync();
            return newMycontact.Id;
        }
    }
}
