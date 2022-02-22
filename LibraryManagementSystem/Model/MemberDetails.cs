using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    public class MemberDetails
    {
        public string MemberID { get; set; }
        public string UserName { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public DateTime JoinDate { get; set; }


        public MemberDetails()
        {

        }

        public MemberDetails( string id,string name,string age,string gender,DateTime joindate)
        {
            this.MemberID = id;
            this.UserName = name;
            this.Age = age;
            this.Gender = gender;
            this.JoinDate = joindate;
        }
    }
}
