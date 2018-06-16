using GameX.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameX.DAL
{
    public class StoreContext: IdentityDbContext<ApplicationUser>
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
           
        }
        public DbSet<Events> Events { get; set; }
        public new DbSet<Users> Users { get; set; }
        public DbSet<EventParticipants> EventParticipants { get; set; }
        public DbSet<EventAdress> EventAdress { get; set; }
        public DbSet<Disciplines> Disciplines { get; set; }
    }
}
