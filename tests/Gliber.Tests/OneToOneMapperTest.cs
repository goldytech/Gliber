namespace Gliber.Tests
{
    using Xunit;

    public class OneToOneMapperTest
    {
        [Fact]
        public void In_One_To_One_Mapping_The_Properties_Count_InBoth_EntitiesShouldBeSame()
        {

            var src = new Source { IntProp = 100, StrProp = "Afzal" };
            var mapper = new GlibMapper<Source, Target>();
            mapper.WithOneToOneMapping().CreateMap(src);

            Assert.NotNull(mapper.MappedObject);
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

}
