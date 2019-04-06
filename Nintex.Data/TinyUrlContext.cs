using MySql.Data.Entity;
using Nintex.Entities;
using System.Data.Common;
using System.Data.Entity;

namespace Nintex.Data
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class TinyUrlContext : DbContext
    {
        public TinyUrlContext() : base("NintexDB") // base("server = localhost; port=3306;database=NintexDB;uid=root;password=kabuljan")
        {

        }
        public virtual DbSet<TinyUrl> TinyUrls { get; set; }
        public TinyUrlContext(DbConnection existingConnection, bool contextOwnsConnection) :
            base(existingConnection, contextOwnsConnection)
        {
        }
        
    }
}
