namespace Gliber
{
    using System.Collections.Generic;
    using System.Reflection;

    internal class Config : IConfig
    {
        public Config()
        {
            this.SelectedPropertiesOfSourceObject = null;
            this.HasOneToOneMapping = false;
        }
        public IEnumerable<string> SelectedPropertiesOfSourceObject { get; set; }

        public bool HasOneToOneMapping { get; set; }
    }
}