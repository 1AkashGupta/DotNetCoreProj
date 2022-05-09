using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreLearnProj.Data.Model
{
    public class Publisher
    {
        public int id { get; set; }
        public string name { get; set; }

        //Navigation property
        public List<Book> books { get; set; }
    }
}
