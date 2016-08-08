using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catalyst.Data.Entities;
using Catalyst.Data.Initializer;
using System.Data.Entity;

namespace Catalyst.Data.Context
{
    public class CatalystDbContext : DbContext
    {
        public CatalystDbContext()
            : base("Catalyst.DbConnection")
        {
            Database.SetInitializer<CatalystDbContext>(new CatalystMemberInitializer());
            Configuration.ProxyCreationEnabled = false;
        }

       // public DbSet<CatalystMember> CatalystMembers { get; set; }
        public virtual IDbSet<CatalystMember> DbEntities { get; set; }
    }
}
