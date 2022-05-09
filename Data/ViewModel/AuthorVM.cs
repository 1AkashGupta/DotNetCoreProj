using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreLearnProj.Data.ViewModel
{
    public class AuthorVM
    {
        public string fullName { get; set; }
    }

    public class AuthorVMByBook
    {
        public string fullName { get; set; }

        public List<string> bookTitles { get; set; }
    }
}
