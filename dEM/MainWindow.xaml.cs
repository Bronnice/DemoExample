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

namespace dEM
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void loginButt_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new DemoDB())
            {
                var users = db.user_auth.Where(u => u.login == loginBox.Text && u.password == passwordBox.Password);
                if (users.Count() == 0)
                {
                    MessageBox.Show("Incorrect log or pas");
                    return;
                }
                MessageBox.Show("Logged");
            }
        }

        private void registerButt_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new DemoDB())
            {
                var users = db.user_auth.Where(u => u.login == loginBox.Text);
                if (users.Count() > 0)
                {
                    MessageBox.Show("log already exists");
                }
                else
                {
                    var user = new user_auth { login = loginBox.Text, password = passwordBox.Password };

                    db.user_auth.Add(user);
                    db.SaveChanges();
                }
            }
        }
    }
}
