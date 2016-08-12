using System;

namespace Gliber
{
    using System.ComponentModel;
    using Microsoft.Extensions.DependencyInjection;

    public class GlibMapper
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
            this.serviceProvider = this.serviceCollection.BuildServiceProvider();
            this.serviceCollection.AddSingleton<ITarget, Target>();
            this.serviceCollection.AddSingleton<IConfig, Config>();

        }
        public ITarget MapFrom<TSrc>() where TSrc : class
        {
            this.serviceProvider.GetService<IConfig>().SourceType = typeof(TSrc);
          return this.serviceProvider.GetService<ITarget>();
        }
    }

    public class Target :ITarget
    {
        private readonly IServiceProvider serviceProvider;

        internal Target(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public IOptions MapTo<TTgt>()
        {
            this.serviceProvider.GetService<IConfig>().SourceType = typeof(TTgt);
            return this.serviceProvider.GetService<IOptions>();
        }


    }

    public interface ITarget
    {
        IOptions MapTo<T>();

       
    }

    public interface IOptions
    {
    }

    internal interface IConfig
    {
        Type SourceType { get; set; }
        Type TargetType { get; set; }
    }

    class Config : IConfig
    {
        public Type SourceType { get; set; }

        public Type TargetType { get; set; }
    }
}