using LineTen.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineTen.Application.Interface
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository memberRepository;
        public ProductService(IProductRepository memberRepository)
        {
            this.memberRepository = memberRepository;
        }
        List<Domain.Entitites.Products> IProductService.GetProducts()
        {
            return this.memberRepository.GetProducts();
        }
    }
}
