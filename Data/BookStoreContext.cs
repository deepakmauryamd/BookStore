using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Data
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options)
            : base(options)
        {

        }

        public DbSet<Books> Books { get; set; }
        public DbSet<BookGalary> BookGalary { get; set; }
        public DbSet<Language> Language { get; set; }
        public DbSet<Category> Category { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;database=BookStore;user=user;password=password;");
            base.OnConfiguring(optionsBuilder);
        }
    }

    public class AccountContext : IdentityDbContext
    {
        public AccountContext(DbContextOptions<AccountContext> options)
            : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;database=BookStore;user=user;password=password;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
