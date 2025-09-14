using Cms.Models;
using Microsoft.EntityFrameworkCore;

namespace Cms.Context
{
    public class CmsContext :DbContext
    {
        public CmsContext(DbContextOptions<CmsContext> options) : base(options)
        {
        }

        public DbSet<AdminLogin> AdminLogins { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<PageComment> PageComments { get; set; }
        public DbSet<PageGroup> PageGroups { get; set; }

    }
}
