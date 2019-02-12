using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.AspNetCore.Routing.Template;
using Microsoft.EntityFrameworkCore.Design;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : Controller
    {
        private readonly TodoContext _context;

        public TodoController(TodoContext context)
        {
            _context = context;


            //!
            _context.Database.EnsureCreated();

            if (_context.TodoItems.Count() == 0)
            {
                // Create a new TodoItem if collection is empty,
                 //which means you can't delete all TodoItems.
                _context.TodoItems.Add(new TodoItem() {Name = "Item1"});
                _context.SaveChanges();
            }

            if (_context.Osobe.Count() == 0)
            {
                // Create a new TodoItem if collection is empty,
                // which means you can't delete all TodoItems.
                _context.Osobe.Add(new Osoba() { Ime = "Ja" });
                _context.SaveChanges();
            }
        }

        ////GET: api/Todo
        [HttpGet("pretraga1")]
        public IActionResult GetOsobe()
        {
            var osobe = _context.Osobe.ToList();
            return Ok(osobe);
        }

        //GET: api/Todo/5
        [HttpGet("pretraga2/{id}")]
        public IActionResult GetOsoba(long id)
        {
            var o = _context.Osobe.Find(id);

            if (o == null)
            {
                return NotFound();
            }

            return Ok(o);
        }

        ////GET: api/Todo/5
        //[HttpGet("pretraga/{id}")]
        //public IActionResult GetOsoba(long id)
        //{
        //    var osoba = _context.Osobe;
        //    var osoQuery =
        //        osoba.Where(x => x.Id == id);

        //    return Ok(osoQuery);
        //}

        //GET: api/Todo/5
        [HttpGet("pretraga3/{ime}/{prezime}")]
        public IActionResult GetOsobaIme(string ime, string prezime)
        {
            IEnumerable<Osoba> OsobeIme = from o in _context.Osobe
                where o.Ime.Equals(ime) && o.Prezime.Equals(prezime)
                select o;

            if (!OsobeIme.Any())
            {
                return NotFound();
            }

            return Ok(OsobeIme.FirstOrDefault());
        }

        //GET: api/Todo/5
        [HttpGet("pretraga4/{emailAdresa}")]
        public IActionResult GetOsobaMejl(string emailAdresa)
        {
            var OsobeMejl = from o in _context.Osobe
                                //where o.EmailAdresa.Equals(emailAdresa)
                where o.EmailAdresa == emailAdresa
                            select o;

            if (!OsobeMejl.Any())
            {
                return NotFound();
            }

            return Ok(OsobeMejl.FirstOrDefault());
        }

        //[HttpGet("email/{email}")]
        //public IActionResult GetByEmail(string email)
        //{
        //    var getEmail = _context.Osobe;
        //    var getQuery = getEmail.Where(x => x.EmailAdresa.Equals(email));

        //    return Ok(getQuery.ToList());
        //}



        //GET: api/Todo/5
        [HttpGet("pretraga5/{datumRodjenja}")]
        public IActionResult GetOsobaDatum(DateTime datumRodjenja)
        {

            //var o = _context.Osobe;
            //var os = o.Where(op => ((DateTime.Compare(op.DatumRodjenja, datumRodjenja) == 0))).ToList();

            IEnumerable<Osoba> OsobeDatum = from o in _context.Osobe
                where o.DatumRodjenja.Day == datumRodjenja.Day
                      && o.DatumRodjenja.Month == datumRodjenja.Month
                      && o.DatumRodjenja.Year == datumRodjenja.Year
                                            select o;

            if (!OsobeDatum.Any())
            {
                return NotFound();
            }

            return Ok(OsobeDatum.FirstOrDefault());
        }

        //GET: api/Todo/5
        [HttpGet("pretraga6/{datumRodjenja}/{mestoRodjenja}")]
        public IActionResult GetOsobaDatumMesto(DateTime datumRodjenja, string mestoRodjenja)
        {
            IEnumerable<Osoba> OsobeMesto = from os in _context.Osobe
                where os.MestoRodjenja.Equals(mestoRodjenja)
                select os;

            IEnumerable<Osoba> OsobeIDatum = from o in OsobeMesto
                where o.DatumRodjenja.Day == datumRodjenja.Day
                      && o.DatumRodjenja.Month == datumRodjenja.Month
                      && o.DatumRodjenja.Year == datumRodjenja.Year
                select o;

            if (!OsobeIDatum.Any())
            {
                return NotFound();
            }

            return Ok(OsobeIDatum.FirstOrDefault());
        }


        //POST: api/Todo
        [HttpPost]
        public IActionResult PostOsoba(Osoba osoba)
        {
            _context.Osobe.Add(osoba);
            _context.SaveChanges();

            return Ok(osoba);
        }

        //PUT: api/Todo
        [HttpPut("{id}")]
        public IActionResult PutOsoba(long id, Osoba osoba)
        {

            var os = _context.Osobe.Find(id);

            if (os != null)
            {
                os.Ime = osoba.Ime;
                os.Prezime = osoba.Prezime;
                os.DatumRodjenja = osoba.DatumRodjenja;
                os.MestoRodjenja = osoba.MestoRodjenja;
                os.EmailAdresa = osoba.EmailAdresa;

                _context.SaveChanges();
                return Ok();
            }
           
            return NoContent();
        }

        //DELETE: api/Todo/5
        [HttpDelete("{id}")]
        public IActionResult DeleteTodoItem(long id)
        {
            var osoba = _context.Osobe.Find(id);

            if (osoba == null)
            {
                return NotFound();
            }

            _context.Osobe.Remove(osoba);
            _context.SaveChanges();

            return NoContent();
        }

        //!
        //GET
        //[HttpGet("proba")]
        //public IActionResult GetOsobe()
        //{
        //    var osobe = _context.Osobe.ToList();
        //    return Ok(osobe);
        //}
    }
}