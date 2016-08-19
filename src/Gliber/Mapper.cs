namespace Gliber
{
    using Microsoft.Extensions.DependencyInjection;

    using Newtonsoft.Json;

    internal class Mapper<TSrc, TTgt> : IMapper<TSrc, TTgt>
    {
        /// <summary>
        /// The mapping validator.
        /// </summary>
        private readonly IMappingValidator mappingValidator;

        public Mapper(IMappingValidator mappingValidator)
        {
            this.mappingValidator = mappingValidator;
        }

        /// <summary>
        /// The create map.
        /// </summary>
        /// <param name="source">
        /// The source.
        /// </param>
        public void CreateMap(TSrc source)
        {
            this.mappingValidator.ForOneToOneMappingSourceAndTargetPropertiesMustMatch<TSrc, TTgt>();
            if (this.mappingValidator.Exception != null)
            {
                throw this.mappingValidator.Exception;
            }

            var json = JsonConvert.SerializeObject(source);
            var mappedObject = JsonConvert.DeserializeObject<TTgt>(json);
            this.Publish<TTgt>(mappedObject);
        }
    }
}