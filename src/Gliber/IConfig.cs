namespace Gliber
{
    using System;

    internal interface IConfig
    {
        object SourceType { get; set; }
        object TargetType { get; set; }

        bool HasOneToOneMapping { get; set; }
    }
}