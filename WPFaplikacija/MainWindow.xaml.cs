using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFaplikacija
{
    //patrik
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window

    {
        
        public MainWindow()
        {
            InitializeComponent();
            this.WindowState = WindowState.Maximized;
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            Window2 regWindow = new Window2();
            regWindow.Owner = this;     
            regWindow.Show();
            this.Hide();
        }

        private void tbUser_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (sender is TextBox tb)
                tb.FontSize = tb.ActualHeight / 2.5;
        }

        

        //test
    }
}