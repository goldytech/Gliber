namespace Gliber
{
    using System;
    using System.Linq.Expressions;

    /// <summary>
    /// The OneToOneMapper interface.
    /// </summary>
    /// <typeparam name="TSrc">
    /// </typeparam>
    /// <typeparam name="TTgt">
    /// </typeparam>
    public interface IMapper<TSrc, TTgt>
    {
        /// <summary>
        /// The create map.
        /// </summary>
        /// <param name="source">
        /// The source.
        /// </param>
        /// <returns>
        /// The <see cref="TTgt"/>.
        /// </returns>
        void CreateMap(TSrc source);

        /// <summary>
        /// The except for.
        /// </summary>
        /// <param name="propertyExpression">
        /// The property Expression.
        /// </param>
        /// <typeparam name="TProp">
        /// </typeparam>
        /// <returns>
        /// The <see cref="ICustomMapper"/>.
        /// </returns>
        ICustomMapper<TSrc, TTgt, TProp> AddCustomMappingFor<TProp>(Expression<Func<TSrc, TProp>> propertyExpression);
    }
}