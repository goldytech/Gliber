namespace Gliber
{
    using System;
    using System.Linq;
    using System.Reflection;

    internal class MappingValidator : IMappingValidator
    {
        public Exception Exception { get; private set; }

        public MappingValidator()
        {
            this.Exception = null;
        }
        public void ForOneToOneMappingSourceAndTargetPropertiesMustMatch<TSrc, TTgt>()
        {
            var sourceProperties = typeof(TSrc).GetProperties();
            var targetProperties = typeof(TTgt).GetProperties();
            var unmappedTargets = targetProperties.Where(t => !sourceProperties.Any(s => s.Name.Equals(t.Name))).ToArray();
            var unmappedsources = targetProperties.Where(s => !targetProperties.Any(t => t.Name.Equals(s.Name))).ToArray();

            if (!unmappedsources.Any() && !unmappedTargets.Any())
            {
                return;
            }

            var targetStrings = unmappedTargets.Select(x => typeof(TTgt).Name + "." + x.Name);
            var srcStrings = unmappedsources
                .Select(x => typeof(TSrc).Name + "." + x.Name);

            var exceptionMessage = "Unmapped properties: "
                                   + string.Join(", ", targetStrings.OrderBy(x => x).Concat(srcStrings.OrderBy(x => x)));
            this.Exception = new Exception(exceptionMessage);
        }
    }
}