using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class ProductsWithTypesAndBrandsSpecification : BaseSpecification<Product>
    {
        //thos cotr is used to get all products
        public ProductsWithTypesAndBrandsSpecification()
        {
            AddInclude(x => x.productType);
            AddInclude(x => x.productBrand);
        }
        //this ctor used to get specific product with id
        public ProductsWithTypesAndBrandsSpecification(int id):base(P=>P.Id==id)
        {
            AddInclude(x => x.productType);
            AddInclude(x => x.productBrand);
        }
    }
}
