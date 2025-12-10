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
            

        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            
        }



        

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); // zapre okno nov x style, da app bol zgleda
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            Window2 regWindow = new Window2();
            Visibility = Visibility.Hidden;
            regWindow.Owner = this;
            regWindow.Show();
            this.Hide();


        }



        //test
    }
}