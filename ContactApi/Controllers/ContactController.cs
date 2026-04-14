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
using Microsoft.AspNetCore.Authorization;

namespace ContactApi.Controllers
{
    [Authorize]
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
        
        [HttpGet]
        public async Task<ActionResult> GetAllMycontactAsync()
        {
            var contact = await _contactRepository.GetAllMycontactAsync();
            return Ok(contact);
        }
        [Authorize(Roles = "Admin")]
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
        
        [HttpGet("{Id}")]
        public async Task<ActionResult<MycontactDto>> GetContactAsync(int Id)
        {
            var contact = await _contactRepository.GetMycontactAsync(Id);
            if (contact == null)
            {
                return NotFound($"contact with the {Id}not found");
            }
            return Ok(contact);
        }
       
        [HttpDelete]
        [Authorize(Roles ="Admin")]

        public async Task<ActionResult>DeleteMycontactAsync(int Id)
        {
            var contact = await _contactRepository.DeleteMycontactAsync(Id);
            if (!contact) 
            {
                return NotFound("contact Id not found");
            }
            return NoContent();

        }
    
        [HttpPut]

        public async Task<IActionResult> UpdateMycontact(int Id, MycontactDto request)
        {
            var contact = await _contactRepository.UpdateMycontactAsync(Id, request);
            if (!contact) throw new Exception($"contact with {Id}not found");
            return Ok($"employee update successfully");
        }
        
    }
}
