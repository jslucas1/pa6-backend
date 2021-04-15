using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using api.database;
using api.models;
using api.interfaces;
using Microsoft.AspNetCore.Cors;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class booksController : ControllerBase
    {
        // GET: api/books
        [EnableCors("AnotherPolicy")]
        [HttpGet]
        public List<Book> Get()
        {
            ReadBook readObj = new ReadBook();
            return readObj.GetAllBooks();
        }

        // GET: api/books/5
        [EnableCors("AnotherPolicy")]
        [HttpGet("{cwid}", Name = "Get")]
        public List<Book> Get(string cwid)
        {
            ReadBook readObj = new ReadBook();
            return readObj.GetBooksByCwid(cwid);
        }

        // POST: api/books
        [EnableCors("AnotherPolicy")]
        [HttpPost("{cwid}")]
        public void Post(string cwid, [FromBody] Book value)
        {
            value.Cwid = cwid;
            value.SaveAction.CreateBook(value);
        }

        // PUT: api/books/5
        [EnableCors("AnotherPolicy")]
        [HttpPut("{cwid}/{id}")]
        public void Put(string cwid, int id, [FromBody] Book value)
        {
            Console.WriteLine(value.Title + " " + value.Id);
            value.SaveAction.Save(value);
        }

        // DELETE: api/books/5
        [EnableCors("AnotherPolicy")]
        [HttpDelete("{cwid}/{id}")]
        public void Delete(string cwid, int id)
        {
            Console.WriteLine("Made it to the delete with cwid " + cwid + " and id " + id);
            IDeleteBook delete = new DeleteBook();
            delete.Delete(id);
        }
    }
}
