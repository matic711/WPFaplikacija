using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
using WPFaplikacija.Models;
using static WPFaplikacija.Services.skladisce;

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
        private void TopBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
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


            if (Skladisce.EmailExists(tbEmail.Text))
            {
                napake += "Ta email je že registriran!\n";
            }




            if (napake == "")
            {


                var user = new User
                {
                    Email = tbEmail.Text,
                    FullName = tbName.Text,
                    Password = tbgeslo1.Password
                };
                Skladisce.Users.Add(user);

                
                var emp = new zaposleni
                {
                    Id = Skladisce.NextId(),
                    Email = tbEmail.Text,
                    FullName = tbName.Text,
                    Placa = 0m,
                    
                    Koda = Skladisce.CreateUniqueEmployeeCode() 
                };
                Skladisce.Employees.Add(emp);

                var appwindow = new MainWindow();
                Application.Current.MainWindow = appwindow;
                appwindow.Show();
                this.Close();

                MessageBox.Show("Registracija uspešna", "Preverjanje",
                                MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Napake:\n\n" + napake, "Preverjanje",
                                MessageBoxButton.OK, MessageBoxImage.Warning);

                // if (this.Owner != null)
                //  this.Owner.Show(); 
                //this.Close();
            }
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
