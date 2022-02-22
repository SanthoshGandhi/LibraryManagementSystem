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
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        string Log_as = string.Empty;

        public LoginPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Repo repo = new Repo();
            LoginModel logins = new LoginModel();
            logins.Username = xUsername.Text;
            logins.Password = xPassword.Password;
            if (repo.GetLoginDetails(Log_as, logins))
            {
                if (Log_as == "ADMIN")
                {
                    this.NavigationService.Navigate(new AdminPage());
                }
                else if (Log_as == "MEMBER")
                {
                    this.NavigationService.Navigate(new MemberPage(repo.GetMember(logins.Username, logins.Password)));
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Log_as = "ADMIN";
            xLoginForm.Visibility = Visibility.Visible;
            xadminbtn.Visibility = Visibility.Collapsed;
            xmemberbtn.Visibility = Visibility.Collapsed;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Log_as = "MEMBER";
            xLoginForm.Visibility = Visibility.Visible;
            xadminbtn.Visibility = Visibility.Collapsed;
            xmemberbtn.Visibility = Visibility.Collapsed;
        }
    }
}
