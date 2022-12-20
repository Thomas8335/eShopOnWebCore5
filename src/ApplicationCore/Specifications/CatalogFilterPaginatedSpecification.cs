using Ardalis.Specification;
using Microsoft.eShopWeb.ApplicationCore.Entities;

namespace Microsoft.eShopWeb.ApplicationCore.Specifications
{
    public class CatalogFilterPaginatedSpecification : Specification<CatalogItem>
    {
        public CatalogFilterPaginatedSpecification(int skip, int take, int? brandId, int? typeId, int? sugarId)
            : base()
        {
            if (take == 0)
            {
                take = int.MaxValue;
            }
            Query
                .Where(i => (!brandId.HasValue || i.CatalogBrandId == brandId) &&
                (!typeId.HasValue || i.CatalogTypeId == typeId) && (!sugarId.HasValue || i.CatalogSugarId == sugarId))
                .Skip(skip).Take(take);
        }
    }
}
