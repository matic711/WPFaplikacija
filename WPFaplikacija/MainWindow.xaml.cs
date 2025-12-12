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
using Microsoft.EntityFrameworkCore;
using System.Linq;

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
            string napake = "";
            string pattern  = @"^[a-zA-ZšŠžŽčČćĆđĐ\s]+$";

            if (string.IsNullOrWhiteSpace(tbName.Text))
            {
                napake += "Ime nesme biti prazno \n";



            }
            else if (!Regex.IsMatch(tbName.Text, pattern))
            {
                napake += "Ime lahko vsebuje samo crke\n";
            }

            if (string.IsNullOrWhiteSpace(tbgeslo1.Password))
            {
                napake += "Prosim vnesite geslo\n";
            }




            if (napake == "")
            {
                var appwindow = new drugoOkno();


                using (var db = new AppDbContext())
                {
                    
                    var user = db.Users
                        .FirstOrDefault(u => u.FullName == tbName.Text && u.Password == tbgeslo1.Password);

                    if (user == null)
                    {
                        MessageBox.Show("Napačno ime ali geslo!", "Preverjanje",
                                        MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }

                    MessageBox.Show($"Prijava uspešna! Dobrodošel {user.FullName}", "Preverjanje",
                                    MessageBoxButton.OK, MessageBoxImage.Information);

                    Application.Current.MainWindow = appwindow;
                    appwindow.Show();
                    this.Close();
                }
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
            Visibility = Visibility.Hidden;
            regWindow.Owner = this;
            regWindow.Show();
            this.Hide();


        }



        //test
    }
}