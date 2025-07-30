using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KitapYonetim.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        static private List<Book> _books = new List<Book>
        {
            new Book { Id=1, Title= "Silmarillion", Author= "John Ronald Reuel Tolkien" ,PublishedYear= 1977 },
            new Book { Id=2, Title= "Hobbit", Author= "John Ronald Reuel Tolkien" ,PublishedYear= 1937 }
        };

        

        

        [HttpGet]
        public IEnumerable<Book> GetBooks()
        {
            return _books;
        }

        //[HttpGet("{id}")]                                 *************************** id ye göre tek kitap listeleme************

        //public Book? GetBook(int id)
        //{
        //    return  _books.Find(a => a.Id == id);
        //}

        [HttpPost]
        public IActionResult AddBook(string title, string author, int publishedYear)
        {
            var item = new Book
            {
                Id = _books.Count + 1,
                Title = title,
                Author = author,
                PublishedYear = publishedYear
            };

            _books.Add(item);
            return Ok(item);
        }

        //[HttpPut("{id}")]                                 *************************** id ye göre tek kitap güncelleme************

        //public void UpdateBook(int id,string title,string author,int publishedYear)
        //{
        //    var index = _books.FindIndex(a => a.Id == id);

        //    if(index==-1)
        //    {
        //        return;
        //    }

        //    _books[index].Title = title;
        //    _books[index].Author = author;
        //    _books[index].PublishedYear = publishedYear;

        //}

        [HttpDelete("{id}")]
        public void DeleteBook(int id)
        {
            var item = _books.Find(a => a.Id == id);
            if(item!=null)
            {
                _books.Remove(item);
            }   
        }
    

    }
}
