using LogicLayer;
using Moq;

[TestFixture]
public class EvenementTests
{
    [Test]
    public void TestAssignAllPendingBezoekers()
    {
        // Arrange
        var mockEvenement = new Mock<Evenement> { CallBase = true };
        Evenement evenement = mockEvenement.Object;
        
        evenement.AddBezoekerToVak("John", 25);
        evenement.AddBezoekerToVak("johs", 10);
        evenement.AddBezoekerToVak("johk", 30);
        evenement.AddBezoekerToVak("johr", 35);
        evenement.AddBezoekerToVak("bob", 3);
        evenement.AddBezoekerToVak("sob", 10);
        evenement.AddBezoekerToVak("nob", 9);
        evenement.AddBezoekerToVak("kob", 35);
        
        // Act
        int initialPendingCount = evenement.PendingBezoekersCount();
        evenement.AssignBezoekersToStoelen();

        // Assert
        Assert.AreEqual(0, evenement.PendingBezoekersCount());
        Assert.AreEqual(initialPendingCount, evenement.TotalAssignedBezoekersCount());
    }
    
    [Test]
    public void CreateNewVak_Count()
    {
        // Arrange
        var mockEvenement = new Mock<Evenement> { CallBase = true };
        Evenement evenement = mockEvenement.Object;
    
        // Act
        evenement.CreateNewVak('A');
    
        // Assert
        Assert.AreEqual(1, evenement.Vakken.Count);
    }
    
    [Test]
    public void AssignBezoekersToStoelen_Count()
    {
        // Arrange
        Evenement evenement = new Evenement();
        evenement.AddBezoekerToVak("Bezoeker 1", 20);
        evenement.AddBezoekerToVak("Bezoeker 2", 15);
        evenement.AddBezoekerToVak("Bezoeker 3", 10);
        evenement.AddBezoekerToVak("Bezoeker 4", 20);
        evenement.AddBezoekerToVak("Bezoeker 5", 15);
        evenement.AddBezoekerToVak("Bezoeker 6", 10);
        evenement.AddBezoekerToVak("Bezoeker 7", 20);
        evenement.AddBezoekerToVak("Bezoeker 8", 15);
        evenement.AddBezoekerToVak("Bezoeker 9", 10);
        evenement.AddBezoekerToVak("Bezoeker 10", 20);
        evenement.AddBezoekerToVak("Bezoeker 11", 15);
        evenement.AddBezoekerToVak("Bezoeker 12", 10);
        evenement.AddBezoekerToVak("Bezoeker 13", 20);
        evenement.AddBezoekerToVak("Bezoeker 14", 15);
        evenement.AddBezoekerToVak("Bezoeker 15", 10);

        // Act
        evenement.AssignBezoekersToStoelen();

        // Assert
        int assignedCount = evenement.Vakken.Sum(v => v.Rijen.Sum(r => r.Stoelen.Count(s => s.Bezoeker != null)));
        Assert.AreEqual(15, assignedCount);
    }

}
