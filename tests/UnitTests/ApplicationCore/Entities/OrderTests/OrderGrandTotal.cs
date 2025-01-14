﻿using Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;
using Microsoft.eShopWeb.UnitTests.Builders;
using System.Collections.Generic;
using Xunit;

namespace Microsoft.eShopWeb.UnitTests.ApplicationCore.Entities.OrderTests
{
    public class OrderGrandTotal
    {
        private decimal _testUnitPrice = 42m;

        [Fact]
        public void IsZeroForNewOrder()
        {
            var order = new OrderBuilder().WithNoItems();

            Assert.Equal(0, order.Total());
        }

        [Fact]
        public void IsCorrectGiven1Item()
        {
            var builder = new OrderBuilder();
            var items = new List<OrderItem>
            {
                new OrderItem(builder.TestCatalogItemOrdered, _testUnitPrice, 1)
            };
            var order = new OrderBuilder().WithItems(items);
            var tax = order.Tax();
            
            Assert.Equal(_testUnitPrice + tax, order.GrandTotal());
        }

        [Fact]
        public void IsCorrectGiven3Items()
        {
            var builder = new OrderBuilder();
            var order = builder.WithDefaultValues();
            var tax = order.Tax();
            Assert.Equal((builder.TestUnitPrice * builder.TestUnits) + tax, order.GrandTotal());
        }
    }
}
