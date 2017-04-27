using System.Linq;
using domain.Entities;
using domain.Lib;
using Microsoft.EntityFrameworkCore;
using api.Context.Repository;
using api.Context.Transaction;

namespace api.Context
{
    public class DbInitializer
    {        
        public static void Initialize(CdpContext context)
        {            
            var ResetData = true;

            context.Database.EnsureCreated();

            if (ResetData)
            {
                context.Database.ExecuteSqlCommand("DELETE FROM peladaUser");
                context.Database.ExecuteSqlCommand("ALTER TABLE peladaUser AUTO_INCREMENT = 1");

                context.Database.ExecuteSqlCommand("DELETE FROM pelada");
                context.Database.ExecuteSqlCommand("ALTER TABLE pelada AUTO_INCREMENT = 1");

                context.Database.ExecuteSqlCommand("DELETE FROM arena");
                context.Database.ExecuteSqlCommand("ALTER TABLE arena AUTO_INCREMENT = 1");

                context.Database.ExecuteSqlCommand("DELETE FROM user");
                context.Database.ExecuteSqlCommand("ALTER TABLE user AUTO_INCREMENT = 1");
            }

            var unitOfWork = new UnitOfWork(context);

            InsertUsers(unitOfWork);
            InsertArenas(unitOfWork);
            //InsertPeladas(unitOfWork);

            unitOfWork.Save();


            //InsertPeladaUsers(context);

            //context.SaveChanges();
        }

        public static void InsertUsers(UnitOfWork unitOfWork)
        {            
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
                unitOfWork.UserRepository.Create(user);
            }
        }

        public static void InsertArenas(UnitOfWork unitOfWork) 
        {                        
            var arenas = new Arena[]
            {
                new Arena {Name = "Arena Capim Macio", Description = "Rua Arena Capim Macio"},
                new Arena {Name = "Arena Nova Descoberta", Description = "Rua Arena Nova Descoberta"}
            };

            foreach(var arena in arenas) 
            {
                unitOfWork.ArenaRepository.Create(arena);
            }

            var xico = unitOfWork.ArenaRepository.GetAll();
        }

        public static void InsertPeladas(UnitOfWork unitOfWork)
        {            
            var peladas = new Pelada[]
            {
                new Pelada {Name = "Pelada 1", CreatedByUserId = 1},
                new Pelada {Name = "Pelada 2", CreatedByUserId = 2},
                new Pelada {Name = "Pelada 3", CreatedByUserId = 1}
            };

            foreach (var pelada in peladas)
            {
                unitOfWork.PeladaRepository.Create(pelada);
            }
        }

        public static void InsertPeladaUsers(CdpContext context)
        {
            if (context.PeladaUser.Any())
            {
                return;
            }

            context.SaveChanges();

            var peladaUsers = new PeladaUser[]
            {
                new PeladaUser {UserId = 1, PeladaId = 1},
                new PeladaUser {UserId = 2, PeladaId = 1},
                new PeladaUser {UserId = 1, PeladaId = 2},
                new PeladaUser {UserId = 2, PeladaId = 2},
            };

            foreach (var peladaUser in peladaUsers)
            {
                context.PeladaUser.Add(peladaUser);
            }
        }
    }
}