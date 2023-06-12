using VisitorPlacementTool4;

namespace UnitTest
{
    public class EvenementTests
    {
        [Test]
        public void CreateVakken_PositiveTest()  //checks if the number of vakken is equal to the number of vakken that were created
        {
            // Arrange
            Evenement evenement = new Evenement();
            int numVakken = 3;

            // Act
            evenement.CreateVakken(numVakken);
            var vakken = evenement.GetVakken();

            // Assert
            Assert.IsNotNull(vakken);
            Assert.AreEqual(numVakken, vakken.Count());
        }
        
        [Test]
        public void CreateVakken_NegativeTest() //checks if ArgumentOutOfRangeException is thrown when the number of vakken is negative
        {
            // Arrange
            Evenement evenement = new Evenement();
            int numVakken = -1;

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => evenement.CreateVakken(numVakken)); 
        }
        
        [Test]
        public void AssignBezoekersToStoelen_PositiveTest() //checks if the bezoekers are assigned to the stoelen
        {
            // Arrange
            Evenement evenement = new Evenement();
            evenement.CreateVakken(1);
            evenement.CreateGroepen(4);

            // Act
            evenement.AssignBezoekersToStoelen();

            // Assert
            var vakken = evenement.GetVakken();
            foreach (var vak in vakken)
            {
                var rijen = vak.GetRijen();
                foreach (var rij in rijen)
                {
                    var stoelen = rij.GetStoelen();
                    var assignedBezoekers = stoelen.Where(stoel => stoel.GetBezoeker() != null).Select(stoel => stoel.GetBezoeker()).ToList();
            
                    foreach (var assignedBezoeker in assignedBezoekers)
                    {
                        var assignedGroep = evenement.GetGroepen().FirstOrDefault(groep => groep.Bezoekers().Contains(assignedBezoeker));
                        Assert.IsNotNull(assignedGroep); // Checks if the assigned bezoeker belongs to a groep
                    }
                }
            }
        }

        [Test]
        public void AssignBezoekersToStoelen_NegativeTest() //checks if the bezoekers are not assigned to the stoelen 
        {
            // Arrange
            Evenement evenement = new Evenement();
            evenement.CreateVakken(3);
            evenement.CreateGroepen(0); // No groepen created

            // Act
            evenement.AssignBezoekersToStoelen();

            // Assert
            var vakken = evenement.GetVakken();
            foreach (var vak in vakken)
            {
                var rijen = vak.GetRijen();
                foreach (var rij in rijen)
                {
                    Assert.IsFalse(rij.GetStoelen().Any(stoel => stoel.IsBezet())); // Checks if no stoel is occupied in any rij
                }
            }
        }
    }
}