using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using BookLibrary.DAL;
using BookLibrary.Models;

namespace BookHandler.Controllers
{
    public class BookController : ApiController
    {
        private readonly BookService BookService;

        public BookController()
        {
            BookService = new BookService();
        }

        // GET: api/Book
        public IEnumerable<Book> GetBooks()
        {
            var books = BookService.GetAllBooks();

            return books;
        }

        // GET: api/Books/5
        [ResponseType(typeof(Book))]
        public IHttpActionResult GetBook(int id)
        {
            var book = BookService.GetBook(id);
            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }


        [ResponseType(typeof(Book))]
        public IHttpActionResult PostBook(Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var savedBook = BookService.SaveBook(book);

            var dto = new Book
            {
                Id = savedBook.Id,
                Name = savedBook.Name,
                Author = savedBook.Author,
                Read = savedBook.Read,
                Rank = savedBook.Rank
            };

            return CreatedAtRoute("DefaultApi", new { id = book.Id }, dto);
        }

        // PUT: api/Books/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBook(int id, Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != book.Id)
            {
                return BadRequest();
            }

            BookService.UpdateBook(book);


            return StatusCode(HttpStatusCode.NoContent);
        }

        [ResponseType(typeof(Book))]
        public IHttpActionResult DeleteBook(int id)
        {
            try
            {
                BookService.RemoveBook(id);
            }
            catch (Exception)
            {
                
                throw;
            }
      
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
