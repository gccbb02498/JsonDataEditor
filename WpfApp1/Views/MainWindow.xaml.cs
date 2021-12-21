using System.Windows;

namespace WpfApp1.Views;

/// <summary>
///     Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void SkillDataButton_Click(object sender, RoutedEventArgs e)
    {
        var skillDataWindow = new SkillDataWindow(this);
        this.Hide();
        skillDataWindow.Show();
    }
}