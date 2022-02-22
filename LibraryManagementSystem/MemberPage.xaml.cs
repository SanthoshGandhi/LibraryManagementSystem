using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        ObservableCollection<BookDetails> SelectedBooks = new ObservableCollection<BookDetails>();
        MemberDetails Member = new MemberDetails();
        Repo repo = new Repo();
        BookDetails book = new BookDetails();
        ObservableCollection<BookIssueModel> Issuedbooks = new ObservableCollection<BookIssueModel>();
        public MemberPage()
        {
            InitializeComponent();
            Issuedbooks = repo.getissuedbooks();
            xSelectedbooksView.ItemsSource = SelectedBooks;

        }

        public MemberPage(MemberDetails memberdetail)
        {
            InitializeComponent();
            Member = memberdetail;
            xSelectedbooksView.ItemsSource = SelectedBooks;
            //xIssuedBookList.ItemsSource = Issuedbooks;
            LoadData();
        }

        void LoadData()
        {
            Issuedbooks = repo.getissuedbooks();
            xIssuedBookList.Items.Clear();
            foreach (BookIssueModel Book in Issuedbooks)
            {
                xIssuedBookList.Items.Add(Book);
            }
        }

        private void Searchbtn_Click(object sender, RoutedEventArgs e)
        {

            book = repo.GetBook(xSearchbookid.Text);
            if (book.BookID == null)
            {
                MessageBox.Show("This book is NOT available in the library");
            }
            else
            {
                xBookid.Text = book.BookID;
                xBookTitle.Text = book.BookTitle;
                xDescription.Text = book.Description;
                xAuthorname.Text = book.AuthorName;
                xPublicationdate.Text = book.PublicationYear.ToString();
                xEdition.Text = book.Edition;
                xPrice.Text = book.BookPrice.ToString();
                xBookCount.Text = book.BookCount.ToString();
                xAddnewbook.Visibility = Visibility.Visible;
                xselectedAddbtn.Visibility = Visibility.Visible;
                xSelectedbooksView.Visibility = Visibility.Visible;
            }
        }

        private void xIssuebtn_Click(object sender, RoutedEventArgs e)
        {
        }

        private void xIssue_Click(object sender, RoutedEventArgs e)
        {
            BookIssueModel bookIssue = new BookIssueModel();
            int count = repo.getissuedcount(Member.MemberID);

            if (count < 5 )
            {
                if (SelectedBooks.Count + count <= 5)
                {
                    foreach (var item in SelectedBooks)
                    {
                        bookIssue.MemberID = Member.MemberID;
                        bookIssue.BookID = item.BookID;
                        bookIssue.IsIssued = true;
                        bookIssue.IssuedDate = DateTime.Today.Date;
                        bookIssue.ReturnDate = bookIssue.IssuedDate.AddDays(30);
                        repo.InsertIssusedDetails(bookIssue);
                    }
                    LoadData();
                    ReloadBookDetailsView();
                    MessageBox.Show("Issued Successfull");
                }
                else
                {
                    MessageBox.Show("By Library Rules User can have only 5 books and This User Aldready have a "+ count +" Book(s) so please select "+((SelectedBooks.Count + count ) - 5) +" Book(s) or Return those book(s).");
                }
            }
            else
            {
                MessageBox.Show("Already have a " + count + " No. of Books.");
            }
        }


        void ReloadBookDetailsView()
        {
            xAddnewbook.Visibility = Visibility.Collapsed;
            SelectedBooks.Clear();
        }


        private void xselectedAddbtn_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedBooks.Count < 5)
            {
                bool flag = SelectedBooks.Any(temp => temp.BookID == book.BookID);
                if (!flag)
                {
                    SelectedBooks.Add(book);
                    xselectedAddbtn.Visibility = Visibility.Collapsed;
                    xIssuebtn.Visibility = Visibility.Visible;
                }
                else
                {
                    MessageBox.Show("Aldready Selected this book " + book.BookTitle);
                }
            }
            else
            {
                xselectedAddbtn.Visibility = Visibility.Collapsed;
            }

        }

        BookIssueModel Returnbook = new BookIssueModel();
        private void xReturnbtn_Click(object sender, RoutedEventArgs e)
        {
            repo.UpdateIssuedBooks(Member.MemberID, Returnbook.BookID);
            Issuedbooks.Remove(Returnbook);
            xIssuedBookList.Items.Clear();
            foreach (BookIssueModel item in Issuedbooks)
            {
                xIssuedBookList.Items.Add(item);
            }
            xAddnewbook.Visibility = Visibility.Collapsed;
            MessageBox.Show("Returned");
        }


       

        //Logout
        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new LoginPage());
        }

        private void xIssuedBookList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int Index = 0;
            if(xIssuedBookList.SelectedIndex!= -1)
            {
                Index = xIssuedBookList.SelectedIndex;
            }

            Returnbook = Issuedbooks[Index];

        }

        private void xSelectedbooksView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (xSelectedbooksView.SelectedIndex != -1)
            {
                SelectedBooks.Remove(SelectedBooks[xSelectedbooksView.SelectedIndex]);
            }
            if(SelectedBooks.Count == 0)
            {
                xIssuebtn.Visibility = Visibility.Collapsed;
            }
        }
    }
}
