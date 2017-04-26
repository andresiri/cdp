using System.Linq;
using domain.Entities;
using domain.Lib;

namespace api.Context
{
    public class DbInitializer
    {
        public static void Initialize(CdpContext context)
        {
            context.Database.EnsureCreated();

            InsertUsers(context);
            InsertArenas(context);

            context.SaveChanges();
        }

        public static void InsertUsers(CdpContext context)
        {
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
                    Password = Password.Hash("andre", "andremirannda@gmail.com"),
                    Position = Position.MeioCampo
                },
                new User
                {
                    Email = "heliofeliciano@gmail.com",
                    FirstName = "Helio",
                    LastName = "Feliciano",
                    Number = 7,
                    Password = Password.Hash("helio", "heliofeliciano@gmail.com"),
                    Position = Position.Atacante
                }
            };

            foreach (var user in users)
            {
                context.User.Add(user);
            }
        }

        public static void InsertArenas(CdpContext context) 
        {
            if (context.Arena.Any()) 
            {
                return;
            }

            var arenas = new Arena[]
            {
                new Arena {Name = "Arena Capim Macio", Description = "Rua Arena Capim Macio"},
                new Arena {Name = "Arena Nova Descoberta", Description = "Rua Arena Nova Descoberta"}
            };

            foreach(var arena in arenas) 
            {
                context.Arena.Add(arena);
            }
        }
    }
}