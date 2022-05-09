using DotNetCoreLearnProj.Data.Model;
using DotNetCoreLearnProj.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreLearnProj.Data.Services
{
    public class AuthorService
    {
        private AppDbContext _context;
        public AuthorService(AppDbContext context)
        {
            _context = context;
        }
        public void AddAuthor(AuthorVM author)
        {
            var _author = new Author()
            {
                fullName = author.fullName
            };
            _context.Authors.Add(_author);
            _context.SaveChanges();
        }

        public List<Author> GetAllAuthor()
        {
            return _context.Authors.ToList();
        }

        public AuthorVMByBook GetAuthorById(int id)
        {
            var authorVm = _context.Authors.Where(x => x.id==id).Select(n => new AuthorVMByBook() { 
            fullName = n.fullName,
            bookTitles = n.book_Authors.Select(x => x.book.title).ToList()
            }).FirstOrDefault();

            return authorVm;
        }
    }
}
