using Avalonia.Controls;
using Practica13_33.Models;
using System.Linq;

namespace Practica13_33.Views
{
    public partial class AuthView : UserControl
    {
        public AuthView()
        {
            InitializeComponent();
        }


        private void ButtonRegistr_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            MainWindow.ContentWindow.Content = new RegistrView();
        }
        private void ButtonEnter_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            if (lg.Text != "" 
                && pass.Text != "")
            {
                using DataBase database = new DataBase();
                User user = database.Users.Select(x => x).Where(x => x.Login == lg.Text && x.Password == pass.Text).FirstOrDefault();
                if (user != null) MainWindow.ContentWindow.Content = new ProductsView();
            }
        }
    }
}
