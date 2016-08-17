namespace Gliber
{
    /// <summary>
    /// The Mapper interface.
    /// </summary>
    /// <typeparam name="TSrc">
    /// </typeparam>
    /// <typeparam name="TTgt">
    /// </typeparam>
    public interface IMapper<in TSrc, out TTgt>
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
    }
}