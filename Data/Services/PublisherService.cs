using DotNetCoreLearnProj.Data.Model;
using DotNetCoreLearnProj.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreLearnProj.Data.Services
{
    public class PublisherService
    {

        private AppDbContext _context;
        public PublisherService(AppDbContext context)
        {
            _context = context;
        }
        public Publisher AddPublisher(PublisherVM publisher)
        {
            var _publisher = new Publisher()
            {
                name = publisher.name
            };
            _context.publishers.Add(_publisher);
            _context.SaveChanges();
            return _publisher;
        }
        public Publisher getPublisherById(int id)
        {
            return _context.publishers.FirstOrDefault(x =>x.id==id);
        }
        public PublisherBookAuthorVM GetPublisherData(int id)
        {
            var publisher = _context.publishers.Where(x =>x.id==id).Select(p => new PublisherBookAuthorVM()
            {
                name = p.name,
                bookAuthors = p.books.Select(x => new BookAuthorVM()
                { 
                    bookName = x.title,
                    bookAuthors = x.book_Authors.Select(y => y.author.fullName).ToList()
                }).ToList()

            }).FirstOrDefault();

            return publisher;
        }
        public bool DeletePublisherById(int publisherId)
        {
            var _publisher = _context.publishers.FirstOrDefault(x => x.id == publisherId);
            if (_publisher != null)
            {
                _context.publishers.Remove(_publisher);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
