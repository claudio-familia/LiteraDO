using LiteraDO.Common.Models;
using LiteraDO.Common.Services.Contracts;
using LiteraDO.Domain.Readers;
using LiteraDO.Domain.Users;
using LiteraDO.Domain.Writers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace LiteraDO.DataAccess
{
    public class LiteraDODBContext : DbContext
    {
        private readonly ICurrentUserService _currentUserService;
        public LiteraDODBContext(DbContextOptions<LiteraDODBContext> options,
                                        ICurrentUserService currentUserService) : base(options)
        {
            _currentUserService = currentUserService;
        }

        #region Save Changes
        public override int SaveChanges()
        {
            var auditableEntitySet = ChangeTracker.Entries<IAuditableEntity>();

            if (auditableEntitySet != null)
            {
                foreach (var auditableEntity in auditableEntitySet.Where(c => c.State == EntityState.Added || c.State == EntityState.Modified))
                {
                    if (auditableEntity.State == EntityState.Added)
                    {
                        auditableEntity.Entity.CreationTime = DateTime.Now;
                        auditableEntity.Entity.CreatorUserId = _currentUserService.UserId ?? 0;
                    }

                    auditableEntity.Entity.CreationTime = DateTime.Now;
                    auditableEntity.Entity.CreatorUserId = _currentUserService.UserId ?? 0;
                    auditableEntity.Entity.LastModificationTime = DateTime.Now;
                    auditableEntity.Entity.LastModifierUserId = _currentUserService.UserId ?? 0;
                }
            }

            return base.SaveChanges();
        }

        #endregion

        #region Seed DATA

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }

        #endregion


        // USERS
        public DbSet<User> Users { get; set; }
        public DbSet<Country> Countries { get; set; }


        // READERS
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<BookUserState> BookUserStates { get; set; }
        public DbSet<LiteraryGenre> LiteraryGenres { get; set; }
        public DbSet<UserFavoriteGenre> UserFavoriteGenres { get; set; }

        // WRITERS
        public DbSet<Story> Stories { get; set; }
        public DbSet<StoryChapter> StoryChapters { get; set; }
        public DbSet<StoryCharacter> StoryCharacters { get; set; }
        public DbSet<StoryReports> StoryReports { get; set; }
        public DbSet<StoryReviews> StoryReviews { get; set; }
    }
}
