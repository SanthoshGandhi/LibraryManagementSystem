using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    class Repo
    {
        static string connectionstring = "Data Source=.;Initial Catalog=LMSystem;Integrated Security=True";

        public List<LoginModel> GetLoginDetails(string Log_as)
        {
            List<LoginModel> log = new List<LoginModel>();
            SqlConnection con = new SqlConnection(connectionstring);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            if (Log_as == "ADMIN")
            {
                cmd.CommandText = "Select * from Admin";
            }
            else
            {
                cmd.CommandText = "Select UserName,Password from MemberDetails";
            }
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                log.Add(new LoginModel { Username = reader.GetString(0), Password = reader.GetString(1) });
            }
            con.Close();
            return log;
        }

        public void InsertBookDetails(BookDetails books)
        {
            SqlConnection con = new SqlConnection(connectionstring);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Insert Into BookDetails(ID,Title,Description,AuthorName,PublicationYear,Edition,Price,Count,EntryDate) values(@ID,@Title,@Description,@Authorname,@Publication,@edition,@price,@Count,@EntryDate)";
            //foreach (BookDetails item in books)
            //{
            //    cmd.Parameters.AddWithValue("@ID", item.BookID);
            //    cmd.Parameters.AddWithValue("@Title", item.BookTitle);
            //    cmd.Parameters.AddWithValue("@Description", item.Description);
            //    cmd.Parameters.AddWithValue("@Authorname", item.AuthorName);
            //    cmd.Parameters.AddWithValue("@Publication", item.PublicationYear);
            //    cmd.Parameters.AddWithValue("@edition", item.Edition);
            //    cmd.Parameters.AddWithValue("@price", item.BookPrice);
            //    cmd.Parameters.AddWithValue("@Count", item.BookCount);
            //    cmd.Parameters.AddWithValue("@EntryDate", item.EntrtDate);

            cmd.Parameters.AddWithValue("@ID", books.BookID);
            cmd.Parameters.AddWithValue("@Title", books.BookTitle);
            cmd.Parameters.AddWithValue("@Description", books.Description);
            cmd.Parameters.AddWithValue("@Authorname", books.AuthorName);
            cmd.Parameters.AddWithValue("@Publication", books.PublicationYear);
            cmd.Parameters.AddWithValue("@edition", books.Edition);
            cmd.Parameters.AddWithValue("@price", books.BookPrice);
            cmd.Parameters.AddWithValue("@Count", books.BookCount);
            cmd.Parameters.AddWithValue("@EntryDate", books.EntrtDate);


            //cmd.Parameters[0].Value = ;
            //cmd.Parameters[1].Value = ;
            //cmd.Parameters[2].Value = ;
            //cmd.Parameters[3].Value = ;
            //cmd.Parameters[4].Value = ;
            //cmd.Parameters[5].Value = ;
            //cmd.Parameters[6].Value = ;
            //cmd.Parameters[7].Value = ;
            //cmd.Parameters[8].Value = ;

            cmd.ExecuteNonQuery();
            // }
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
            cmd.CommandText = "Delete from BookDetails where id = '" + id + "'";
            cmd.ExecuteNonQuery();
            con.Close();
        }


        public void InsertMemberDetails(MemberDetails details)
        {
            SqlConnection con = new SqlConnection(connectionstring);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Insert into MemberDetails values ('" + details.MemberID + "','" + details.UserName + "','" + details.Password + "','" + details.Age + "','" + details.Gender + "','" + details.JoinDate + "')";
            cmd.ExecuteNonQuery();
            con.Close();
        }


        public void RemoveMember(string ID)
        {
            SqlConnection con = new SqlConnection(connectionstring);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Delete from MemberDetails where id = '" + ID + "'";
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
            while(reader.Read())
            {
                books.Add(new BookDetails { BookID = reader.GetString(0), BookTitle = reader.GetString(1), Description = reader.GetString(2), AuthorName = reader.GetString(3), PublicationYear = reader.GetString(4), Edition = reader.GetString(5), BookPrice = reader.GetString(6), BookCount = reader.GetString(7), EntrtDate = reader.GetDateTime(8) });
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
                members.Add(new MemberDetails { MemberID = reader.GetString(0), UserName = reader.GetString(1), Password = reader.GetString(2), Age = reader.GetString(3), Gender = reader.GetString(4), JoinDate = reader.GetDateTime(5) });
            }
            con.Close();
            return members;
        }

        public BookDetails GetBook(string id)
        {
            BookDetails book = new BookDetails();
            SqlConnection con = new SqlConnection(connectionstring);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from BookDetails where Id ='" + id + "'";
            SqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                book.BookID = reader.GetString(0);
                book.BookTitle = reader.GetString(1);
                book.Description = reader.GetString(2);
                book.AuthorName = reader.GetString(3);
                book.PublicationYear = reader.GetString(4);
                book.Edition = reader.GetString(5);
                book.BookPrice = reader.GetString(6);
                book.BookCount = reader.GetString(7);
            }
            con.Close();
            return book;
        }

        public void InsertIssusedDetails(BookIssueModel book)
        {
            SqlConnection con = new SqlConnection(connectionstring);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            int val = book.IsIssued ? 1 : 0;
            cmd.CommandText = "Insert into BookIssuedTable values ('" + book.Name + "','" + book.BookID + "','" + val + "','" + book.IssuedDate.ToString("yyyy-MM-dd") + "')";
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public int getissuedcount(string name)
        {
            SqlConnection con = new SqlConnection(connectionstring);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Select Count(Customer) from BookIssuedTable where IsIssued = 1 and Customer = '"+name+"'";
            int count = (int)cmd.ExecuteScalar();
            con.Close();
            return count;
        }

        public void UpdateIssuedBooks(string bookid , string name)
        {
            SqlConnection con = new SqlConnection(connectionstring);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "update BookIssuedTable set IsIssued = '0' where Customer = '" + name + "' and BookID = '" + bookid + "'";
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
