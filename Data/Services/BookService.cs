using DotNetCoreLearnProj.Data.Model;
using DotNetCoreLearnProj.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreLearnProj.Data.Services
{
    public class BookService
    {
        private AppDbContext _context;
        public BookService(AppDbContext context)
        {
            _context = context;            
        }

        public void AddBookWithAuthors(BookVM book)
        {
            var _book = new Book()
            {
                title = book.title,
                Description = book.Description,
                IsRead = book.IsRead,
                DateRead = book.IsRead ? book.DateRead.Value : null,
                Rate = book.IsRead ? book.Rate.Value : null,
                gener = book.gener,
                CoverUrl = book.CoverUrl,
                DateAdded = DateTime.Now,
                publisherId = book.PublisherId

            };
            _context.Books.Add(_book);
            _context.SaveChanges();

            foreach (var id in book.authorId)
            {
                var _book_author = new Book_Author
                {
                    bookId = _book.Id,
                    authorId = id
                };
                _context.Book_Authors.Add(_book_author);
                _context.SaveChanges();
            }
        }

        public List<Book> GetAllBook()
        {
            return _context.Books.ToList();
        }

        public BookWithAuthorVM GetBookById(int bookId)
        {
            //return _context.Books.FirstOrDefault(x => x.Id == bookId);
            var bookWithAuthors = _context.Books.Where(x => x.Id ==bookId).Select(book => new BookWithAuthorVM
            {
                title = book.title,
                Description = book.Description,
                IsRead = book.IsRead,
                DateRead = book.IsRead ? book.DateRead.Value : null,
                Rate = book.IsRead ? book.Rate.Value : null,
                gener = book.gener,
                CoverUrl = book.CoverUrl,   
                PublisherName = book.publisher.name,
                authorName = book.book_Authors.Select(n=>n.author.fullName).ToList()

            }).FirstOrDefault();


            return bookWithAuthors;
        }

        public Book UpdateBookById(int bookId, BookVM book)
        {
            var _book =_context.Books.FirstOrDefault(x => x.Id == bookId);
            if(_book != null)
            {
                _book.title = book.title;
                _book.Description = book.Description;
                _book.IsRead = book.IsRead;
                _book.Rate = book.Rate;
                _book.DateRead = book.DateRead;
                _book.gener = book.gener;
                _book.CoverUrl = _book.CoverUrl;

                _context.SaveChanges();
            }

            return _book;
        }
        public bool DeleteBookById(int bookId)
        {
            var _book = _context.Books.FirstOrDefault(x => x.Id == bookId);
            if(_book != null)
            {
                _context.Books.Remove(_book);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
