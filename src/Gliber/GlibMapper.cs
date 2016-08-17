using System;

namespace Gliber
{
    using Microsoft.Extensions.DependencyInjection;

    using Newtonsoft.Json;

    public interface IGlibMapper<TSrc, TTgt>
    {
        TTgt MappedObject { get; }

        IMapper<TSrc, TTgt> WithOneToOneMapping();
    }

    public class GlibMapper<TSrc, TTgt> : IObserver<TTgt>, IGlibMapper<TSrc, TTgt>
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

            this.serviceCollection.AddSingleton<IGlibMapper<TSrc, TTgt>, GlibMapper<TSrc, TTgt>>();  
          this.serviceCollection.AddSingleton<IMapper<TSrc, TTgt>, Mapper<TSrc, TTgt>>();
            this.serviceProvider = this.serviceCollection.BuildServiceProvider();
            this.Subscribe<TTgt>(
                (tgt) =>
                    {
                        this.MappedObject = tgt;
                        this.Unsubscribe();
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

        public IMapper<TSrc, TTgt> WithOneToOneMapping()
        {
            return this.serviceProvider.GetService<IMapper<TSrc,TTgt>>();
        }

        //public ITarget MapFrom<TSrc>()
        //{
        //    this.serviceProvider.GetService<IConfig>().SourceType = Activator.CreateInstance(typeof(TSrc));
        //      return this.serviceProvider.GetService<ITarget>();
        //    }
        //}

        //public class Mapper : IMapper
        //{
        //    private readonly IServiceProvider serviceProvider;

        //    public Mapper(IServiceProvider serviceProvider)
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