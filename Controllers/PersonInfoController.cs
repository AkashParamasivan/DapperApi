using DapperApi.Models;
using DapperApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonInfoController : ControllerBase
    {
        private readonly IPersonRepo _context;
        

        public PersonInfoController(IPersonRepo context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<PersonInfo> GetPersonDetails()
        {

            try
            {

                return _context.GetPersonDetails();
            }
            catch (System.Exception e)
            {
                
                throw;

            }
        }

        [HttpGet("{Personid}")]
        public IActionResult GetPerson(int Personid)
        {
            try
            {
               
                PersonInfo result = _context.GetPerson(Personid);
                if (result != null)
                {
                    return Ok(result);
                }
                result = new PersonInfo();
                return Ok(result);
            }
            catch (System.Exception e)
            {
                
                throw;
            }
        }


        [HttpPost]
        public PersonInfo InsertPersonDetails(PersonInfo person)
        {

            try
            {
               
               
                _context.InsertPersonDetails(person);
                return person;
            }
            catch (System.Exception e)
            {
                
                throw;
            }

        }

        [HttpPut("{id}")]
        public PersonInfo UpdatePersonDetails(int id, PersonInfo person)
        {
            try
            {
            

                 _context.UpdatePersonDetails(id, person);
                return person;
            }
            catch (System.Exception e)
            {
               
                throw;
            }
        }

        [HttpDelete("{Persionid}")]
        public string DeleteTruck(int Persionid)
        {
            try
            {
               
                _context.DeletePerson(Persionid);
                return "";
            }
            catch (System.Exception e)
            {
               
                throw;
            }


        }
    }
}
