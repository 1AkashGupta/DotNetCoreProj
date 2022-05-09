using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreLearnProj.Data.Model
{
    public class Author
    {
        public int id { get; set; }
        public string fullName { get; set; }

        //Navigation Property
        public List<Book_Author> book_Authors { get; set; }
    }
}
