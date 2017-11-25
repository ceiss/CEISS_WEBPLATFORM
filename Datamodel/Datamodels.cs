using Classes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datamodel
{
    public class CEISSContext : DbContext
    {
        public CEISSContext()
        {

        }
        public CEISSContext(bool lazyEnabled)
        {
            Configuration.LazyLoadingEnabled = lazyEnabled;
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Career> Careers { get; set; }
    }
}
