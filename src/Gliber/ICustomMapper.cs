namespace Gliber
{
    using System;
    using System.Linq.Expressions;

    /// <summary>
    /// The CustomMapper interface.
    /// </summary>
    /// <typeparam name="TSrc">
    /// </typeparam>
    /// <typeparam name="TTgt">
    /// </typeparam>
    /// <typeparam name="TProp">
    /// </typeparam>
    public interface ICustomMapper<TSrc, TTgt, TProp>
    {
        /// <summary>
        /// The map to.
        /// </summary>
        /// <param name="propertyExpression">
        /// The property expression.
        /// </param>
        /// <typeparam name="TProp">
        /// </typeparam>
        /// <returns>
        /// The <see cref="IMapper"/>.
        /// </returns>
        IMapper<TSrc, TTgt> MapTo<TProp>(Expression<Func<TTgt, TProp>> propertyExpression);
    }
}