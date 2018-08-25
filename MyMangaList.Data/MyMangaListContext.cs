using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyMangaList.Models;

namespace MyMangaList.Data
{
    public class MyMangaListContext : IdentityDbContext<User>
    {
        public MyMangaListContext(DbContextOptions<MyMangaListContext> options)
            : base(options)
        {
        }
        public DbSet<Manga> Manga { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<UsersInGroups> UsersInGrouos { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<UserManga> UsersManga { get; set; }
        public DbSet<Friend> Friends { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasMany(u => u.MangaWritten)
                .WithOne(m => m.Author)
                .HasForeignKey(m => m.AuthorId);

            builder.Entity<User>()
                .HasMany(u => u.Comments)
                .WithOne(m => m.User)
                .HasForeignKey(m => m.UserId);

            builder.Entity<User>()
                .HasMany(u => u.Groups)
                .WithOne(m => m.User)
                .HasForeignKey(m => m.UserId);

            builder.Entity<User>()
                .HasMany(u => u.MyMangaList)
                .WithOne(m => m.User)
                .HasForeignKey(m => m.UserId);

            builder.Entity<Friend>()
                .HasOne(f => f.Contract)
                .WithMany(u => u.Friends)
                .HasForeignKey(f => f.ContractId);

            builder.Entity<Friend>()
                .HasOne(f => f.User)
                .WithMany(u => u.UserContracts)
                .HasForeignKey(f => f.UserId);

            builder.Entity<Manga>()
                .HasMany(u => u.Users)
                .WithOne(m => m.Manga)
                .HasForeignKey(m => m.MangaId);


            builder.Entity<Group>()
                .HasMany(u => u.Users)
                .WithOne(m => m.Group)
                .HasForeignKey(m => m.GroupId);

            builder.Entity<Group>()
                .HasMany(u => u.Messages)
                .WithOne(m => m.Group)
                .HasForeignKey(m => m.GroupId);

            builder.Entity<Manga>()
                .HasMany(u => u.Comments)
                .WithOne(m => m.Manga)
                .HasForeignKey(m => m.MangaId);

            builder.Entity<UsersInGroups>()
                .HasKey(ug => new { ug.UserId, ug.GroupId });
            


            base.OnModelCreating(builder);
        }
    }
}
