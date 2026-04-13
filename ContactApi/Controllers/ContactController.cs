using ContactApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ContactApi.Data;
using ContactApi.Dto;
using ContactApi.Repository;
using Microsoft.EntityFrameworkCore;

namespace ContactApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly ContactDbContext _dbContext;
        private readonly IContactRepository _contactRepository;
        public ContactController(ContactDbContext context, IContactRepository contactRepository)
        {
            _dbContext = context;
            _contactRepository= contactRepository;
        }
        [HttpPost]

        public async Task<ActionResult<MycontactDto>> CreateMycontact([FromBody] MycontactDto request)
        {
            if (request == null) 
            {
                return BadRequest("sorry can't create a contact");
            }
            var newContactId= await _contactRepository.AddMycontact(request);
            var createdContact = await _dbContext.Mycontacts.Where(e => e.Id == newContactId).Select(e => new MycontactDto()
            {
                FullName = e.FullName,
                PhoneNumber = e.PhoneNumber,
                Address = e.Address,
                City = e.City,
                EmailAddress = e.EmailAddress,
                Id = e.Id,

            }).FirstOrDefaultAsync();
            return Created("", newContactId);


        }
    }
}
