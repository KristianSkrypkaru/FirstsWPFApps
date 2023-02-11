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
using System.Windows.Shapes;

namespace UsersApp
{
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void Button_Auth_Click(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text.Trim();
            string password = passwordBox.Password.Trim();

            if (login.Length < 5)
            {
                textBoxLogin.ToolTip = "Login is not correct";
                textBoxLogin.Background = Brushes.DarkRed;
            }
            else if (password.Length < 5)
            {
                passwordBox.ToolTip = "The password is not correct";
                passwordBox.Background = Brushes.DarkRed;
            }
            else 
            {
                textBoxLogin.ToolTip = "";
                textBoxLogin.Background = Brushes.Transparent;
                passwordBox.ToolTip = "";
                passwordBox.Background = Brushes.Transparent;

                User? authUser = null;
                using(AppContext db = new AppContext())
                {
                    authUser = db.Users.Where(user => user.login == login && user.password == password).FirstOrDefault();
                }
                if (authUser != null)
                {
                    MessageBox.Show("Everything's okay");
                }
                else
                {
                    MessageBox.Show("You entered something incorrect");
                }
            }
        }
    }
}
