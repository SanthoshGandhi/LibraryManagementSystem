using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    class BookIssueModel
    {
        public string MemberID { get; set; }
        public string BookID { get; set; }
        public bool IsIssued { get; set; }
        public DateTime IssuedDate { get; set; }
        public DateTime ReturnDate { get; set; }

        public BookIssueModel()
        {

        }

        public BookIssueModel(string memberid,string bookid,bool isisssued,DateTime issueddate,DateTime returndate)
        {
            this.MemberID = memberid;
            this.BookID = bookid;
            this.IsIssued = isisssued;
            this.IssuedDate = issueddate;
            this.ReturnDate = returndate;
        }
    }
}
