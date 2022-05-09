using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DotNetCoreLearnProj.Data.Model;

namespace DotNetCoreLearnProj.Data.Model
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book_Author>()
                .HasOne(b => b.book)
                .WithMany(ba => ba.book_Authors)
                .HasForeignKey(bi => bi.bookId);

            modelBuilder.Entity<Book_Author>()
                .HasOne(b => b.author)
                .WithMany(ba => ba.book_Authors)
                .HasForeignKey(bi => bi.authorId);
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book_Author> Book_Authors { get; set; }
        public DbSet<Publisher> publishers { get; set; }

    }
}
