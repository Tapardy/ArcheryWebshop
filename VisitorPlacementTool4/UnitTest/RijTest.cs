using VisitorPlacementTool4;

namespace UnitTest
{
    public class RijTests
    {
        [Test]
        public void IsRijVol_ShouldReturnsTrue_PositiveTest() //checks if the rij is full
        {
            // Arrange
            Rij rij = new Rij(1);
            rij.CreateStoelen(5);
            foreach (var stoel in rij.GetStoelen())
            {
                stoel.CanAssignStoelToBezoeker(new Bezoeker(1));
            }

            // Act
            var isRijVol = rij.IsRijVol();

            // Assert
            Assert.IsTrue(isRijVol); 
        }

        [Test]
        public void IsRijVol_ShouldReturnFalse_NegativeTest() //checks if the rij is full
        {
            // Arrange
            Rij rij = new Rij(1);
            rij.CreateStoelen(5);

            // Act
            var isRijVol = rij.IsRijVol();

            // Assert
            Assert.IsFalse(isRijVol); 
        }

        [Test]
        public void AssignBezoekersToStoelen_KinderenAssignedToRij1Only_PositiveTest() //checks if the children are assigned to the first rij only
        {
            // Arrange
            Rij rij1 = new Rij(1);
            Rij rij2 = new Rij(2);
            Rij rij3 = new Rij(3);

            List<Bezoeker> bezoekers = new List<Bezoeker>
            {
                new Bezoeker(1), // Child
                new Bezoeker(2), // Adult
                new Bezoeker(3), // Child
                new Bezoeker(4), // Adult
                new Bezoeker(5) // Child
            };

            List<Groep> groepen = new List<Groep>
            {
                new Groep(1),
                new Groep(2)
            };

            groepen[0].AddBezoeker(bezoekers[0]);
            groepen[0].AddBezoeker(bezoekers[1]);
            groepen[1].AddBezoeker(bezoekers[2]);
            groepen[1].AddBezoeker(bezoekers[3]);
            groepen[1].AddBezoeker(bezoekers[4]);

            // Act
            rij1.AssignBezoekersToStoelen(groepen);
            rij2.AssignBezoekersToStoelen(groepen);
            rij3.AssignBezoekersToStoelen(groepen);

            // Assert
            foreach (var stoel in rij1.GetStoelen())
            {
                Assert.IsTrue(stoel.IsBezet() && stoel.GetBezoeker().IsKind());
            }

            foreach (var stoel in rij2.GetStoelen())
            {
                Assert.IsFalse(stoel.IsBezet() && stoel.GetBezoeker().IsKind());
            }

            foreach (var stoel in rij3.GetStoelen())
            {
                Assert.IsFalse(stoel.IsBezet() && stoel.GetBezoeker().IsKind());
            } 
        }

        [Test]
        public void AssignBezoekersToStoelen_NoKinderenAssignedToOtherRijen_NegativeTest() //checks if the children are assigned to the first rij only
        {
            // Arrange
            Rij rij1 = new Rij(1);
            Rij rij2 = new Rij(2);

            List<Bezoeker> bezoekers = new List<Bezoeker>
            {
                new Bezoeker(1), // Adult
                new Bezoeker(2), // Adult
                new Bezoeker(3) // Adult
            };

            List<Groep> groepen = new List<Groep>
            {
                new Groep(1),
                new Groep(2)
            };

            groepen[0].AddBezoeker(bezoekers[0]);
            groepen[1].AddBezoeker(bezoekers[1]);
            groepen[1].AddBezoeker(bezoekers[2]);

            // Act
            rij1.AssignBezoekersToStoelen(groepen);
            rij2.AssignBezoekersToStoelen(groepen);

            // Assert
            foreach (var stoel in rij1.GetStoelen())
            {
                Assert.IsFalse(stoel.IsBezet() && stoel.GetBezoeker().IsKind());
            }

            foreach (var stoel in rij2.GetStoelen())
            {
                Assert.IsFalse(stoel.IsBezet() && stoel.GetBezoeker().IsKind());
            } 
        }
    }
}