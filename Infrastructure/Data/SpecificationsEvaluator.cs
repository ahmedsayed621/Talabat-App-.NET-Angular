﻿using Core.Entities;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class SpecificationsEvaluator<IEntity> where IEntity : BaseEntity
    {
        public static IQueryable<IEntity> GetQuery(IQueryable<IEntity> inputQuery,
            ISpecification<IEntity> spec)
        {
            var query = inputQuery;

            if (spec.Criteria != null)
            {
                query = query.Where(spec.Criteria); //p=>p.id=1
            }
            //context.set<Product>();

            if(spec.OrderBy!= null)
            {
                query = query.OrderBy(spec.OrderBy);
            }
            if (spec.OrderByDescending != null)
            {
                query = query.OrderByDescending(spec.OrderByDescending);
            }
            if (spec.IsPagingEnabled)
            {
                query = query.Skip(spec.Skip).Take(spec.Take);
            }
            query = spec.Includes.Aggregate(query,(currentQuery,include)=>currentQuery.Include(include));
            //context.set<product>().includes(p=>p.productBrand).Include(p=>p.product.productType);
            return query;
        }
    }
}
