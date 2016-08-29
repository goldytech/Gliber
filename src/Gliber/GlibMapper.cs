using System;

namespace Gliber
{
    using System.Collections.Generic;

    using Microsoft.Extensions.DependencyInjection;
   

    public class GlibMapper<TSrc, TTgt> 
    {
        /// <summary>
        /// The service collection.
        /// </summary>
        private readonly IServiceCollection serviceCollection;

        /// <summary>
        /// The service provider.
        /// </summary>
        private readonly IServiceProvider serviceProvider;

        public GlibMapper()
        {
         this.serviceCollection = new ServiceCollection();

          //  this.serviceCollection.AddSingleton<IGlibMapper<TSrc, TTgt>, GlibMapper<TSrc, TTgt>>();
           // this.serviceCollection.AddSingleton<IConfig, Config>();
            this.serviceCollection.AddTransient<IMappingValidator, MappingValidator>(); 
          //this.serviceCollection.AddTransient<IMapper<TSrc, TTgt>, OneToOneMapper<TSrc, TTgt>>();
            this.serviceProvider = this.serviceCollection.BuildServiceProvider();
            this.Subscribe<TTgt>(
                (tgt) =>
                    {
                        this.MappedObject = tgt;
                      //  this.Unsubscribe<TTgt>();
                    }
                   );
        }

        public TTgt MappedObject { get; private set; }

        //private Func<IServiceProvider, Target> TargetFactory()
        //{
        //    return this.GetTarget;
        //}

        //private Target GetTarget(IServiceProvider serviceProvider)
        //{
        //    return new Target(this.serviceProvider);
        //}

        public IMapper<TSrc, TTgt> WithOneToOneMappingForAll()
        {
          //  this.serviceProvider.GetService<IConfig>().HasOneToOneMapping = true;
            //this.serviceProvider.GetService<IConfig>().SelectedPropertiesOfSourceObject = null;
            //return this.serviceProvider.GetService<IMapper<TSrc,TTgt>>();
            return new OneToOneMapper<TSrc, TTgt>(this.serviceProvider.GetService<IMappingValidator>());
        }

        /// <summary>
        /// The with selective properties from source.
        /// </summary>
        /// <param name="propertiestobeMapped">
        /// The property expression.
        /// </param>
        /// <typeparam name="TProp">
        /// </typeparam>
        /// <returns>
        /// The <see cref="IMapper"/>.
        /// </returns>
        public IMapper<TSrc, TTgt> WithSelectivePropertiesFromSource(IEnumerable<string> propertiestobeMapped)
        {
           // this.serviceProvider.GetService<IConfig>().SelectedPropertiesOfSourceObject = propertiestobeMapped;
            //this.serviceProvider.GetService<IConfig>().HasOneToOneMapping = false;
           // return this.serviceProvider.GetService<IMapper<TSrc, TTgt>>();
           return new SelectivePropertiesMapper<TSrc, TTgt>(this.serviceProvider.GetService<IMappingValidator>(), propertiestobeMapped);
        }

        //public ITarget MapFrom<TSrc>()
        //{
        //    this.serviceProvider.GetService<IConfig>().SourceType = Activator.CreateInstance(typeof(TSrc));
        //      return this.serviceProvider.GetService<ITarget>();
        //    }
        //}

        //public class OneToOneMapper : IMapper
        //{
        //    private readonly IServiceProvider serviceProvider;

        //    public OneToOneMapper(IServiceProvider serviceProvider)
        //    {
        //        this.serviceProvider = serviceProvider;
        //    }

        //    //public TTgt CreateMap<TTgt>()
        //    //{

        //    //    var config = this.serviceProvider.GetRequiredService<IConfig>();
        //    //    var sourceEntity = config.SourceType;
        //    //    var targetEnity = config.TargetType;
        //    //    var json = JsonConvert.SerializeObject(sourceEntity);
        //    //    var target = JsonConvert.DeserializeObject<TTgt>(json);
        //    //    return target;

        //    //}

        //    //private TTgt Map<TSrc, TTgt>(TSrc source)
        //    //{
        //    //    var json = JsonConvert.SerializeObject(source);
        //    //    return JsonConvert.DeserializeObject<TTgt>(json);
        //    //}
        //}
        public void OnCompleted()
        {
            
        }

        public void OnError(Exception error)
        {
            
        }

        public void OnNext(TTgt value)
        {
            this.MappedObject = value;
        }
    }
}