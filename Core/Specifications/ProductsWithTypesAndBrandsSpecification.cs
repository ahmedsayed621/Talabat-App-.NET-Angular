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
        public ProductsWithTypesAndBrandsSpecification(ProductSpecParams productParams)
            :base(p=>
            (string.IsNullOrEmpty(productParams.Search)||p.Name==productParams.Search)&&
            (!productParams.TypeId.HasValue || p.ProductTypeId== productParams.TypeId.Value) &&
            (!productParams.BrandId.HasValue || p.ProductBrandId == productParams.BrandId.Value)
            )
        {
            AddInclude(x => x.productType);
            AddInclude(x => x.productBrand);
            AddOrderBy(x => x.Name);
            ApplyingPaging(productParams.PageSize * (productParams.PageIndex - 1), productParams.PageSize);
            if(!string.IsNullOrEmpty(productParams.Sort))
            {
                switch (productParams.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(p=>p.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(p => p.Price);
                        break;
                    default:
                        AddOrderBy(p => p.Name);
                        break;


                }
            }
        }
        //this ctor used to get specific product with id
        public ProductsWithTypesAndBrandsSpecification(int id):base(P=>P.Id==id)
        {
            AddInclude(x => x.productType);
            AddInclude(x => x.productBrand);
        }
    }
}
