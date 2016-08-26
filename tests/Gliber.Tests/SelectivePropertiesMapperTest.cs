namespace Gliber.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Reflection;
    using Xunit;

    public class SelectivePropertiesMapperTest
    {
        [Fact]
        public void When_Selective_Properties_Is_Configured_Then_Only_Selected_Properties_Must_Be_Mapped()
        {
            //ARRANGE
            var mapper = new GlibMapper<Source, Target>();
            var src = new Source { IntProp = 100, StrProp = "Afzal" };

            // Only map StrProp and Ignoring IntProp of the source object
            var propertiesNameList = new List<string> { this.NameOf((Source s) => s.StrProp) };

            mapper.WithSelectivePropertiesFromSource(propertiesNameList).CreateMap(src);

            // assert that integer property is not mapped on target object , hence its value is 0
            Assert.Equal(0, mapper.MappedObject.IntProp);
         }

        [Fact]
        public void When_Property_Is_Not_There_InTargetObject_Then_Exception_Must_Be_Thrown()
        {
            var mapper = new GlibMapper<Source, TargetWithMissingProperty>();
            var src = new Source { IntProp = 100, StrProp = "Afzal" };
            var propertiesNameList = new List<string> { this.NameOf((Source s) => s.StrProp) };
            Assert.Throws<Exception>(() =>
            {
                mapper.WithSelectivePropertiesFromSource(propertiesNameList).CreateMap(src);
            });
        }
    }

   internal class TargetWithMissingProperty
    {
        public int SomeProperty { get; set; }
    }
}