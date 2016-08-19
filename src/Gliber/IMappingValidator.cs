namespace Gliber
{
    using System;

    internal interface IMappingValidator
    {
        Exception Exception { get; }

        void ForOneToOneMappingSourceAndTargetPropertiesMustMatch<TSrc, TTgt>();
    }
}