using System;
using System.Collections.Generic;
using System.Text;
using WPFaplikacija.Models;
using System.Linq;

namespace WPFaplikacija.Services
{
    public static class skladisce
    {
        public static class Skladisce
        {
            public static List<zaposleni> Users { get; } = new()
            {
            new zaposleni { Email="admin@demo.local", FullName="Admin", Password="admin" }
            };

            public static bool EmailExists(string email) =>
                Users.Any(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));

            public static bool LoginByFullNameAndPassword(string email, string password) =>
                Users.Any(u => u.Email == email && u.Password == password);

          

           
        }
    }

}

