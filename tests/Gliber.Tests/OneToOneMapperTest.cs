namespace Gliber.Tests
{
    using Xunit;
    using Gliber;
    public class OneToOneMapperTest
    {
        [Fact]
        public void In_One_To_One_Mapping_The_Properties_Count_InBoth_EntitiesShouldBeSame()
        {

            var mapper = new GlibMapper();
            mapper.MapFrom<Source>().MapTo<Target>();


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
