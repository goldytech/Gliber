using System;
using System.Linq.Expressions;

namespace Gliber
{
    using Newtonsoft.Json;

    public static class Extensions
    {
        public static string NameOf<TModel, TProperty>(this object @object, Expression<Func<TModel, TProperty>> propertyExpression)
        {
            var expression = propertyExpression.Body as MemberExpression;
           
            if (expression == null)
            {
                throw new ArgumentException("Expression is not a property.");
            
            }

            return expression.Member.Name;
        }
    }
}
