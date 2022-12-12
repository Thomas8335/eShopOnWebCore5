using Microsoft.EntityFrameworkCore;
using Microsoft.eShopWeb.ApplicationCore.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microsoft.eShopWeb.Infrastructure.Data
{
    public class CatalogContextSeed
    {
        public static async Task SeedAsync(CatalogContext catalogContext,
            ILoggerFactory loggerFactory, int retry = 0)
        {
            var retryForAvailability = retry;
            try
            {
                if (catalogContext.Database.IsSqlServer())
                {
                    catalogContext.Database.Migrate();
                }

                if (!await catalogContext.CatalogBrands.AnyAsync())
                {
                    await catalogContext.CatalogBrands.AddRangeAsync(
                        GetPreconfiguredCatalogBrands());

                    await catalogContext.SaveChangesAsync();
                }

                if (!await catalogContext.CatalogTypes.AnyAsync())
                {
                    await catalogContext.CatalogTypes.AddRangeAsync(
                        GetPreconfiguredCatalogTypes());

                    await catalogContext.SaveChangesAsync();
                }

                if (!await catalogContext.CatalogItems.AnyAsync())
                {
                    await catalogContext.CatalogItems.AddRangeAsync(
                        GetPreconfiguredItems());

                    await catalogContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                if (retryForAvailability >= 10) throw;

                retryForAvailability++;
                var log = loggerFactory.CreateLogger<CatalogContextSeed>();
                log.LogError(ex.Message);
                await SeedAsync(catalogContext, loggerFactory, retryForAvailability);
                throw;
            }
        }

        static IEnumerable<CatalogBrand> GetPreconfiguredCatalogBrands()
        {
            return new List<CatalogBrand>
            {
                new("Mars"),
                new("Hershey"),
                new("Nestle"),
                new("Wrigley"),
                new("Spangler")
            };
        }

        static IEnumerable<CatalogType> GetPreconfiguredCatalogTypes()
        {
            return new List<CatalogType>
            {
                new("Chocolate"),
                new("Gum"),
                new("Fruity"),
                new("Christmas")
            };
        }

        static IEnumerable<CatalogItem> GetPreconfiguredItems()
        {

            

            return new List<CatalogItem>
            {
                new(1,1, "Snickers", "Snickers", 2.0M,  "http://catalogbaseurltobereplaced/images/products/1.png", 29),
                new(3,1, "Skittles", "Skittles", 2.50M, "http://catalogbaseurltobereplaced/images/products/2.png", 29),
                new(1,1, "Twix", "Twix", 2.0M,  "http://catalogbaseurltobereplaced/images/products/3.png", 25),
                new(3,2, "Jolly Ranchers", "Jolly Ranchers", 4.0M, "http://catalogbaseurltobereplaced/images/products/4.png", 11),
                new(1,2, "Milk Chocolate", "Milk Chocolate", 1.5M, "http://catalogbaseurltobereplaced/images/products/5.png", 24),
                new(1,2, "Reese's", "Reese's", 2.0M, "http://catalogbaseurltobereplaced/images/products/6.png", 22),
                new(1,3, "Crunch", "Crunch",  1.8M, "http://catalogbaseurltobereplaced/images/products/7.png", 24),
                new(1,3, "Butterfinger", "Butterfinger", 2.0M, "http://catalogbaseurltobereplaced/images/products/8.png", 28),
                new(3,3, "Smarties", "Smarties", 3.0M, "http://catalogbaseurltobereplaced/images/products/9.png", 6),
                new(2,4, "Extra Gum", "Extra Gum", 12, "http://catalogbaseurltobereplaced/images/products/10.png", 0),
                new(4,5, "Candy Canes", "Candy Canes", 5.0M, "http://catalogbaseurltobereplaced/images/products/11.png", 14),
                new(3,5, "Dum-Dums", "Dum-Dums", 4.5M, "http://catalogbaseurltobereplaced/images/products/12.png", 9)
            };
        }
    }
}
