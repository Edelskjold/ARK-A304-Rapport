[TestMethod]
    public void GetActiveTrip_WithTrip_ReturnTrip()
    {
        // Arrange
        Boat boat = new Boat();
        Trip trip = new Trip();
        boat.Trips = new List<Trip>();
        boat.Trips.Add(trip);
        Trip expected = trip;

        // Act
        Trip actual = boat.GetActiveTrip;

        // Assert
        Assert.AreEqual(expected, actual);
    }