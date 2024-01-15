using LineTen.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineTen.Infrastructure.Context
{
  public partial class LineTenContext: DbContext
  {
    public LineTenContext()
        : base("MyDb")
    { }

    public DbSet<Product> Products { get; set; }
  }
}
