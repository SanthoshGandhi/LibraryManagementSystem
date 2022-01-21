using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LibraryManagementSystem
{
    /// <summary>
    /// Interaction logic for AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        List<BookDetails> Books = new List<BookDetails>();
        Repo repo = new Repo();
        public int Count;

        public AdminPage()
        {
            InitializeComponent();
        }

        private void xaddbook_Click(object sender, RoutedEventArgs e)
        {
            BookDetails book = new BookDetails();
            Count = 0;
            Count = repo.Count("BOOK");
            string id = CreateID("BOOK");
            book = new BookDetails { BookID = id, BookTitle = xBookTitle.Text, Description = xDescription.Text, AuthorName = xAuthorname.Text, PublicationYear = Convert.ToInt32(xPublicationdate.Text), Edition = xEdition.Text, BookPrice = Convert.ToInt32(xPrice.Text), BookCount = Convert.ToInt32(xBookCount.Text), EntryDate = DateTime.Today.Date,ActiveStatus = true };


            repo.InsertBookDetails(book);
            MessageBox.Show("Successfully Added");
            xBookTitle.Text = null;
            xDescription.Text = null;
            xAuthorname.Text = null;
            xPublicationdate.Text = null;
            xEdition.Text = null;
            xPrice.Text = null;
            xBookCount.Text = null;

        }

        private void xinsertbooks_Click(object sender, RoutedEventArgs e)
        {
        }

        public string CreateID(string IDFor)
        {
            string id = string.Empty;
            Count = Count + 1;
            if (IDFor == "MEMBER")
            {
                id = "MNO" + DateTime.Today.ToString("yy") + DateTime.Today.ToString("MM") + Count.ToString();
            }
            else if(IDFor == "BOOK")
            {
                id = "BNO" + DateTime.Today.ToString("yy") + DateTime.Today.ToString("MM") + Count.ToString();
            }
            return id;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            xAddnewbook.Visibility = Visibility.Visible;
            xRemovebooks.Visibility = Visibility.Collapsed;
            xViewBooks.Visibility = Visibility.Collapsed;
            xAddmember.Visibility = Visibility.Collapsed;
            xRemovemember.Visibility = Visibility.Collapsed;
            xViewMember.Visibility = Visibility.Collapsed;

        }

        private void xBookremove_Click(object sender, RoutedEventArgs e)
        {
            repo.RemoveBook(xbookID.Text);
            MessageBox.Show("Removed");
            xbookID.Text = null;

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            xRemovebooks.Visibility = Visibility.Visible;
            xAddnewbook.Visibility = Visibility.Collapsed;
            xViewBooks.Visibility = Visibility.Collapsed;
            xAddmember.Visibility = Visibility.Collapsed;
            xRemovemember.Visibility = Visibility.Collapsed;
            xViewMember.Visibility = Visibility.Collapsed;
        }

        private void xaddmember_Click(object sender, RoutedEventArgs e)
        {
            MemberDetails member = new MemberDetails();
            Count = 0;
            Count = repo.Count("MEMBER");
            member.MemberID = CreateID("MEMBER");
            member.UserName = xUserName.Text;
            member.Password = xPassword.Text;
            member.Age = xAge.Text;
            member.Gender = xGender.Text;
            member.JoinDate = Convert.ToDateTime(xJoiningdate.Text);
            member.ActiveStatus = true;

            repo.InsertMemberDetails(member);
            MessageBox.Show("Successfully Added");
            xUserName.Text = null;
            xPassword.Text = null;
            xAge.Text = null;
            xGender.Text = null;

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            xAddnewbook.Visibility = Visibility.Collapsed;
            xRemovebooks.Visibility = Visibility.Collapsed;
            xViewBooks.Visibility = Visibility.Collapsed;
            xAddmember.Visibility = Visibility.Visible;
            xRemovemember.Visibility = Visibility.Collapsed;
            xViewMember.Visibility = Visibility.Collapsed;
        }

        private void xMemberremove_Click(object sender, RoutedEventArgs e)
        {
            repo.RemoveMember(xmemberID.Text);
            MessageBox.Show("Removed");
            xmemberID.Text = null;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            xAddnewbook.Visibility = Visibility.Collapsed;
            xRemovebooks.Visibility = Visibility.Collapsed;
            xViewBooks.Visibility = Visibility.Collapsed;
            xAddmember.Visibility = Visibility.Collapsed;
            xRemovemember.Visibility = Visibility.Visible;
            xViewMember.Visibility = Visibility.Collapsed;
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            xAddnewbook.Visibility = Visibility.Collapsed;
            xRemovebooks.Visibility = Visibility.Collapsed;
            xViewBooks.Visibility = Visibility.Visible;
            xAddmember.Visibility = Visibility.Collapsed;
            xRemovemember.Visibility = Visibility.Collapsed;
            xViewMember.Visibility = Visibility.Collapsed;

            List<BookDetails> details= repo.GetBookDetails();

            xBookdetails.ItemsSource = details;



        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            xAddnewbook.Visibility = Visibility.Collapsed;
            xRemovebooks.Visibility = Visibility.Collapsed;
            xViewBooks.Visibility = Visibility.Collapsed;
            xAddmember.Visibility = Visibility.Collapsed;
            xRemovemember.Visibility = Visibility.Collapsed;
            xViewMember.Visibility = Visibility.Visible;

            List<MemberDetails> details = repo.GetMemberDetails();

            xMemberdetails.ItemsSource = details;
        }
    }
}
