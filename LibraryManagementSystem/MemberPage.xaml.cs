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
    /// Interaction logic for MemberPage.xaml
    /// </summary>
    public partial class MemberPage : Page
    {

        Repo repo = new Repo();
        BookDetails book = new BookDetails();
        public MemberPage()
        {
            InitializeComponent();
        }

        private void Searchbtn_Click(object sender, RoutedEventArgs e)
        {
            
            book = repo.GetBook(xSearchbookid.Text);
            if (book.BookID== null)
            {
                MessageBox.Show("This book is NOT available in the library");
            }
            else
            {
                xBookid.Text = book.BookID;
                xBookTitle.Text = book.BookTitle;
                xDescription.Text = book.Description;
                xAuthorname.Text = book.AuthorName;
                xPublicationdate.Text = book.PublicationYear;
                xEdition.Text = book.Edition;
                xPrice.Text = book.BookPrice;
                xBookCount.Text = book.BookCount;
                xAddnewbook.Visibility = Visibility.Visible;
                xIssuebtn.Visibility = Visibility.Visible;
                xReturnbtn.Visibility = Visibility.Visible;
            }
        }

        private void xIssuebtn_Click(object sender, RoutedEventArgs e)
        {
            xIssueborder.Visibility = Visibility.Visible;
            xAddnewbook.Visibility = Visibility.Collapsed;
        }

        private void xIssue_Click(object sender, RoutedEventArgs e)
        {
            BookIssueModel bookIssue = new BookIssueModel();
            int count = repo.getissuedcount(xName.Text);

            if (count < 5)
            {
                bookIssue.Name = xName.Text;
                bookIssue.BookID = book.BookID;
                bookIssue.IsIssued = true;
                bookIssue.IssuedDate = DateTime.Today.Date;
                repo.InsertIssusedDetails(bookIssue);
                MessageBox.Show("Issued Successfull");
            }
            else
            {
                MessageBox.Show("This Member is Already have a " + count + " No. of Books");
            }
        }

        private void xBookReturn_Click(object sender, RoutedEventArgs e)
        {
            repo.UpdateIssuedBooks(book.BookID, xReturnName.Text);
            MessageBox.Show("Returned Book :" + book.BookTitle);
        }

        private void xReturnbtn_Click(object sender, RoutedEventArgs e)
        {
            xRreturnborder.Visibility = Visibility.Visible;
        }
    }
}
