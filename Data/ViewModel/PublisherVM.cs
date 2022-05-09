using DotNetCoreLearnProj.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreLearnProj.Data.ViewModel
{
    public class PublisherVM
    {
        public string name { get; set; }
    }
    public class PublisherBookAuthorVM
    {
        public string name { get; set; }

        public List<BookAuthorVM> bookAuthors { get; set; }
    }

    public class BookAuthorVM
    {
        public string bookName { get; set; }

        public List<string> bookAuthors { get; set; }
    }
}
