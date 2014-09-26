[TestMethod]
    public void GetSunsetFromXml_WithData_ReturnDateTime()
    {
        // Arrange
        DateTime expected = DateTime.Today;

        // Act
        DateTime actual = XmlParser.GetSunsetFromXml();

        // Assert - Tests that today's sunset time was found
        Assert.AreEqual(expected.Date, actual.Date);
    }