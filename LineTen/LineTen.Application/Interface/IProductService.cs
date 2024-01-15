using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineTen.Application.Interface
{
    public interface IProductService
    {
        List<Domain.Entitites.Products> GetProducts();

    }
}
