using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static WPFaplikacija.drugoOkno;

namespace WPFaplikacija
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class drugoOkno : Window
    {
        public ObservableCollection<Zaposleni> SeznamZaposlenih { get; set; }
        public drugoOkno()
        {
            InitializeComponent();
            SeznamZaposlenih = new ObservableCollection<Zaposleni>();
            dgZaposleni.ItemsSource = SeznamZaposlenih;
        }

        private void TopBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }










        private bool PreveriVnos()
        {
            if (string.IsNullOrWhiteSpace(txtID.Text) ||
                string.IsNullOrWhiteSpace(txtIme.Text) ||
                string.IsNullOrWhiteSpace(txtPriimek.Text) ||
                cbDelovnoMesto.SelectedItem == null ||
                string.IsNullOrWhiteSpace(txtPlaca.Text))
            {
                MessageBox.Show("Prosim, izpolnite vsa polja.", "Napaka", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (!decimal.TryParse(txtPlaca.Text, out _))
            {
                MessageBox.Show("Prosim, vnesite veljavno številko za plačo.", "Napaka", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (dpDatumRojstva.SelectedDate == null || dpDatumRojstva.SelectedDate > DateTime.Today)
            {
                MessageBox.Show("Prosim, izberite datum rojstva.", "Napaka", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }


        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            if (!PreveriVnos()) return;
            var selectedComboBoxItem = cbDelovnoMesto.SelectedItem as ComboBoxItem;
            string delovnoMesto = selectedComboBoxItem?.Content?.ToString() ?? string.Empty;

            if (dpDatumRojstva.SelectedDate == null)
            {
                MessageBox.Show("Prosim, izberite datum rojstva.", "Napaka", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            SeznamZaposlenih.Add(new Zaposleni
            {
                ID = int.Parse(txtID.Text),
                Ime = txtIme.Text,
                Priimek = txtPriimek.Text,
                DelovnoMesto = delovnoMesto,
                Placa = decimal.Parse(txtPlaca.Text),
                DatumRojstva = dpDatumRojstva.SelectedDate.Value
            });

            Pocisti_Click(this, new RoutedEventArgs());
        }

        private void Uredi_Click(object sender, RoutedEventArgs e)
        {
            if (dgZaposleni.SelectedItem is not Zaposleni z) return;
            if (!PreveriVnos()) return;

            var selectedComboBoxItem = cbDelovnoMesto.SelectedItem as ComboBoxItem;
            string delovnoMesto = selectedComboBoxItem?.Content?.ToString() ?? string.Empty;

            z.ID = int.Parse(txtID.Text);
            z.Ime = txtIme.Text;
            z.Priimek = txtPriimek.Text;
            z.DelovnoMesto = delovnoMesto;
            z.Placa = decimal.Parse(txtPlaca.Text);
            if (dpDatumRojstva.SelectedDate.HasValue)
            {
                z.DatumRojstva = dpDatumRojstva.SelectedDate.Value;
            }
            dgZaposleni.Items.Refresh();

        }

        private void Izbrisi_Click(object sender, RoutedEventArgs e)
        {
            if (dgZaposleni.SelectedItem is Zaposleni z)
            {
                SeznamZaposlenih.Remove(z);
                Pocisti_Click(this, new RoutedEventArgs());
            }
        }

        private void dgZaposleni_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgZaposleni.SelectedItem is not Zaposleni z) return;
            txtID.Text = z.ID.ToString();
            txtIme.Text = z.Ime;
            txtPriimek.Text = z.Priimek;
            dpDatumRojstva.SelectedDate = z.DatumRojstva;
            txtPlaca.Text = z.Placa.ToString();
            cbDelovnoMesto.Text = z.DelovnoMesto;

        }



        private void Pocisti_Click(object sender, RoutedEventArgs e)
        {
            txtID.Clear();
            txtIme.Clear();
            txtPriimek.Clear();
            dpDatumRojstva.SelectedDate = null;
            txtPlaca.Clear();
            cbDelovnoMesto.SelectedIndex = -1;

        }

        public class Zaposleni
        {
            public int ID { get; set; }
            public string Ime { get; set; } = string.Empty;
            public string Priimek { get; set; } = string.Empty;
            public string DelovnoMesto { get; set; } = string.Empty;
            public decimal Placa { get; set; }
            public DateTime DatumRojstva { get; set; }

        }

        private void TxtID_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TxtIme_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TxtPriimek_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void cbDelovnoMesto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TxtPlaca_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Nazaj_Click(object sender, RoutedEventArgs e)
        {
           
            

            if (this.Owner != null)
                this.Owner.Show();  

            this.Close();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

