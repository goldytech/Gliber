namespace Gliber
{
    using System.Collections.Generic;

    using Newtonsoft.Json;

    internal class SelectivePropertiesMapper<TSrc, TTgt> : IMapper<TSrc, TTgt>
    {
        private readonly IMappingValidator mappingValidator;

        private IEnumerable<string> selectedpropertiesofSource;

        public SelectivePropertiesMapper(IMappingValidator mappingValidator, IEnumerable<string> selectedpropertiesofSource)
        {
            this.mappingValidator = mappingValidator;
            this.selectedpropertiesofSource = selectedpropertiesofSource;
        }

        public void CreateMap(TSrc source)
        {
            this.mappingValidator.ForMappingSourceAndTargetPropertiesMustBeMatched<TSrc, TTgt>();
            if (this.mappingValidator.Exception != null)
            {
                throw this.mappingValidator.Exception;
            }

            var json = JsonConvert.SerializeObject(source, Formatting.Indented, new SelectivePropertiesJsonConverter<TSrc>(this.selectedpropertiesofSource));
            var mappedObject = JsonConvert.DeserializeObject<TTgt>(json);
            this.Publish<TTgt>(mappedObject);
        }
    }
}