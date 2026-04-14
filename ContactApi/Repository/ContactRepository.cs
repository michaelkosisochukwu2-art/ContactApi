using ContactApi.Data;
using ContactApi.Dto;
using ContactApi.Model;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;



namespace ContactApi.Repository
{
    public class ContactRepository : IContactRepository
    {
       
        private readonly ContactDbContext _context;
        public ContactRepository(ContactDbContext context)
        {
            _context = context;
           

        }
        public async Task<List<MycontactDto>>GetAllMycontactAsync()
        {
            var allContact = await _context.Mycontacts.ToListAsync();
            var contactDto = await _context.Mycontacts.Select(e => new MycontactDto
            {
                PhoneNumber = e.PhoneNumber,
                Id=e.Id,
                EmailAddress=e.Address,
                City=e.City,
                Address=e.Address,
                FullName=e.FullName
            }).ToListAsync();
            return contactDto;

            
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

        public async Task<MycontactDto> GetMycontactAsync(int Id)
        {
            var contactId = await _context.Mycontacts.FindAsync(Id);
            if (contactId == null) return null;
            return new MycontactDto()
            {
                FullName = contactId.FullName,
                PhoneNumber = contactId.PhoneNumber,
                EmailAddress = contactId.EmailAddress,
                City = contactId.City,
                Id = contactId.Id,
                Address = contactId.Address,
            };
        }

        public async Task<bool> DeleteMycontactAsync(int Id)
        {
            var contactId = await _context.Mycontacts.FindAsync(Id);
            if (contactId == null)return false;
            _context.Mycontacts.Remove(contactId);
            _context.SaveChanges();
            return true;
        }

        public async Task<bool> UpdateMycontactAsync(int Id, MycontactDto mycontact)
        {
            var existingContact = await _context.Mycontacts.FindAsync(Id);
            if (existingContact == null) return false;
            existingContact.FullName = mycontact.FullName;
            existingContact.Address = mycontact.Address;
            existingContact.PhoneNumber = mycontact.PhoneNumber;
            existingContact.EmailAddress = mycontact.EmailAddress;
            existingContact.City = mycontact.City;
            existingContact.Id = mycontact.Id;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
