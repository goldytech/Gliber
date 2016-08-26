namespace Gliber
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Reflection;

    internal interface IConfig
    {
         IEnumerable<string> SelectedPropertiesOfSourceObject { get; set; }

        bool HasOneToOneMapping { get; set; }
    }
}