using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPFaplikacija
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
            

        }




        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            string pattern = @"^[a-zA-ZšŠžŽčČćĆđĐ\s]+$";
            string emailpattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            string napake = "";
            DateTime datum;

            if (string.IsNullOrWhiteSpace(tbEmail.Text))
            {
                napake += "Email nesme biti prazen \n";



            }
            else if (!Regex.IsMatch(tbEmail.Text, emailpattern))
            {
                napake += "Email nesme vsebovati drugih simbolov kot @\n";
            }

            if (string.IsNullOrWhiteSpace(tbName.Text))
            {
                napake += "Ime nesme biti prazno \n";



            }
            else if (!Regex.IsMatch(tbName.Text, pattern))
            {
                napake += "Ime lahko vsebuje samo crke\n";
            }

            if (!DateTime.TryParseExact(DatumRD.Text, "dd.MM.yyyy",
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None, out datum))
            {
                napake += "- Datum rojstva mora biti v obliki dd.MM.yyyy.\n";
            }
            else if (datum > DateTime.Now)
            {
                napake += "- Datum rojstva ne more biti v prihodnosti.\n";
            }

            if (string.IsNullOrWhiteSpace(tbgeslo1.Password) || string.IsNullOrWhiteSpace(tbgeslo2.Password))
            {
                napake += "Vnesi obe gesli!\n";
            }
            else if (tbgeslo1.Password != tbgeslo2.Password)
            {
                napake += "Gesli se ne ujemata!\n";
            }
            

            if (napake == "")
            {
                this.Close();
                drugoOkno   appwindow = new drugoOkno();
                appwindow.Show();

                MessageBox.Show("Pozdravljeni", "Preverjanje",
                                MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Napake:\n\n" + napake, "Preverjanje",
                                MessageBoxButton.OK, MessageBoxImage.Warning);






                
            }

           // if (this.Owner != null)
              //  this.Owner.Show(); 
            //this.Close();
        }













        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            if (this.Owner != null)
                this.Owner.Show();  // se vrne na glavno okno

            this.Close();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); //zapre aplikacijo
        }
    }
}
