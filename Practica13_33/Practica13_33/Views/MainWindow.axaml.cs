using Avalonia.Controls;

namespace Practica13_33.Views;

public partial class MainWindow : Window
{
    public static Window ContentWindow { get; set;}
    public MainWindow()
    {
        InitializeComponent();

        ContentWindow = this;
    }
}
