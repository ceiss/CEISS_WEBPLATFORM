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
<<<<<<< HEAD
        public CEISSContext()
        {

        }
        public CEISSContext(bool lazyEnabled)
        {
            Configuration.LazyLoadingEnabled = lazyEnabled;
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Career> Careers { get; set; }
=======
        public DbSet<Student> Students { get; set; }
>>>>>>> 21747c4a77907cabba94b23fb14f0944b874c06c
    }
}
