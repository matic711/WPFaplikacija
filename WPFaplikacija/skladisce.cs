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
            public static List<User> Users { get; } = new()
        {
            new User { Email="admin@demo.local", FullName="Admin", Password="admin" }
        };

            public static List<zaposleni> Employees { get; } = new()
        {
            new zaposleni { Id=1, Email="admin@demo.local", FullName="Admin", Placa=0m, Koda="ADM00001" }
        };

            private static int _nextId = 2;
            public static int NextId() => _nextId++;

            public static bool EmailExists(string email) =>
                Users.Any(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));

            public static bool LoginByFullNameAndPassword(string fullName, string password) =>
                Users.Any(u => u.FullName == fullName && u.Password == password);

            public static string GenerateEmployeeCode()
            {
                const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                var r = new Random();
                return new string(Enumerable.Range(0, 8).Select(_ => chars[r.Next(chars.Length)]).ToArray());
            }

            public static string CreateUniqueEmployeeCode()
            {
                while (true)
                {
                    var code = GenerateEmployeeCode();
                    if (!Employees.Any(e => e.Koda == code))
                        return code;
                }
            }
        }
    }

}

