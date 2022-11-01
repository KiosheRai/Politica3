using Microsoft.EntityFrameworkCore;
using Politica.Domain;
using Politica.Persistence;
using System;

namespace Politica.Test.Common
{
    public static class PoliticaContextFactory
    {
        public static int AlreadyExistsHabitId = 1111;

        public static Guid PlayerForDelete = Guid.NewGuid();
        public static Guid InvitedPlayer = Guid.NewGuid();
        public static Guid PlayerForUpdate = Guid.NewGuid();
        public static Guid PlayerFractionOwner = Guid.NewGuid();
        public static Guid PlayerForDetails = Guid.NewGuid();

        public static Guid PlayerOne = Guid.NewGuid();
        public static Guid FractionForDelete = Guid.NewGuid();
        public static Guid FractionForUpdate = Guid.NewGuid();

        public static Guid FractionForAccessPlayer = Guid.NewGuid();
        public static Guid FractionForDetails = Guid.NewGuid();

        public static Guid UnionForDelete = Guid.NewGuid();
        public static Guid UnionForUpdate = Guid.NewGuid();
        public static Guid UnionForDetails = Guid.NewGuid();

        public static DateTime NickChangeDate = DateTime.Now;

        public static PoliticaDbContext Create()
        {
            var options = new DbContextOptionsBuilder<PoliticaDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new PoliticaDbContext(options);
            context.Database.EnsureCreated();
            context.Players.AddRange(
                new Player
                {
                    Id = PlayerForDelete,
                    Name = "Gixal",
                    Habit = "VK",
                    HabitId = 789221,
                    InvitedId = null,
                    Association = null,
                    NickChangeDate = null,
                    IsDeleted = false,
                },
                new Player
                {
                    Id = InvitedPlayer,
                    Name = "Ancap1488",
                    Habit = "Telegram",
                    HabitId = AlreadyExistsHabitId,
                    InvitedId = null,
                    Association = null,
                    NickChangeDate = null,
                    IsDeleted = false,
                },
                new Player
                {
                    Id = PlayerForUpdate,
                    Name = "Lince",
                    Habit = "Web",
                    HabitId = 12594,
                    InvitedId = null,
                    Association = null,
                    NickChangeDate = null,
                    IsDeleted = true,
                },
                new Player
                {
                    Id = PlayerFractionOwner,
                    Name = "Коммунист",
                    Habit = "VK",
                    HabitId = 34358,
                    InvitedId = Guid.Parse("7B3293D4-8BA1-4814-8C22-2A9CE42090A1"),
                    Association = null,
                    NickChangeDate = null,
                    IsDeleted = false,
                },
                new Player
                {
                    Id = PlayerForDetails,
                    Name = "Саня",
                    Habit = "VK",
                    HabitId = 76756,
                    InvitedId = null,
                    Association = null,
                    NickChangeDate = NickChangeDate,
                    IsDeleted = false,
                },
                new Player
                {
                    Id = PlayerOne,
                    Name = "PlayerOne",
                    Habit = "VK",
                    HabitId = 767256,
                    InvitedId = null,
                    Association = null,
                    NickChangeDate = null,
                    IsDeleted = false,
                }
             );

            context.Fractions.AddRange(
                new Fraction
                {
                    Id = FractionForAccessPlayer,
                    Title = "Вейшнория",
                    Description = "Описание",
                    CoordinateX = 123,
                    CoordinateZ =  321,
                    Association = null,
                    OwnerId = PlayerFractionOwner,
                    Players = null,
                    IsDeleted = false
                },
                new Fraction
                {
                    Id = FractionForDelete,
                    Title = "FractionForDelete",
                    Description = "Описание",
                    CoordinateX = 123,
                    CoordinateZ = 321,
                    Association = null,
                    OwnerId = PlayerFractionOwner,
                    Players = null,
                    IsDeleted = false
                },
                new Fraction
                {
                    Id = FractionForUpdate,
                    Title = "FractionForDelete",
                    Description = "Описание",
                    CoordinateX = 123,
                    CoordinateZ = 321,
                    Association = null,
                    OwnerId = PlayerFractionOwner,
                    Players = null,
                    IsDeleted = false
                },
                new Fraction
                {
                    Id = FractionForDetails,
                    Title = "FractionForDetails",
                    Description = "Описание",
                    CoordinateX = 123,
                    CoordinateZ = 321231,
                    Association = null,
                    OwnerId = PlayerFractionOwner,
                    Players = null,
                    IsDeleted = false
                }
                );

            context.Unions.AddRange(
                new Union
                {
                    Id = UnionForDelete,
                    Title = "Союз",
                    Description = "Описание",
                    CoordinateX = 123,
                    CoordinateZ = 321231,
                    OwnerId = PlayerFractionOwner,
                    Fractions = null,
                    IsDeleted = false
                },
                new Union
                {
                    Id = UnionForUpdate,
                    Title = "Союз",
                    Description = "Описание",
                    CoordinateX = 123,
                    CoordinateZ = 331221,
                    OwnerId = PlayerFractionOwner,
                    Fractions = null,
                    IsDeleted = false
                },
                new Union
                {
                    Id = UnionForDetails,
                    Title = "UnionForDetails",
                    Description = "Описание",
                    CoordinateX = 123,
                    CoordinateZ = 123,
                    OwnerId = PlayerFractionOwner,
                    Fractions = null,
                    IsDeleted = false
                }
                );


            context.SaveChanges();
            return context;
        }

        public static void Destroy(PoliticaDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
