namespace CSharpFeaturesExercise;

public class CSharp9
{
    [Fact]
    public void Classes()
    {
        // arrange
        Building building = new Building  // HINT: Is it really needed to duplicate the type here?
        { 
            Area = 1500,
            Floors = 3,
            Address = new Address // HINT: The same as above
            {
                Country = "CZ",
                City = "Olomouc",
                Street = "Vejdovského",
                HouseNumber = 50,
            }  
        };

        // act
        Building buildingCopy = (Building)building.Clone();
        buildingCopy.Address.City = "Brno";
        buildingCopy.Area = 1000;

        // assert

        // the original should be the same 
        building.Area.Should().Be(1500);
        building.Address.City.Should().Be("Olomouc");

        // the copy should be modified
        buildingCopy.Area.Should().Be(1000);
        buildingCopy.Address.City.Should().Be("Brno");
    }

    // HINT: These classes seem rather simple, do we need to define them as classes? Can we get around the need to ICloneable somehow?
    public class Building : ICloneable {
        public int Area { get; set; }
        public int Floors { get; set; }
        public Address Address { get; set; }

        public object Clone()
        {
            return new Building 
            {
                Area = Area,
                Floors = 5,
                Address = new Address 
                {
                    Country = Address.Country,
                    City = Address.City,
                    Street = Address.Street,
                    HouseNumber = Address.HouseNumber
                },
            };
        }
    }

    public class Address {
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int HouseNumber { get; set; }
    }
   
}