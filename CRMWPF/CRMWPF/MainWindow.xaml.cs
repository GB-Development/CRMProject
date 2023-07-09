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

namespace CRMWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AplicationContext db;

        public MainWindow()
        {
            InitializeComponent();

            db = new AplicationContext();
        }

        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text.Trim();
            string password = passBox.Password.Trim();
            string passwordRepeat = passBoxRepeat.Password.Trim();
            string email = textBoxEmail.Text.Trim().ToLower();

            if (login.Length < 5)
            {
                textBoxLogin.ToolTip = "Это поле введено некоректно! Логин не может быть меньше 5-ти символов.";
                textBoxLogin.Background = Brushes.Red;
            }
            else if(password.Length < 5)
            {
                passBox.ToolTip = "Это поле введено некоректно! Пароль не может быть меньше 5-ти символов.";
                passBox.Background = Brushes.Red;
            }
            else if (password != passwordRepeat)
            {
                passBoxRepeat.ToolTip = "Это поле введено некоректно! Пароли отличаются.";
                passBoxRepeat.Background = Brushes.Red;
            }
            else if (email.Length <5 || !email.Contains("@") || !email.Contains("."))
            {
                textBoxEmail.ToolTip = "Это поле введено некоректно! Пароли отличаются.";
                textBoxEmail.Background = Brushes.Red;
            }
            else
            {
                textBoxLogin.ToolTip = "";
                textBoxLogin.Background = Brushes.Transparent;
                passBox.ToolTip = "";
                passBox.Background = Brushes.Transparent;
                passBoxRepeat.ToolTip = "";
                passBoxRepeat.Background = Brushes.Transparent;
                textBoxEmail.ToolTip = "";
                textBoxEmail.Background = Brushes.Transparent;

                MessageBox.Show("Регистрация прошла успешно!");
                User user = new User(login, password, email);

                db.Users.Add(user);
                db.SaveChanges();

            }


        }
    }
}
