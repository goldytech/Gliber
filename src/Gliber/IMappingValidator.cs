namespace Gliber
{
    using System;

    internal interface IMappingValidator
    {
        Exception Exception { get; }

        void ForMappingSourceAndTargetPropertiesMustBeMatched<TSrc, TTgt>();
    }
}