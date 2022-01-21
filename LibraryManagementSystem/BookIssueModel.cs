using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    class BookIssueModel
    {
        public string Name { get; set; }
        public string BookID { get; set; }
        public bool IsIssued { get; set; }
        public DateTime IssuedDate { get; set; }
    }
}
