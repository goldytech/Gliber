using Xunit;

namespace Gliber.Tests
{
    public class CustomMapperTests
    {
        [Fact]
        public void With_Custom_Mapping_Target_Object_Must_Be_Mapper_With_Custom()
        {
            var customerdto = new CustomerDto { Name = "Afzal", City = "XX", State = "ABC", ZipCode = "098" };
            var mapper = new GlibMapper<CustomerDto, Customer>();
                                     mapper.WithOneToOneMappingForAll()
                                    .AddCustomMappingFor(x => x.City).MapTo(z => z.CustomerAddress.City)
                                    .AddCustomMappingFor(x => x.State).MapTo(z => z.CustomerAddress.State).CreateMap(customerdto);


        }
    }

    internal class Customer
    {
        public string Name { get; set; }

        public Address CustomerAddress { get; set; }
    }

    internal class CustomerDto
    {
        public string Name { get; set; }

        public string State { get; set; }
        public string City { get; set; }

        public string ZipCode { get; set; }
    }
    public class Address
    {
        public string State { get; set; }
        public string City { get; set; }

        public string ZipCode { get; set; }
    }
}