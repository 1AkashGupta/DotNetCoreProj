using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreLearnProj.Data.ViewModel
{
    public class BookVM
    {
        public string title { get; set; }
        public string Description { get; set; }
        public bool IsRead { get; set; }
        public DateTime? DateRead { get; set; }
        public int? Rate { get; set; }
        public string gener { get; set; }
        public string CoverUrl { get; set; }

        public int PublisherId { get; set; }

        public List<int> authorId { get; set; }
    }

    public class BookWithAuthorVM
    {
        public string title { get; set; }
        public string Description { get; set; }
        public bool IsRead { get; set; }
        public DateTime? DateRead { get; set; }
        public int? Rate { get; set; }
        public string gener { get; set; }
        public string CoverUrl { get; set; }

        public string PublisherName { get; set; }

        public List<string> authorName { get; set; }
    }
}
