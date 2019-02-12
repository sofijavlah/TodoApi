using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Template;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using TodoApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoApi.Controllers
{
    //[Route("api/[controller]/[action]")]
    [Route("api/[controller]")]
    public class RutiranjeController : Controller
    {

        private readonly RutiranjeContext _context;

        // GET: api/<controller>
        [HttpGet("pretraga")]
        public async Task<ActionResult<IEnumerable<Rutiranje>>> GetRut()
        {
            return await _context.Rutiranja.ToListAsync();
            
        }

        // GET api/<controller>/5
        [HttpGet("pretraga/{id}")]
        
        public async Task<ActionResult<Rutiranje>> GetRut(int id)
        {
            var rut = await _context.Rutiranja.FindAsync(id);

            if (rut == null)
            {
                return NotFound();
            }

            return rut;
        }

        // GET: api/<controller>name
        [HttpGet("pretraga/{ime}/{prezime}")]
        public Rutiranje GetOsoba(string ime, string prezime)
        {
            IQueryable<Rutiranje> r = _context.Rutiranja;

       
            IQueryable<Rutiranje> imenaQuery = from rut in r
                where rut.Ime == ime &&
                      rut.Prezime == prezime
                select rut;

            //foreach (Rutiranje p in imenaQuery)
            //{
            //    return p;
            //}

            return imenaQuery.FirstOrDefault();

        }






        //// POST api/<controller>
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult PutOsoba(long id, Rutiranje inputModel)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest("Not valid");
            //}

            var rut = _context.Rutiranja.Where(r => r.Id == id).FirstOrDefault<Rutiranje>();

            if (rut != null)
            {
                rut.Ime = inputModel.Ime;
                rut.Prezime = inputModel.Prezime;
                rut.datumRodjenja = inputModel.datumRodjenja;
                rut.mestoRodjenja = inputModel.mestoRodjenja;
                rut.emailAdresa = inputModel.emailAdresa;

                _context.SaveChanges();

                return Ok();
            }

            return null;

        }

        // DELETE api/<controller>/5
        [HttpDelete("brisanje/{id}")]
        public IActionResult DeleteOsoba(int id)
        {
            if (id <= 0) return BadRequest("Not Valid");
            
            var rut = _context.Rutiranja.Where(r => r.Id == id).FirstOrDefault<Rutiranje>();

            _context.Remove(rut);

            _context.SaveChanges();

            return Ok();

        }
    }
}
