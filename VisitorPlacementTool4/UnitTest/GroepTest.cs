using VisitorPlacementTool4;

namespace UnitTest
{
    public class GroepTests
    {
        [Test]
        public void AddBezoeker_ShouldAddBezoekerToGroep_PositiveTest()  //checks if the bezoeker is in the list of bezoekers
        {
            // Arrange
            Groep groep = new Groep(1);
            Bezoeker bezoeker = new Bezoeker(1);

            // Act
            groep.AddBezoeker(bezoeker);
            var bezoekers = groep.Bezoekers();

            // Assert
            Assert.IsNotNull(bezoekers);
            Assert.AreEqual(1, bezoekers.Count());
            Assert.IsTrue(bezoekers.Contains(bezoeker));
        }

        [Test]
        public void GroepHasVolwassenen_ShouldReturnTrue_PositiveTest() //checks if the groep has volwassenen
        {
            // Arrange
            Groep groep = new Groep(1);
            Bezoeker volwassene = new Bezoeker(1);
            Bezoeker kind = new Bezoeker(1);

            // Set the ages of the visitors
            volwassene.Leeftijd = 25;
            kind.Leeftijd = 10;

            // Act
            groep.AddBezoeker(volwassene);
            groep.AddBezoeker(kind);
            bool hasVolwassenen = groep.GroepHasVolwassenen();

            // Assert
            Assert.IsTrue(hasVolwassenen); 
        }

        [Test]
        public void GroepHasVolwassenen_ShouldReturnFalse_NegativeTest() //checks if the groep has volwassenen
        {
            // Arrange
            Groep groep = new Groep(1);
            Bezoeker kind1 = new Bezoeker(1);
            Bezoeker kind2 = new Bezoeker(1);

            // Set the ages of the visitors
            kind1.Leeftijd = 10;
            kind2.Leeftijd = 12;

            // Act
            groep.AddBezoeker(kind1);
            groep.AddBezoeker(kind2);
            bool hasVolwassenen = groep.GroepHasVolwassenen();

            // Assert
            Assert.IsFalse(hasVolwassenen); 
        }

        [Test]
        public void RandomAanmeldingsDatum_ShouldReturnRandomDateTimeWithin30Days_PositiveTest() //checks if the aanmeldingsdatum is within 30 days
        {
            // Arrange
            Groep groep = new Groep(1);

            // Act
            DateTime aanmeldingsDatum = groep.RandomAanmeldingsDatum();
            TimeSpan timeSinceAanmelding = DateTime.Now - aanmeldingsDatum;

            // Assert
            Assert.LessOrEqual(timeSinceAanmelding.Days, 30); 
        }
        
        [Test]
        public void RandomAanmeldingsDatum_ShouldReturnRandomDateTimeOutside30Days_NegativeTest() //checks if the aanmeldingsdatum is outside 30 days
        {
            // Arrange
            Groep groep = new Groep(1);

            // Act
            DateTime aanmeldingsDatum = groep.RandomAanmeldingsDatum();
            TimeSpan timeSinceAanmelding = DateTime.Now - aanmeldingsDatum;

            // Assert
            Assert.GreaterOrEqual(timeSinceAanmelding.Days, 0); // Make sure the timeSinceAanmelding is non-negative
            Assert.Less(timeSinceAanmelding.Days, 30); // Check if the timeSinceAanmelding is less than 30 days
        }
    }
}