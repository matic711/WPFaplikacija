using System;
using System.Collections.Generic;
using System.Text;
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
            // Dodajte logiko za obravnavo klika gumba
            MessageBox.Show("Gumb v Window2 je bil kliknjen!");
        }

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            if (this.Owner != null)
                this.Owner.Show();  // pokaže nazaj login okno

            this.Close();
        }
    }
}
