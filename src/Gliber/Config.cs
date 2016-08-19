namespace Gliber
{
    using System;

    internal class Config : IConfig
    {
        public object SourceType { get; set; }

        public object TargetType { get; set; }

        public bool HasOneToOneMapping { get; set; }
    }
}