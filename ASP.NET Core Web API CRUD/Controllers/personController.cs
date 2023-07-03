using ASP.NET_Core_Web_API_CRUD.Data;
using ASP.NET_Core_Web_API_CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Core_Web_API_CRUD.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class personController : Controller
    {
        private readonly DataContext context;

        public personController(DataContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public async Task<IActionResult> Getpersons()
        {
            return Ok(await context.persons.ToListAsync());
             
        }


        [HttpGet]
        [Route("{id:guid}")] 
        public async Task<IActionResult> Getperson([FromRoute] Guid id)
        {
            var person = await context.persons.FindAsync(id);
            if(person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }

        [HttpPost]
        public async Task<IActionResult> Addperson(AddPersonRequest addPersonelRequest)
        {
            var person = new person()
            {
                Id = Guid.NewGuid(),
                Name = addPersonelRequest.Name,
                Email = addPersonelRequest.Email,
                Phone = addPersonelRequest.Phone,
                Address = addPersonelRequest.Address

            };

            await context.persons.AddAsync(person);
            await context.SaveChangesAsync();

            return Ok(person);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> Updateperson([FromRoute] Guid id,UpdatePersonRequest updatePersonRequest)
        {
            var person=context.persons.Find(id);

            if(person != null)
            {
                person.Name=updatePersonRequest.Name;
                person.Email=updatePersonRequest.Email;
                person.Phone=updatePersonRequest.Phone;
                person.Address=updatePersonRequest.Address;

                await context.SaveChangesAsync();
                return Ok(person);
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Deleteperson([FromRoute] Guid id)
        {
            var person = await context.persons.FindAsync(id);

            if(person != null)
            {
                context .persons.Remove(person);
                context.SaveChangesAsync();
                return Ok(person);
            }
            return NotFound();
        }
    }
}
