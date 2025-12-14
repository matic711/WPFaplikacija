using System;
using System.Collections.Generic;
using System.Text;

namespace WPFaplikacija.Models
{
    public class zaposleni
    {

        public int Id { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public decimal Placa { get; set; }
        public string Koda { get; set; }
    }
}
