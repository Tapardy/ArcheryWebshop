using VisitorPlacementTool4;

namespace UnitTest
{
    public class StoelTests
    {
        [Test]
        public void CanAssignStoelToBezoeker_PositiveTest() //checks if the stoel can be assigned to the bezoeker
        {
            // Arrange
            Stoel stoel = new Stoel(1);
            Bezoeker bezoeker = new Bezoeker(1);

            // Act
            var canAssignStoel = stoel.CanAssignStoelToBezoeker(bezoeker);

            // Assert
            Assert.IsTrue(canAssignStoel); 
        }
        
        [Test]
        public void CanAssignStoelToBezoeker_NegativeTest() //checks if the stoel can be assigned to the bezoeker
        {
            // Arrange
            Stoel stoel = new Stoel(1);
            Bezoeker bezoeker1 = new Bezoeker(1);
            Bezoeker bezoeker2 = new Bezoeker(2);
            stoel.CanAssignStoelToBezoeker(bezoeker1);

            // Act
            var canAssignStoel = stoel.CanAssignStoelToBezoeker(bezoeker2);

            // Assert
            Assert.IsFalse(canAssignStoel); 
        }
    }
}