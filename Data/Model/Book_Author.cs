using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreLearnProj.Data.Model
{
    public class Book_Author
    {
        public int id { get; set; }
        public int bookId { get; set; }
        public Book book { get; set; }
        public int authorId { get; set; }
        public Author author { get; set; }

        //Navigation Property

    }
}
