using System.Collections.Generic;
using System.Linq;
using BookLibrary.Models;
using Newtonsoft.Json;

namespace BookLibrary.DAL
{
    public class BookService
    {
        private readonly List<Book> BookList;

        public BookService()
        {
            BookList = JsonConvert.DeserializeObject<List<Book>>(JSONDataHandler.LoadJSONData());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void RemoveBook(int id)
        {
            var book = BookList.Find(b => b.Id == id);
            BookList.Remove(book);
        }

        /// <summary>
        /// Saves one book to the JSON stream
        /// </summary>
        /// <param name="book"></param>
        /// <returns>True if successful, false if failed.</returns>
        public Book SaveBook(Book book)
        {
 
            book.Id = BookList.Max(b => b.Id) + 1; 
            BookList.Add(book);
           
            JSONDataHandler.SaveJSONData(BookList);

            return book;
        }

        public bool UpdateBook(Book book)
        {
            if (BookList.Contains(book))
            {
                var index = BookList.FindIndex(b => b.Id == book.Id);
                BookList[index] = book;
                JSONDataHandler.SaveJSONData(BookList);
                return true;
            }
     
            return false;
        }

        /// <summary>
        /// Returns all the books in the JSON file
        /// </summary>
        /// <returns>a list of books</returns>
        public List<Book> GetAllBooks()
        {
            return BookList;
        }
        /// <summary>
        /// Returns one book by ID
        /// </summary>
        /// <param name="id">The ID of the book to search for</param>
        /// <returns></returns>
        public Book GetBook(int id)
        {
            return BookList.Find(b => b.Id == id);
        }
    }
}
