﻿// Copyright (c) Christof Senn. All rights reserved. See license.txt in the project root for license information.

using Common.Model;
using Common.ServiceContracts;
using Remote.Linq.Dynamic;
using Remote.Linq.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Server
{
    public class QueryService : IQueryService
    {
        private static readonly Func<Type, IQueryable> _queryableResourceProvider = type =>
        {
            var dataStore = InMemoryDataStore.Instance;

            if (type == typeof(ProductCategory)) return dataStore.ProductCategories.AsQueryable();
            if (type == typeof(Product)) return dataStore.Products.AsQueryable();
            if (type == typeof(OrderItem)) return dataStore.OrderItems.AsQueryable();

            throw new Exception(string.Format("No queryable resource available for type {0}", type));
        };

        public IEnumerable<DynamicObject> ExecuteQuery(Expression queryExpression)
        {
            var mapper = new DynamicObjectMapper(knownTypes: new[] { typeof(OrderItem), typeof(Product), typeof(ProductCategory) });

            return queryExpression.Execute(_queryableResourceProvider, mapper: mapper);
        }
    }
}
