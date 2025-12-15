using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;
using static WPFaplikacija.Services.skladisce;

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
        private void TopBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }


        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            string napake = "";
            string empattern  = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            if (string.IsNullOrWhiteSpace(email.Text))
            {
                napake += "Ime nesme biti prazno \n";



            }
            else if (!Regex.IsMatch(email.Text, empattern))
            {
                napake += "Pravilno vpišite email\n";
            }

            if (string.IsNullOrWhiteSpace(tbgeslo1.Password))
            {
                napake += "Prosim vnesite geslo\n";
            }




            if (napake == "")
            {
                bool ok = Skladisce.LoginByFullNameAndPassword(email.Text, tbgeslo1.Password);
                if (!ok)
                {
                    MessageBox.Show("Napačno ime ali geslo!", "Preverjanje",
                                    MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                MessageBox.Show($"Prijava uspešna! Dobrodošli ", "Preverjanje",
                                MessageBoxButton.OK, MessageBoxImage.Information);

                 drugoOkno appwindow = new drugoOkno();
                appwindow.Owner = this;
                appwindow.Show();
                this.Hide();

                











            }
            else
            {
                MessageBox.Show("Napake:\n\n" + napake, "Preverjanje",
                                MessageBoxButton.OK, MessageBoxImage.Warning);
            }



        }





        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); // zapre okno nov x style, da app bol zgleda
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            Window2 regWindow = new Window2();
            regWindow.Owner = this;
            regWindow.Show();
            this.Hide();


        }



        //test
    }
}