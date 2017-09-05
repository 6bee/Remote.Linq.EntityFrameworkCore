// Copyright (c) Christof Senn. All rights reserved. See license.txt in the project root for license information.

namespace Remote.Linq.EntityFrameworkCore
{
    using Aqua.Dynamic;
    using Aqua.TypeSystem;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class RemoteQueryableFactoryExtensions
    {
        public static IQueryable CreateEntityFrameworkCoreQueryable(this RemoteQueryableFactory factory, Type elementType, Func<Expressions.Expression, IEnumerable<DynamicObject>> dataProvider, ITypeResolver typeResolver = null, IDynamicObjectMapper mapper = null, Func<System.Linq.Expressions.Expression, bool> canBeEvaluatedLocally = null)
            => factory.Create(elementType, dataProvider, typeResolver, mapper, canBeEvaluatedLocally.And(ExpressionEvaluator.CanBeEvaluated));

        public static IQueryable<T> CreateEntityFrameworkCoreQueryable<T>(this RemoteQueryableFactory factory, Func<Expressions.Expression, IEnumerable<DynamicObject>> dataProvider, ITypeResolver typeResolver = null, IDynamicObjectMapper mapper = null, Func<System.Linq.Expressions.Expression, bool> canBeEvaluatedLocally = null)
            => factory.Create<T>(dataProvider, typeResolver, mapper, canBeEvaluatedLocally.And(ExpressionEvaluator.CanBeEvaluated));

        public static IQueryable CreateEntityFrameworkCoreQueryable(this RemoteQueryableFactory factory, Type elementType, Func<Expressions.Expression, object> dataProvider, ITypeResolver typeResolver = null, IQueryResultMapper<object> resultMapper = null, Func<System.Linq.Expressions.Expression, bool> canBeEvaluatedLocally = null)
            => factory.Create(elementType, dataProvider, typeResolver, resultMapper, canBeEvaluatedLocally.And(ExpressionEvaluator.CanBeEvaluated));

        public static IQueryable<T> CreateEntityFrameworkCoreQueryable<T>(this RemoteQueryableFactory factory, Func<Expressions.Expression, object> dataProvider, ITypeResolver typeResolver = null, IQueryResultMapper<object> resultMapper = null, Func<System.Linq.Expressions.Expression, bool> canBeEvaluatedLocally = null)
            => factory.Create<T>(dataProvider, typeResolver, resultMapper, canBeEvaluatedLocally.And(ExpressionEvaluator.CanBeEvaluated));

        public static IQueryable CreateEntityFrameworkCoreQueryable<TSource>(this RemoteQueryableFactory factory, Type elementType, Func<Expressions.Expression, TSource> dataProvider, IQueryResultMapper<TSource> resultMapper, ITypeResolver typeResolver = null, Func<System.Linq.Expressions.Expression, bool> canBeEvaluatedLocally = null)
            => factory.Create<TSource>(elementType, dataProvider, resultMapper, typeResolver, canBeEvaluatedLocally.And(ExpressionEvaluator.CanBeEvaluated));

        public static IQueryable<T> CreateEntityFrameworkCoreQueryable<T, TSource>(this RemoteQueryableFactory factory, Func<Expressions.Expression, TSource> dataProvider, IQueryResultMapper<TSource> resultMapper, ITypeResolver typeResolver = null, Func<System.Linq.Expressions.Expression, bool> canBeEvaluatedLocally = null)
            => factory.Create<T, TSource>(dataProvider, resultMapper, typeResolver, canBeEvaluatedLocally.And(ExpressionEvaluator.CanBeEvaluated));
    }
}
