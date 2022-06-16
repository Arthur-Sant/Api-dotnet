using System.Net.Http;
using System.Net;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Globalization;
using System.Threading.Tasks;
using webapidotnet.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapidotnet.Models;

namespace webapidotnet.Controllers
{

    [Controller]
    [Route("[controller]")]

    public class PersonController : ControllerBase
    {
        private DataContext dataContext; 

        public PersonController(DataContext dataContext){
            this.dataContext = dataContext;
        }

        [HttpPost("hi")]
        public async Task<ActionResult> createPerson([FromBody] Person person){
            dataContext.person.Add(person);
            await dataContext.SaveChangesAsync();

            return Created("Object person", person);
        }

        [HttpGet("hi")]
        public async Task<ActionResult> listPeople(){
            var datas = await dataContext.person.ToListAsync();

            return Ok(datas);
        }

        [HttpGet("hi/{id}")]
        public Person listPersonById(int id){
            Person person = dataContext.person.Find(id);

            return person;
        }

        [HttpPut("hi")]
        public async Task<ActionResult> editPersonInformation([FromBody] Person person){
            dataContext.person.Update(person);
            await dataContext.SaveChangesAsync();

            return Ok(person);
        }

        [HttpDelete("hi/{id}")]
        public async Task<ActionResult> deletePerson(int id) {
            Person person = this.listPersonById(id);

            if(person == null) {
                return NotFound();
            }

            dataContext.person.Remove(person);
            await dataContext.SaveChangesAsync();

            return Ok();
        }
    }
}