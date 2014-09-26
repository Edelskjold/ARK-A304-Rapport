[TestMethod]
    public void TimeBoatOut_Wait5Secs_Return5()
    {
        // Arrange
        Trip trip = new Trip();
        trip.TripStartTime = DateTime.Now;
        int expected = 5;

        // Act
        System.Threading.Thread.Sleep(5000);
        int actual = (int)trip.TimeBoatOut.TotalSeconds;

        // Assert
        Assert.AreEqual(expected, actual);
    }