using Avalonia.Controls;
using Practica13_33.Models;

namespace Practica13_33.Views
{
    public partial class RegistrView : UserControl
    {
        public RegistrView()
        {
            InitializeComponent();
        }


        private void ButtonRegistration_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            if (fio.Text != ""
                && login.Text != ""
                && password.Text != "")
            {
                using DataBase dataBase = new DataBase();
                dataBase.Users.Add(new User()
                {
                    Name = fio.Text,
                    Login = login.Text,
                    Password = password.Text
                });
                dataBase.SaveChanges();
                MainWindow.ContentWindow.Content = new AuthView();
            }
        }
        private void ButtonBack_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            MainWindow.ContentWindow.Content = new AuthView();
        }
    }
}
