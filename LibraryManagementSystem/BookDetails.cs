using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    class BookDetails
    {
        public string BookID { get; set; }
        public string BookTitle { get; set; }
        public string Description { get; set; }
        public string AuthorName { get; set; }
        public string PublicationYear { get; set; }
        public string Edition { get; set; }
        public string BookPrice { get; set; }
        public string BookCount { get; set; }
        public DateTime EntrtDate { get; set; }
    }
}
