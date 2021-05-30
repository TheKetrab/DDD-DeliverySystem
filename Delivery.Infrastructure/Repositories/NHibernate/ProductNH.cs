using Delivery.Domain.Model.Products;
using Delivery.Domain.Model.Products.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delivery.Infrastructure.Repositories.NHibernate
{
    public class ProductNH : BaseImplNH<Product>, IProductRepository
    {
        public override string Table => "Product";
    }
}
