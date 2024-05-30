using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace LibraryInterface
{
    /// <summary>
    /// Interaction logic for PasswordRecovery.xaml
    /// </summary>
    public partial class PasswordRecovery : Window
    {
        public PasswordRecovery()
        {
            InitializeComponent();
        }
        private void Window_Activated(object sender, EventArgs e)
        {
            SetCapsLockOnState();
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            SetCapsLockOnState();
        }

        private void SetCapsLockOnState()
        {
            if (Console.CapsLock)
            {
                Caps.Visibility = Visibility.Visible;
            }
            else
            {
                Caps.Visibility = Visibility.Hidden;
            }
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                string login = tbLogin.Text;
                string oPassword = oldPassword.Password;
                string nPassword = newPassword.Password;
                string rnPassword = repeatNewPassword.Password;
                if(nPassword != rnPassword)
                {
                    MessageBox.Show("Ошибка!", $"Неверный логин или пароль!");
                    return;
                }
                try
                {
                    Library.MyEntities.User user = db.Users.Where((u) => u.Name == login && u.Password == oPassword).Single();
                    user.Password = nPassword;
                    db.SaveChanges();
                    MessageBox.Show("Успешно!");
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("Ошибка!", $"Неверный логин или пароль!");
                }
            }
        }
    }
}
