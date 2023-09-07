namespace CSharpFeaturesExercise;

public class CSharp10
{
    [Theory]
    [MemberData(nameof(TripData))]
    
    public void Trip_Switch(Trip trip, string expectedResult)
    {
        // arrange - empty

        // act
        var result = ResolveTrip(trip);

        // assert
        result.Should().Be(expectedResult);
    }

    private string ResolveTrip(Trip trip) {
        Type tripType = trip.GetType();
        
        if (tripType == typeof(MountainTrip)){
            var mountainTrip = trip as MountainTrip;

            if (mountainTrip.Elevation >= 3500){
                return $"Mountain trip with high elevation and {mountainTrip.Expense.MoneySpent} spent";
            }
            else if (mountainTrip.Elevation > 1500 && mountainTrip.Elevation < 3500){
                return $"Mountain trip with middle elevation";
            }
            else {
                return $"Mountain trip with low elevation";
            }
        }
        else if (tripType == typeof(SeaTrip)){
            var seaTrip = trip as SeaTrip;

            if (seaTrip.NumberOfDrinks > 10){
                return "You shouldn't drink so much on sea trip";
            } 
            else {
                return "A nice sea trip";
            }
        }
        else {
            if (trip.Expense.MoneySpent >= 5000){
                return "Phew this was an expensive trip";
            }
            else if (trip.Expense.MoneySpent >= 1000 && trip.Expense.MoneySpent < 5000) {
                return $"Reasonably priced general trip to {trip.Destination}";
            }
        }

        return "No matched trip";
    }

    public class Trip {
        public string Destination { get; set; }

        public Expense Expense { get; set; } 
    }

    private class MountainTrip : Trip {
        public int Elevation { get; set; }
    }

    private class SeaTrip : Trip {
        public int NumberOfDrinks { get; set; }
    }

    public class Expense {
        public int MoneySpent { get; set; }
        public string[] Items { get; set; }
    }
 
    public static IEnumerable<object[]> TripData() {

        yield return new object [] {
            new Trip() { Destination = "Mallorca", Expense = new() { MoneySpent = 1500 } },
            "Reasonably priced general trip to Mallorca"
        };

        yield return new object [] {
            new MountainTrip() { Destination = "Alpes", Elevation = 3850, Expense = new() { MoneySpent = 1800 } },
            "Mountain trip with high elevation and 1800 spent"
        };

        yield return new object [] {
            new Trip() { Destination = "Rocky Mountains", Expense = new() { MoneySpent = 6000 } },
            "Phew this was an expensive trip"
        };

        yield return new object [] {
            new SeaTrip() { Destination = "Istria", NumberOfDrinks = 6 },
            "A nice sea trip"
        };

        yield return new object [] {
            new SeaTrip() { Destination = "Ibiza", NumberOfDrinks = 15 },
            "You shouldn't drink so much on sea trip"
        };

        yield return new object [] {
            new Trip() { Destination = "Brno city centre", Expense = new() { MoneySpent = 500 } },
            "No matched trip"
        };
    }
   
}