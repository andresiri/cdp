using System;
using System.Linq;
using Domain.Entities;

namespace api.Context
{
    public class DbInitializer
    {
        public static void Initialize(CdpContext context)
        {
            context.Database.EnsureCreated();

            if (context.User.Any())
            {
                return;
            }

            var users = new User[]
            {
                new User
                {
                    Email = "andremirannda@gmail.com",
                    FirstName = "Andre",
                    LastName = "Miranda",
                    Number = 8,
                    Password = "andre"
                },
                new User
                {
                    Email = "heliofeliciano@gmail.com",
                    FirstName = "Helio",
                    LastName = "Feliciano",
                    Number = 7,
                    Password = "helio"
                }
            };

            foreach (var u in users)
            {
                context.User.Add(u);
            }

            context.SaveChanges();
        }
    }
}