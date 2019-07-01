using Microsoft.EntityFrameworkCore;
using DojoCenter.Models;
using System.Linq;
using System;

namespace DojoCenter.Models {
    public class CenterContext : DbContext {
        public CenterContext(DbContextOptions options) : base(options) { }
        public DbSet<Shindig> Shindigs {get;set;}
        public DbSet<User> Users { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public int Create(User u)
        {
            Users.Add(u);
            SaveChanges();
            return u.UserId;
        }

        public User GetUserByEmail(string email)
        {
            return Users.FirstOrDefault(u => u.Email == email);
        }

        public User GetUserById(int UserId)
        {
            return Users.FirstOrDefault(u => u.UserId == UserId);
        }
        public void Create(Shindig s)
        {
            Add(s);
            SaveChanges();
        }
        public void Create(Participant p)
        {
            Add(p);
            SaveChanges();
        }
        public Shindig GetShindigById(int ShindigId)
        {
            return Shindigs.Where(s => s.ShindigId == ShindigId).FirstOrDefault();
        }
        public void Remove(int SId, int PId)
        {
            Participant Planner = Participants.Where(s => s.ShindigId == SId).Where(p => p.UserId == PId).FirstOrDefault();
            Remove(Planner);
            SaveChanges();
        }

        
    }

}