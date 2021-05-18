using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ResultArchive.Models.AuditTrail;

namespace ResultArchive.Models
{
    public class DBContext : IdentityDbContext<IdentityUser>
    {
        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        //register the migration files here
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<ExamLog> ExamLogs { get; set; }
        public DbSet<AuditSchool> AuditSchools { get; set; }
        public DbSet<AuditSession> AuditSessions { get; set; }
        public DbSet<AuditResult> AuditResults { get; set; }
        public DbSet<AuditExamLog> AuditExamLogs { get; set; }

    }
}
