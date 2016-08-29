namespace Gliber.Tests
{
    using System;

    using Xunit;

    
    public class OneToOneMapperTest
    {
        [Fact]
        public void In_One_To_One_Mapping_The_Mapped_Object_Cannot_Be_Null()
        {

            var src = new Source { IntProp = 100, StrProp = "Afzal" };
            var mapper = new GlibMapper<Source, Target>();
            mapper.WithOneToOneMappingForAll().CreateMap(src);

            Assert.NotNull(mapper.MappedObject);
        }

        [Fact]
        public void Exception_Must_Be_Thrown_If_Source_And_Target_Are_Different()
        {
            var src = new Source { IntProp = 100, StrProp = "Afzal" };
            var mapper = new GlibMapper<Source, Target2>();


            Assert.Throws<Exception>(
                () =>
                    {
                        mapper.WithOneToOneMappingForAll().CreateMap(src);
                    });
        }
    }

    

    public class Source
    {
        public int IntProp { get; set; }

        public string StrProp { get; set; }
    }

    public class Target
    {
        public int IntProp { get; set; }

        public string StrProp { get; set; }
    }

    public class Target2
    {
        public int IntProp { get; set; }

        public string StrProp { get; set; }

        public decimal DecProp { get; set; }
    }

}
