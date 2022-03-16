using Microsoft.EntityFrameworkCore;
using Models.Entities;
using System;

namespace DAL
{
    public static class DataInitializer
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            #region Users
            var userId1 = Guid.NewGuid();
            var userId2 = Guid.NewGuid();

            var user1 = new User 
            {
                Id = userId1,
                Name = "User1",
            };

            var user2 = new User
            {
                Id = userId2,
                Name = "User2",
            };

            modelBuilder.Entity<User>()
                .HasData(user1, user2);

            #endregion

            #region Diagrams

            var diagramId1 = Guid.NewGuid();
            var diagramId2 = Guid.NewGuid();

            var diagram1 = new Diagram
            {
                Id = diagramId1,
                Room = "seed-room-1",
                Data = string.Empty
            };

            var diagram2 = new Diagram
            {
                Id = diagramId2,
                Room = "seed-room-2",
                Data = string.Empty
            };

            modelBuilder.Entity<Diagram>().HasData(diagram1, diagram2);

            #endregion

            #region UserDiagrams

            modelBuilder.Entity<UserDiagram>()
                .HasKey(uc => new { uc.UserId, uc.DiagramId });

            modelBuilder.Entity<UserDiagram>().HasData
                (
                    new UserDiagram
                    {
                        Id = Guid.NewGuid(),
                        UserId = user1.Id,
                        DiagramId = diagram1.Id,
                    },

                    new UserDiagram
                    {
                        Id = Guid.NewGuid(),
                        UserId = user1.Id,
                        DiagramId = diagram2.Id,
                    },
                    new UserDiagram
                    {
                        Id = Guid.NewGuid(),
                        UserId = user2.Id,
                        DiagramId = diagram1.Id,
                    }
                );

            #endregion

        }

    }
}
