using Microsoft.eShopWeb.ApplicationCore.Interfaces;

namespace Microsoft.eShopWeb.ApplicationCore.Entities
{
    public class CatalogSugar : BaseEntity, IAggregateRoot
    {
        public string Sugar { get; private set; }
        public CatalogSugar(string sugar)
        {
            Sugar = sugar;
        }
    }
}
