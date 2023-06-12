using VisitorPlacementTool4;

namespace UnitTest
{
    public class VakTests
    {
        [Test]
        public void CreateRijen_PositiveTest() //checks if the number of rijen is equal to the number of rijen that were created
        {
            // Arrange
            Vak vak = new Vak(1);
            int numRijen = 2;

            // Act
            vak.CreateRijen(numRijen);
            var rijen = vak.GetRijen();

            // Assert
            Assert.IsNotNull(rijen);
            Assert.AreEqual(numRijen, rijen.Count());
        }

        [Test]
        public void AssignBezoekersToStoelen_PositiveTest() //checks if the bezoekers are assigned to the stoelen
        {
            // Arrange
            Vak vak = new Vak(1);
            int numRijen = 3;
            vak.CreateRijen(numRijen);

            List<Groep> groepen = new List<Groep>
            {
                new Groep(1),
                new Groep(2),
                new Groep(3)
            };

            foreach (var groep in groepen)
            {
                var bezoeker = new Bezoeker(groep.GroepId);
                groep.AddBezoeker(bezoeker);
            }

            List<Bezoeker> bezoekers = groepen.SelectMany(g => g.Bezoekers()).ToList();

            // Act
            vak.AssignBezoekersToStoelen(groepen, bezoekers);

            // Assert
            var rijen = vak.GetRijen();
            foreach (var rij in rijen)
            {
                foreach (var stoel in rij.GetStoelen())
                {
                    if (stoel.IsBezet())
                    {
                        Assert.Pass(); // At least one stoel is occupied by a bezoeker
                        return;
                    }
                }
            }

            Assert.Fail("No bezoekers were assigned to stoelen.");
        }


        [Test]
        public void AssignBezoekersToStoelen_NegativeTest() //checks if the bezoekers are assigned to the stoelen
        {
            // Arrange
            Vak vak = new Vak(1);
            vak.CreateRijen(2);

            List<Groep> groepen = new List<Groep>
            {
                new Groep(1),
                new Groep(2)
            };

            // No bezoekers added to groepen

            // Act & Assert
            Assert.DoesNotThrow(() => vak.AssignBezoekersToStoelen(groepen, new List<Bezoeker>()));

            var rijen = vak.GetRijen();
            foreach (var rij in rijen)
            {
                foreach (var stoel in rij.GetStoelen())
                {
                    Assert.IsFalse(stoel.IsBezet()); // Checks if no stoelen are occupied when no bezoekers are provided
                }
            }
        }

        [Test]
        public void IsVakVol_ShouldReturnTrue_PositiveTest() //checks if the vak is full
        {
            // Arrange
            Vak vak = new Vak(1);
            vak.CreateRijen(2);

            foreach (var rij in vak.GetRijen())
            {
                rij.CreateStoelen(2);
                foreach (var stoel in rij.GetStoelen())
                {
                    stoel.CanAssignStoelToBezoeker(new Bezoeker(1));
                }
            }

            // Act
            var isVakVol = vak.IsVakVol();

            // Assert
            Assert.IsTrue(isVakVol);
        }

        [Test]
        public void IsVakVol_ShouldReturnFalse_NegativeTest() // Checks if the vak is not full when no stoelen are assigned
        {
            // Arrange
            Vak vak = new Vak(1);
            vak.CreateRijen(2);

            // Act
            var isVakVol = vak.IsVakVol();

            // Assert
            Assert.IsFalse(isVakVol); 
        }
    }
}