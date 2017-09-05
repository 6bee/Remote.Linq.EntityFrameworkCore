// Copyright (c) Christof Senn. All rights reserved. See license.txt in the project root for license information.

using Aqua.Dynamic;
using Aqua.TypeSystem;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Remote.Linq.EntityFrameworkCore
{
    public static class RemoteEntityFrameworkCoreQueryable
    {
        public static IQueryable Create(Type elementType, Func<Expressions.Expression, IEnumerable<DynamicObject>> dataProvider, ITypeResolver typeResolver = null, IDynamicObjectMapper mapper = null, Func<System.Linq.Expressions.Expression, bool> canBeEvaluatedLocally = null)
            => RemoteQueryable.Create(elementType, dataProvider, typeResolver, mapper, canBeEvaluatedLocally.And(ExpressionEvaluator.CanBeEvaluated));

        public static IQueryable<T> Create<T>(Func<Expressions.Expression, IEnumerable<DynamicObject>> dataProvider, ITypeResolver typeResolver = null, IDynamicObjectMapper mapper = null, Func<System.Linq.Expressions.Expression, bool> canBeEvaluatedLocally = null)
            => RemoteQueryable.Create<T>(dataProvider, typeResolver, mapper, canBeEvaluatedLocally.And(ExpressionEvaluator.CanBeEvaluated));

        public static IQueryable Create(Type elementType, Func<Expressions.Expression, object> dataProvider, ITypeResolver typeResolver = null, IQueryResultMapper<object> resultMapper = null, Func<System.Linq.Expressions.Expression, bool> canBeEvaluatedLocally = null)
            => RemoteQueryable.Create(elementType, dataProvider, typeResolver, resultMapper, canBeEvaluatedLocally.And(ExpressionEvaluator.CanBeEvaluated));

        public static IQueryable<T> Create<T>(Func<Expressions.Expression, object> dataProvider, ITypeResolver typeResolver = null, IQueryResultMapper<object> resultMapper = null, Func<System.Linq.Expressions.Expression, bool> canBeEvaluatedLocally = null)
            => RemoteQueryable.Create<T>(dataProvider, typeResolver, resultMapper, canBeEvaluatedLocally.And(ExpressionEvaluator.CanBeEvaluated));

        public static IQueryable Create<TSource>(Type elementType, Func<Expressions.Expression, TSource> dataProvider, IQueryResultMapper<TSource> resultMapper, ITypeResolver typeResolver = null, Func<System.Linq.Expressions.Expression, bool> canBeEvaluatedLocally = null)
            => RemoteQueryable.Create<TSource>(elementType, dataProvider, resultMapper, typeResolver, canBeEvaluatedLocally.And(ExpressionEvaluator.CanBeEvaluated));

        public static IQueryable<T> Create<T, TSource>(Func<Expressions.Expression, TSource> dataProvider, IQueryResultMapper<TSource> resultMapper, ITypeResolver typeResolver = null, Func<System.Linq.Expressions.Expression, bool> canBeEvaluatedLocally = null)
            => RemoteQueryable.Create<T, TSource>(dataProvider, resultMapper, typeResolver, canBeEvaluatedLocally.And(ExpressionEvaluator.CanBeEvaluated));
    }
}
