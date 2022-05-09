using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreLearnProj.Data.Model
{
    public class Book
    {
        public int Id { get; set; }
        public string title { get; set; }
        public string Description { get; set; }
        public bool IsRead { get; set; }
        public DateTime? DateRead { get; set; }
        public int? Rate { get; set; }
        public string gener { get; set; }
        public string CoverUrl { get; set; }
        public DateTime DateAdded { get; set; }

        //Navigation Property
        public int publisherId { get; set; }
        public Publisher publisher { get; set; }
        public List<Book_Author> book_Authors { get; set; }
    }
}
