using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    class Repo
    {
        public string connectionstring = "Data Source=.;Initial Catalog=LMSystem;Integrated Security=True";

        public bool GetLoginDetails(string Log_as,LoginModel model)
        {
            bool flag = true;
            SqlConnection con = new SqlConnection(connectionstring);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            if (Log_as == "ADMIN")
            {
                cmd.CommandText = "SELECT UserName FROM Admin WHERE username = '"+model.Username+"' AND password = '"+model.Password+"'";
            }
            else
            {
                cmd.CommandText = "SELECT UserName FROM MemberDetails WHERE username = '" + model.Username + "' AND password = '" + model.Password + "'";
            }
            if(cmd.ExecuteScalar() == null)
            {
                flag = false;
            }
            return  flag;
        }

        public void InsertBookDetails(BookDetails books)
        {
            SqlConnection con = new SqlConnection(connectionstring);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Insert Into BookDetails(ID,Title,Description,AuthorName,PublicationYear,Edition,Price,Count,EntryDate,Active) values(@ID,@Title,@Description,@Authorname,@Publication,@edition,@price,@Count,@EntryDate,@Active)";

            cmd.Parameters.AddWithValue("@ID", books.BookID);
            cmd.Parameters.AddWithValue("@Title", books.BookTitle);
            cmd.Parameters.AddWithValue("@Description", books.Description);
            cmd.Parameters.AddWithValue("@Authorname", books.AuthorName);
            cmd.Parameters.AddWithValue("@Publication", books.PublicationYear);
            cmd.Parameters.AddWithValue("@edition", books.Edition);
            cmd.Parameters.AddWithValue("@price", books.BookPrice);
            cmd.Parameters.AddWithValue("@Count", books.BookCount);
            cmd.Parameters.AddWithValue("@EntryDate", books.EntryDate);

            int val = books.ActiveStatus ? 1 : 0;
            cmd.Parameters.AddWithValue("@Active", books.ActiveStatus);

            cmd.ExecuteNonQuery();
            con.Close();
        }

        //Number of created ID Count
        public int Count(string CountFor)
        {
            int count = 0;
            string month = DateTime.Today.Month.ToString();
            SqlConnection con = new SqlConnection(connectionstring);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            if (CountFor == "BOOK")
            {
                cmd.CommandText = "select count(*) from BookDetails where Month(EntryDate) = '" + month + "'";
            }
            else if (CountFor == "MEMBER")
            {
                cmd.CommandText = "select count(*) from MemberDetails where Month(JoiningDate) = '" + month + "'";
            }
            count = (int)cmd.ExecuteScalar();
            con.Close();
            return count;
        }

        public void RemoveBook(string id)
        {
            SqlConnection con = new SqlConnection(connectionstring);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Update BookDetails set Active = '0' where id = '" + id + "'";
            cmd.ExecuteNonQuery();
            con.Close();
        }


        public void InsertMemberDetails(MemberDetails details,string pass)
        {
            SqlConnection con = new SqlConnection(connectionstring);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Insert into MemberDetails values ('" + details.MemberID + "','" + details.UserName + "','"+pass+"','" + details.Age + "','" + details.Gender + "','" + details.JoinDate + "','1')";
            cmd.ExecuteNonQuery();
            con.Close();
        }


        public void RemoveMember(string ID)
        {
            SqlConnection con = new SqlConnection(connectionstring);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Update MemberDetails set Active = '0' where id = '" + ID + "'";
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public List<BookDetails> GetBookDetails()
        {
            List<BookDetails> books = new List<BookDetails>();
            SqlConnection con = new SqlConnection(connectionstring);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Select * from BookDetails";
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                books.Add(new BookDetails { BookID = reader.GetString(0), BookTitle = reader.GetString(1), Description = reader.GetString(2), AuthorName = reader.GetString(3), PublicationYear = reader.GetInt32(4), Edition = reader.GetString(5), BookPrice = reader.GetInt32(6), BookCount = reader.GetInt32(7), EntryDate = reader.GetDateTime(8) ,ActiveStatus = reader.GetBoolean(9)});
            }

            con.Close();
            return books;
        }


        public List<MemberDetails> GetMemberDetails()
        {
            List<MemberDetails> members = new List<MemberDetails>();
            SqlConnection con = new SqlConnection(connectionstring);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Select * from MemberDetails";
            SqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                members.Add( new MemberDetails (reader.GetString(0), reader.GetString(1),reader.GetString(3), reader.GetString(4), reader.GetDateTime(5) ));
            }
            con.Close();
            return members;
        }

        public BookDetails GetBook(string Name)
        {
            BookDetails book = new BookDetails();
            SqlConnection con = new SqlConnection(connectionstring);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from BookDetails where Title ='" + Name + "' and Active = '1'";
            SqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                book.BookID = reader.GetString(0);
                book.BookTitle = reader.GetString(1);
                book.Description = reader.GetString(2);
                book.AuthorName = reader.GetString(3);
                book.PublicationYear = reader.GetInt32(4);
                book.Edition = reader.GetString(5);
                book.BookPrice = reader.GetInt32(6);
                book.BookCount = reader.GetInt32(7);
            }
            con.Close();
            return book;
        }

        public void InsertIssusedDetails(BookIssueModel book)
        {
            bool flag = false;
            SqlConnection con = new SqlConnection(connectionstring);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT CAST(CASE WHEN COUNT(*) > 0 THEN 1 ELSE 0 END AS BIT) FROM BookIssuedTable WHERE BookId = '" + book.BookID + "' and MemberID = '"+book.MemberID+"'";
            flag = (bool)cmd.ExecuteScalar();
            if(flag)
            {
               cmd.CommandText = "Update BookIssuedTable set IsIssued = '1' where BookId = '"+book.BookID+"'";
                cmd.ExecuteNonQuery();
            }
            else
            {
                int val = book.IsIssued ? 1 : 0;
                cmd.CommandText = "Insert into BookIssuedTable values ('" + book.MemberID + "','" + book.BookID + "','" + val + "','" + book.IssuedDate.ToString("yyyy-MM-dd") + "','" + book.ReturnDate.ToString("yyyy-MM-dd") + "')";
                cmd.ExecuteNonQuery();
            }
            con.Close();
        }

        public int getissuedcount(string name)
        {
            SqlConnection con = new SqlConnection(connectionstring);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Select Count(MemberID) from BookIssuedTable where IsIssued = 1 and MemberID = '" + name +"'";
            int count = (int)cmd.ExecuteScalar();
            con.Close();
            return count;
        }

        public void UpdateIssuedBooks(string Memberid , string bookid)
        {
            SqlConnection con = new SqlConnection(connectionstring);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "update BookIssuedTable set IsIssued = '0' where MemberID = '" + Memberid + "' and BookID = '" + bookid + "'";
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public ObservableCollection<BookIssueModel> getissuedbooks()
        {
            ObservableCollection<BookIssueModel> issuebooks = new ObservableCollection<BookIssueModel>();
            SqlConnection con = new SqlConnection(connectionstring);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Select * from BookIssuedTable where IsIssued = '1'";
            SqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                issuebooks.Add(new BookIssueModel(reader.GetString(0), reader.GetString(1), reader.GetBoolean(2),reader.GetDateTime(3),reader.GetDateTime(4)));
            }
            con.Close();
            return issuebooks;
        }


        public MemberDetails GetMember(string name , string pass)
        {
            MemberDetails member = new MemberDetails();
            SqlConnection con = new SqlConnection(connectionstring);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Select * from MemberDetails where Username = '" + name + "' and Password ='" + pass + "'";
            SqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                member = new MemberDetails(reader.GetString(0), reader.GetString(1), reader.GetString(3), reader.GetString(4), reader.GetDateTime(5));

            }
            con.Close();
            return member;
        }
    }
}
