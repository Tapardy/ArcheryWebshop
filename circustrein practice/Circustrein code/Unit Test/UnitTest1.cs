using CircusTreinClassLibrary;
using NUnit.Framework;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Type = CircusTreinClassLibrary.Type;

namespace CircusTreinTests
{
    public class TrainTests
    {
        [Test]
        public void AddAnimal_AddsToExistingWagon_WhenPossible()
        {
            // Arrange
            var train = new Train();
            train.AddAnimal(new Animal(Size.Small, Type.Herbivore));
            var existingWagon = train.wagons[0];

            // Act
            train.AddAnimal(new Animal(Size.Medium, Type.Herbivore));

            // Assert
            Assert.AreEqual(1, train.wagons.Count);
            Assert.AreEqual(2, existingWagon.Animals.Count);
        }

        [Test]
        public void AddAnimal_CreatesNewWagon_WhenNecessary()
        {
            // Arrange
            var train = new Train();
            train.AddAnimal(new Animal(Size.Large, Type.Herbivore));

            // Act
            train.AddAnimal(new Animal(Size.Large, Type.Herbivore));

            // Assert
            Assert.AreEqual(1, train.wagons.Count);
        }

        [Test]
        public void DisplayWagons_PrintsCorrectOutput()
        {
            // Arrange
            var train = new Train();
            train.AddAnimal(new Animal(Size.Small, Type.Herbivore));
            train.AddAnimal(new Animal(Size.Medium, Type.Carnivore));
            train.AddAnimal(new Animal(Size.Large, Type.Herbivore));
            train.AddAnimal(new Animal(Size.Medium, Type.Herbivore));

            // Act

            // Assert
            var expectedOutput = "Train has 2 wagons:\r\n" +
                                 "Wagon with animals:\r\n" +
                                 "Size: Small, Type: Herbivore\r\n" +
                                 "Size: Medium, Type: Carnivore\r\n" +
                                 "Size: Large, Type: Herbivore\r\n" +
                                 "Wagon with animals:\r\n" +
                                 "Size: Medium, Type: Herbivore\r\n";
        }

        private string CaptureConsoleOutput(System.Action action)
        {
            using (var consoleOutput = new System.IO.StringWriter())
            {
                System.Console.SetOut(consoleOutput);

                action();

                return consoleOutput.ToString();
            }
        }
    }

    public class WagonTests
    {
        [Test]
        public void CanAddAnimal_ReturnsTrue_WhenWagonIsEmpty()
        {
            // Arrange
            var wagon = new Wagon();
            var animal = new Animal(Size.Small, Type.Herbivore);

            // Act
            var result = wagon.AddAnimal(animal);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void CanAddAnimal_ReturnsTrue_WhenAnimalCanShareWithOtherHerbivores()
        {
            // Arrange
            var wagon = new Wagon();
            wagon.Animals.Add(new Animal(Size.Medium, Type.Herbivore));
            var animal = new Animal(Size.Small, Type.Herbivore);

            // Act
            var result = wagon.AddAnimal(animal);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void CanAddAnimal_ReturnsFalse_WhenAnimalCannotShareWithOtherHerbivores()
        {
            // Arrange
            var wagon = new Wagon();
            wagon.Animals.Add(new Animal(Size.Medium, Type.Herbivore));
            var animal = new Animal(Size.Large, Type.Herbivore);

            // Act
            var result = wagon.AddAnimal(animal);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void CanAddAnimal_ReturnsFalse_WhenAnimalIsCarnivore_AndLargerOrEqualSizeCarnivoreAlreadyPresent()
        {
            // Arrange
            var wagon = new Wagon();
            wagon.Animals.Add(new Animal(Size.Medium, Type.Carnivore));
            var animal = new Animal(Size.Large, Type.Carnivore);

            // Act
            var result = wagon.AddAnimal(animal);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void CanAddAnimal_ReturnsFalse_WhenAnimalIsHerbivore_AndLargerCarnivoreAlreadyPresent()
        {
            // Arrange
            var wagon = new Wagon();
            wagon.Animals.Add(new Animal(Size.Medium, Type.Carnivore));
            var animal = new Animal(Size.Small, Type.Herbivore);

            // Act
            var result = wagon.AddAnimal(animal);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void AddAnimal_AddsAnimalToWagon_WhenAnimalCanShareWithOtherHerbivores_AndNoCarnivoreIsLargeEnough()
        {
            // Arrange
            var wagon = new Wagon();
            wagon.Animals.Add(new Animal(Size.Medium, Type.Herbivore));
            var animal = new Animal(Size.Small, Type.Herbivore);

            // Act
            wagon.AddAnimal(animal);

            // Assert
            Assert.AreEqual(2, wagon.Animals.Count);
            Assert.IsTrue(wagon.Animals.Contains(animal));
        }

        [Test]
        public void AddAnimal_AddsAnimalToWagon_WhenAnimalIsCarnivore_AndNoLargerCarnivoreIsPresent()
        {
            // Arrange
            var wagon = new Wagon();
            var train = new Train();
            wagon.Animals.Add(new Animal(Size.Medium, Type.Carnivore));
            var animal = new Animal(Size.Small, Type.Carnivore);

            // Act
            wagon.AddAnimal(animal);

            // Assert
            Assert.AreEqual(1, wagon.Animals.Count);
            Assert.AreEqual(2, train.wagons.Count);
            Assert.IsTrue(wagon.Animals.Contains(animal));
        }

        [Test]
        public void AddAnimal_AddsAnimalToNewWagon_WhenAnimalCannotShareWithOtherHerbivores()
        {
            // Arrange
            var wagon1 = new Wagon();
            wagon1.Animals.Add(new Animal(Size.Medium, Type.Herbivore));
            var train = new Train();

            // Act
            train.AddAnimal(new Animal(Size.Large, Type.Herbivore));

        }
    }
}
