namespace Gliber
{
    using System;

    using Microsoft.Extensions.DependencyInjection;

    using Newtonsoft.Json;

   internal class Mapper<TSrc, TTgt> : IMapper<TSrc, TTgt>
    {
        

      

       

        public void CreateMap(TSrc source)
        {
            var json = JsonConvert.SerializeObject(source);
            var mappedObject = JsonConvert.DeserializeObject<TTgt>(json);
          this.Publish<TTgt>(mappedObject);
        }
   }
}