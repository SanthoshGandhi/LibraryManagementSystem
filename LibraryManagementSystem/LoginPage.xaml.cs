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
            List<LoginModel> logins = repo.GetLoginDetails(Log_as);
            bool flag = false;
            foreach(LoginModel item in logins)
            {
                if(xUsername.Text == item.Username && xPassword.Text == item.Password)
                {
                    if(Log_as == "ADMIN")
                    {
                        this.NavigationService.Navigate(new AdminPage());
                        flag = true;
                        return;
                    }
                    else if(Log_as == "MEMBER")
                    {
                        this.NavigationService.Navigate(new MemberPage());
                        flag = true;
                        return;
                    }
                }
            }
            if (flag)
            {
                MessageBox.Show("Please enter the valid Username or Password");
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
