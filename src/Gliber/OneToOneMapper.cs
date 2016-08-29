namespace Gliber
{
    using System;
    using Newtonsoft.Json;

    internal class OneToOneMapper<TSrc, TTgt> : IMapper<TSrc, TTgt>
    {
        /// <summary>
        /// The mapping validator.
        /// </summary>
        private readonly IMappingValidator mappingValidator;

      public OneToOneMapper(IMappingValidator mappingValidator)
        {
            this.mappingValidator = mappingValidator;
            
        }

        public ICustomMapper<TSrc, TTgt, TProp> AddCustomMappingFor<TProp>(System.Linq.Expressions.Expression<Func<TSrc, TProp>> propertyExpression)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The create map.
        /// </summary>
        /// <param name="source">
        /// The source.
        /// </param>
        public void CreateMap(TSrc source)
        {
            this.mappingValidator.ForMappingSourceAndTargetPropertiesMustBeMatched<TSrc, TTgt>();
            if (this.mappingValidator.Exception != null)
            {
                throw this.mappingValidator.Exception;
            }
            var json = string.Empty;
            
               json = JsonConvert.SerializeObject(source);
            //}

            //if (this.config.SelectedPropertiesOfSourceObject != null)
            //{
            //     json = JsonConvert.SerializeObject(source, Formatting.Indented, new SelectivePropertiesJsonConverter<TSrc>(this.config.SelectedPropertiesOfSourceObject));
            //}

            var mappedObject = JsonConvert.DeserializeObject<TTgt>(json);
            this.Publish<TTgt>(mappedObject);
        }
    }
}